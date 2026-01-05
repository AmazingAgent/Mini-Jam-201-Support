using UnityEngine;
using UnityEngine.Audio;

public class Cannonball : MonoBehaviour
{
    public float moveSpeed = 10f;

    public GameObject targetObject;

    private AudioSource audioSource;

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
                audioSource = GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    audioSource.Play();
                }

                targetObject.GetComponent<EnemyAI>().Damage(1);
                Destroy(this.gameObject);
            }
        }
    }
}
