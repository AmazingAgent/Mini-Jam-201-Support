using UnityEngine;

public class BoomAnim : MonoBehaviour
{
    public float boomTime;
    public float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (timer > 0)
        {
            GetComponent<MeshRenderer>().enabled = true;
            timer -= Time.deltaTime;
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = false;
            timer = 0;
        }
    }

    public void StartBoom()
    {
        timer = boomTime;
    }
}
