using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;


public class Attack : MonoBehaviour
{
    [SerializeField] private string attackType = "";
    [SerializeField] private GameObject projectileParent;

    public List<GameObject> projectiles = new List<GameObject>();
    void Start()
    {
        projectileParent = GameObject.Find("Projectiles");
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
            case "magnet":
                MagnetAttack(enemy);
                break;
            default:
                break;
        }
    }

    private void BasicAttack(GameObject enemy)
    {
        GameObject newProjectile = Instantiate(projectiles[0]);
        projectileParent = GameObject.Find("Projectiles");
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = transform.position;
        newProjectile.GetComponent<Cannonball>().targetObject = enemy;
        //enemy.GetComponent<EnemyAI>().Damage(1f);
    }

    private void FreezeAttack(GameObject enemy)
    {
        enemy.GetComponent<EnemyAI>().Freeze(1.5f);
    }

    private void SlowAttack(GameObject enemy)
    {
        GameObject newProjectile = Instantiate(projectiles[0]);
        projectileParent = GameObject.Find("Projectiles");
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = transform.position;
        newProjectile.GetComponent<Snowball>().targetObject = enemy;
        //enemy.GetComponent<EnemyAI>().Slow(2.0f, 0.125f);
    }

    private void BoomAttack(GameObject enemy)
    {
        enemy.GetComponent<EnemyAI>().Damage(2f);
    }

    private void MagnetAttack(GameObject enemy)
    {
        enemy.GetComponent<EnemyAI>().SetHP(1);
        GameObject newProjectile = Instantiate(projectiles[0]);
        projectileParent = GameObject.Find("Projectiles");
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = enemy.transform.position;
        newProjectile.GetComponent<HelmetProjectile>().targetObject = this.gameObject;
    }
}
