using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class KnightController : MonoBehaviour
{
    [SerializeField] private EnemyAI enemyAI;
    [SerializeField] private List<Mesh> models = new List<Mesh>();
    private float health;
    void Start()
    {
        enemyAI = GetComponentInParent<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        GetHealth();
        SetModel();
    }
    
    private void GetHealth()
    {
        health = enemyAI.health;
    }

    private void SetModel()
    {
        switch (health)
        { 
            case 1:
                GetComponent<MeshFilter>().mesh = models[0];
                break;
            case 2:
                GetComponent<MeshFilter>().mesh = models[1];
                break;
            case 3:
                GetComponent<MeshFilter>().mesh = models[2];
                break;
            default:
                GetComponent<MeshFilter>().mesh = models[0];
                break;
        }
    }
}
