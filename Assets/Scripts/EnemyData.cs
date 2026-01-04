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
    public int enemiesLeft = 0;

    void Start()
    {
        GetAllEnemies();
        DeactivateAllEnemies();
        enemiesLeft = enemies.Count;
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
        enemiesLeft = enemies.Count;
    }

    public void ActivateAllEnemies()
    {
        foreach (EnemyDataType enemy in enemies)
        {
            enemy.enemyObject.GetComponent<EnemyAI>().ResetEnemy();
            enemy.enemyObject.SetActive(true);
        }
        enemiesLeft = enemies.Count;
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
