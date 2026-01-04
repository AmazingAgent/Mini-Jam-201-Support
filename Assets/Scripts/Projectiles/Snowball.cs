using UnityEngine;

public class Snowball : MonoBehaviour
{
    public float moveSpeed = 10f;

    public GameObject targetObject;


    void Start()
    {
        
    }

    void Update()
    {
        if (targetObject != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetObject.transform.position, moveSpeed * Time.deltaTime);
            transform.LookAt(targetObject.transform.position);
            if (Vector3.Distance(transform.position, targetObject.transform.position) < 0.3f)
            {
                targetObject.GetComponent<EnemyAI>().Slow(2.0f, 0.125f);
                Destroy(this.gameObject);
            }
        }
    }
}
