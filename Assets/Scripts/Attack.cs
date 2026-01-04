using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private string attackType = "";

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoAttack(GameObject enemy)
    {
        switch (attackType)
        {
            case "basic":
                BasicAttack(enemy);
                break;
            case "freeze":
                FreezeAttack(enemy);
                break;
            case "slow":
                SlowAttack(enemy);
                break;
            case "boom":
                BoomAttack(enemy);
                break;
            default:
                break;
        }
    }

    private void BasicAttack(GameObject enemy)
    {
        enemy.GetComponent<EnemyAI>().Damage(1f);
    }

    private void FreezeAttack(GameObject enemy)
    {
        enemy.GetComponent<EnemyAI>().Freeze(1.5f);
    }

    private void SlowAttack(GameObject enemy)
    {
        enemy.GetComponent<EnemyAI>().Slow(2.0f, 0.25f);
    }

    private void BoomAttack(GameObject enemy)
    {
        enemy.GetComponent<EnemyAI>().Damage(2f);
    }
}
