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
        DeactivateAllEnemies();
    }

    void Update()
    {

    }

    public void DeactivateAllEnemies()
    {
        foreach (EnemyDataType enemy in enemies)
        {
            enemy.enemyObject.SetActive(false);
            enemy.enemyObject.transform.position = new Vector3(1000f, 0, 0);
        }
    }

    public void ActivateAllEnemies()
    {
        foreach (EnemyDataType enemy in enemies)
        {
            enemy.enemyObject.GetComponent<EnemyAI>().ResetEnemy();
            enemy.enemyObject.SetActive(true);
        }
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
