using UnityEngine;

public class AddMeshColliders : MonoBehaviour
{
    void Start()
    {
        // Get all child objects including nested ones using GetComponentsInChildren
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();

        // Loop through each child that has a MeshFilter
        foreach (MeshFilter meshFilter in meshFilters)
        {
            // Check if it already has a MeshCollider, if not, add one
            if (meshFilter.gameObject.GetComponent<MeshCollider>() == null)
            {
                meshFilter.gameObject.AddComponent<MeshCollider>();
            }
        }
    }
}
