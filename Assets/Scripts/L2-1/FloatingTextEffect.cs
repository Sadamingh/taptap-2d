using UnityEngine;
using TMPro;

public class FloatingTextEffect : MonoBehaviour
{
    public TMP_Text tmpText; // Reference to the TMP_Text component
    public float floatSpeed = 1f; // Speed of the floating effect
    public float floatAmount = 5f; // Amount to float up and down

    private TMP_TextInfo textInfo;

    void Start()
    {
        if (tmpText == null)
        {
            tmpText = GetComponent<TMP_Text>();
        }

        textInfo = tmpText.textInfo;
    }

    void Update()
    {
        tmpText.ForceMeshUpdate(); // Update the text mesh to get latest character positions

        for (int i = 0; i < textInfo.characterCount; i++)
        {
            if (!textInfo.characterInfo[i].isVisible)
                continue;

            // Get the vertices for each character
            int vertexIndex = textInfo.characterInfo[i].vertexIndex;
            Vector3[] vertices = textInfo.meshInfo[textInfo.characterInfo[i].materialReferenceIndex].vertices;

            // Calculate a floating offset using sine wave for smooth up-and-down motion
            float offsetY = Mathf.Sin(Time.time * floatSpeed + i) * floatAmount;

            // Apply the offset to each vertex of the character
            vertices[vertexIndex + 0].y += offsetY;
            vertices[vertexIndex + 1].y += offsetY;
            vertices[vertexIndex + 2].y += offsetY;
            vertices[vertexIndex + 3].y += offsetY;
        }

        // Update the mesh with the modified vertex positions
        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            textInfo.meshInfo[i].mesh.vertices = textInfo.meshInfo[i].vertices;
            tmpText.UpdateGeometry(textInfo.meshInfo[i].mesh, i);
        }
    }
}
