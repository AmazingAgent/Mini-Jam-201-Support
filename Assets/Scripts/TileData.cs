using UnityEngine;

public class TileData : MonoBehaviour
{
    [SerializeField] private GameObject tower;

    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddTower(GameObject newTower)
    {
        tower = newTower;
    }

    public GameObject GetTowerData()
    {
        return tower;
    }
    public void RemoveTower()
    {
        Debug.Log("destroyed tower");
        Destroy(tower);
        tower = null;
    }

    public bool IsFree()
    {
        if (tower != null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
