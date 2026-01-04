using System.Linq;
using UnityEngine;

public class TowerAI : MonoBehaviour
{
    [SerializeField] private GameObject firstEnemy;
    [SerializeField] private EnemyData enemyData;


    void Start()
    {
        
    }

    void Update()
    {
        firstEnemy = enemyData.SortEnemies().First().enemyObject;
        transform.LookAt(firstEnemy.transform.position);
    }
}
