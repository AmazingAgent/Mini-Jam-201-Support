using UnityEngine;

public class CleanupProjectiles : MonoBehaviour
{
    public void CleanupAllProjectiles()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
