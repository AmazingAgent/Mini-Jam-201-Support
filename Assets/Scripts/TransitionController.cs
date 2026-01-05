using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour
{
    public GameObject rightHalf;
    public GameObject leftHalf;
    public float speed;

    public bool closing = false;
    public bool opening = true;

    public int nextSceneID = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (opening)
        {
            if (rightHalf.transform.position.x < 15)
            {
                rightHalf.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                leftHalf.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            }
            else
            {
                opening = false;
            }
        }

        if (closing)
        {
            if (rightHalf.transform.position.x > 0)
            {
                rightHalf.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
                leftHalf.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }
            else
            {
                rightHalf.transform.position = new Vector3(0, rightHalf.transform.position.y, 0);
                leftHalf.transform.position = new Vector3(0, rightHalf.transform.position.y, 0);
                closing = false;
                SceneManager.LoadScene(nextSceneID);
            }
        }
    }
}
