using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float startHealth = 1f;
    [SerializeField] public float health;
    public bool active = false;
    
    

    [SerializeField] private float walkSpeed = 100f;
    [SerializeField] private float startSteps = 0f;
    [SerializeField] private float step;

    [SerializeField] private float freezeTimer = 0f;
    [SerializeField] private float slowTimer = 0f;
    [SerializeField] private float slowAmount = 1.0f;
    

    [SerializeField] private PathData pathData;
    

    void Start()
    {
        ResetEnemy();
        pathData = GameObject.Find("PathController").GetComponent<PathData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (step > 0 && health > 0) { active = true; }
        else { active = false; }


        if (freezeTimer <= 0)
        {
            if (slowTimer > 0)
            {
                slowTimer -= Time.deltaTime;
            }
            else
            {
                slowAmount = 1.0f;
            }
            Walk();
        }
        else
        {
            freezeTimer -= Time.deltaTime;
        }
    }

    public void ResetEnemy()
    {
        health = startHealth;
        step = startSteps;
        freezeTimer = 0f;
        slowTimer = 0f;
    }

    private void Walk()
    {
        step += Time.deltaTime * walkSpeed * slowAmount;
        transform.position = pathData.GetPos(step);
        LookNext();
    }

    private void LookNext()
    {
        transform.LookAt(pathData.GetNext(step));
    }


    public float GetStep()
    {
        return step;
    }

    public void SetStep(int newStep)
    {
        step = newStep;
    }
    private void KillEnemy()
    {
        active = false;
        gameObject.SetActive(false);
    }

    
    public void Damage(float damage) // Damage the enemy
    {
        health -= damage;
        if (health <= 0f)
        {
            KillEnemy();
        }
    }

    public void Freeze(float time)
    {
        freezeTimer = time;
    }

    public void Slow(float time, float slow)
    {
        slowTimer = time;
        slowAmount = slow;
    }



}
