using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class TowerAI : MonoBehaviour
{
    [SerializeField] private float attackRange = 2f;
    [SerializeField] public float startAttackCooldown = 1f;
    [SerializeField] public float attackCooldown;
    [SerializeField] public bool active = true;
    [SerializeField] private Attack attack;
    [SerializeField] private bool aoeAttack = false;

    private List<EnemyDataType> enemies = new List<EnemyDataType>();
    private List<EnemyDataType> enemiesInRange = new List<EnemyDataType>();
    [SerializeField] private GameObject firstEnemy;
    [SerializeField] private EnemyData enemyData;

    public Material deactivatedMat;
    private Material startMaterial;


    [SerializeField] private GameObject rangeObject;
    [SerializeField] private GameObject lookObject;

    void Start()
    {
        startMaterial = GetComponentInChildren<MeshRenderer>().material;
        ResetTower();
        enemyData = GameObject.Find("EnemyController").GetComponent<EnemyData>();
    }

    void Update()
    {
        if (active)
        {
            if (enemyData != null)
            {
                CheckForEnemies();
            }
        }
    }

    public void ResetTower()
    {
        attackCooldown = startAttackCooldown;
        GetComponentInChildren<MeshRenderer>().material = startMaterial;
        active = true;
        
    }

    private void CheckForEnemies()
    {
        enemies = enemyData.SortEnemies();
        enemiesInRange.Clear();
        foreach (EnemyDataType enemy in enemies)
        {
            if (enemy.enemyObject != null)
            {
                if (Vector3.Distance(transform.position, enemy.enemyObject.transform.position) < attackRange && enemy.enemyObject.GetComponent<EnemyAI>().active)
                {
                    enemiesInRange.Add(enemy);
                }
            }
        }
        if (enemiesInRange.Count > 0)
        {
            firstEnemy = enemiesInRange.First().enemyObject;
            LookAtEnemy();
            TryAttack();
        }
        else
        {
            attackCooldown = startAttackCooldown;
        }
    }

    private void LookAtEnemy()
    {
        if (lookObject != null)
        {
            lookObject.transform.LookAt(firstEnemy.transform.position + new Vector3(0, 1, 0));
        }
    }

    private void TryAttack()
    {
        attackCooldown -= Time.deltaTime;

        if (attackCooldown <= 0) // Do the attack
        {
            if (aoeAttack)
            {
                foreach (EnemyDataType enemy in enemiesInRange)
                {
                    if (enemy.enemyObject != null)
                    {
                        attack.DoAttack(enemy.enemyObject);
                    }
                }
            }
            else
            {
                attack.DoAttack(firstEnemy);
            }
                
            DeactivateTower();
        }
    }


    private void DeactivateTower()
    {
        active = false;
        //GetComponentInChildren<MeshRenderer>().material = deactivatedMat;
    }


    public void HideRange()
    {
        rangeObject.SetActive(false);
    }

    public void ShowRange()
    {
        rangeObject.SetActive(true);
    }

}
