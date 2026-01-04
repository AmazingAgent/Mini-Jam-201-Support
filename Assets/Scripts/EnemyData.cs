using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class EnemyDataType
{
    public GameObject enemyObject;
    public float steps;
}

public class EnemyData : MonoBehaviour
{
    [SerializeField] public List<EnemyDataType> enemies = new List<EnemyDataType>();

    void Start()
    {
        GetAllEnemies();
    }

    void Update()
    {

    }

    private void GetAllEnemies()
    {
        foreach (Transform childTransform in transform)
        {
            enemies.Add(new EnemyDataType { enemyObject = childTransform.gameObject, steps = childTransform.GetComponent<EnemyAI>().GetStep() });
        }
    }


    public List<EnemyDataType> SortEnemies()
    {
        return enemies.OrderBy(e => e.steps).ToList();
    }

}
