using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 100f;
    [SerializeField] private float startSteps = 0f;
    [SerializeField] private float step;

    [SerializeField] private PathData pathData;
    

    void Start()
    {
        step = startSteps;
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }

    private void Walk()
    {
        step += Time.deltaTime * walkSpeed;
        transform.position = pathData.GetPos(step);
    }

    public float GetStep()
    {
        return step;
    }


}
