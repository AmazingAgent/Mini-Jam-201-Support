using UnityEngine;

public class HelmetProjectile : MonoBehaviour
{
    public float moveSpeed = 10f;

    public GameObject targetObject;



    void Update()
    {
        if (targetObject != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetObject.transform.position, moveSpeed * Time.deltaTime);
            transform.LookAt(targetObject.transform.position);
            if (Vector3.Distance(transform.position, targetObject.transform.position) < 0.3f)
            {
                transform.position = targetObject.transform.position;
                targetObject = null;
            }
        }
    }
}
