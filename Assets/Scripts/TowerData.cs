using System.Collections.Generic;
using UnityEngine;


public class TowerDataType
{
    public GameObject towerObject;
}
public class TowerData : MonoBehaviour
{
    [SerializeField] public List<TowerDataType> towers = new List<TowerDataType>();
    void Start()
    {
        GetAllTowers();
    }

    void Update()
    {

    }

    public void DeactivateAllTowers()
    {
        GetAllTowers();
        foreach (TowerDataType tower in towers)
        {
            tower.towerObject.GetComponent<TowerAI>().ResetTower();
            tower.towerObject.GetComponent<TowerAI>().ShowRange();
            //tower.towerObject.SetActive(false);
            //tower.towerObject.transform.position = new Vector3(1000f, 0, 0);
        }
    }

    public void ActivateAllTowers()
    {
        GetAllTowers();
        foreach (TowerDataType tower in towers)
        {
            tower.towerObject.GetComponent<TowerAI>().ResetTower();
            tower.towerObject.GetComponent<TowerAI>().HideRange();
            //tower.towerObject.SetActive(true);
        }
    }
    private void GetAllTowers()
    {
        towers.Clear();
        foreach (Transform childTransform in transform)
        {
            towers.Add(new TowerDataType { towerObject = childTransform.gameObject });
        }
    }
}
