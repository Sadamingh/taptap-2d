using UnityEngine;

public class CatCoverageChecker : MonoBehaviour
{
    public CatController catController; // Reference to the CatController script
    public LayerMask maskLayer; // Set this to only detect objects with the "Mask" layer

    public void CheckCoverage()
    {
        if (!IsFullyCovered())
        {
            catController.TriggerFlashAndReset(); // Trigger flash and reset if not fully covered
        }
    }

    public bool IsFullyCovered()
    {
        Bounds bounds = GetComponent<Collider2D>().bounds;

        // Define points at each corner of the Cat's bounds
        Vector2[] checkPoints = new Vector2[]
        {
            bounds.min, // Bottom-left
            new Vector2(bounds.min.x, bounds.max.y), // Top-left
            bounds.max, // Top-right
            new Vector2(bounds.max.x, bounds.min.y) // Bottom-right
        };

        // Check if each corner point is covered by an object in the Mask layer
        foreach (var point in checkPoints)
        {
            RaycastHit2D hit = Physics2D.Raycast(point, Vector2.zero, 0, maskLayer);
            if (hit.collider == null || hit.collider.gameObject.layer != LayerMask.NameToLayer("Mask"))
            {
                return false; // Not fully covered if any point is uncovered
            }
        }

        return true; // All points are covered
    }
}
