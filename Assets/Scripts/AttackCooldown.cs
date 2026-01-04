using UnityEngine;

public class AttackCooldown : MonoBehaviour
{

    public TowerAI towerAI;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (towerAI.attackCooldown > 0)
        {
            transform.localScale = new Vector3((towerAI.attackCooldown / towerAI.startAttackCooldown) * 0.9f, 0.1f, 0.1f);
        }
        else
        {
            transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
