using UnityEngine;
using System.Collections.Generic;

public class PedestalSelector : MonoBehaviour
{
    [SerializeField] private GameObject pedestalSelector;
    [SerializeField] private int pedestalIndex = 0;
    [SerializeField] private PlaceTower placeTower;

    [SerializeField] private GameObject towerParent;

    [SerializeField] private List<GameObject> towers;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Scroll Mouse
        if (towers.Count > 0)
        {
            if (Input.mouseScrollDelta.y > 0)
            {
                pedestalIndex += 1;
                if (pedestalIndex >= towers.Count)
                {
                    pedestalIndex = 0;
                }

                //placeTower.ChangeTower(towers[pedestalIndex]);
            }
            if (Input.mouseScrollDelta.y < 0)
            {
                pedestalIndex -= 1;
                if (pedestalIndex < 0)
                {
                    pedestalIndex = towers.Count - 1;
                }

                //placeTower.ChangeTower(towers[pedestalIndex]);
            }

            pedestalIndex = Mathf.Clamp(pedestalIndex, 0, towers.Count - 1);
            placeTower.ChangeTower(towers[pedestalIndex]);
        }
        // ================


        UpdateSelector();
        

        GetTowers();
        PlaceTowers();
    }

    private void UpdateSelector()
    {
        pedestalSelector.transform.position = new Vector3(-3 + pedestalIndex, 0f, -5f);
    }

    private void GetTowers()
    {
        towers.Clear();
        foreach (Transform tower in towerParent.transform)
        {
            towers.Add(tower.gameObject);
        }
    }

    private void PlaceTowers()
    {
        int index = 0;
        foreach (GameObject tower in towers)
        {
            tower.transform.position = new Vector3(-3 + index, 0.25f, -5f);
            index++;

            tower.GetComponent<TowerAI>().HideRange();
        }
    }

    public void RemoveTower()
    {
        Destroy(towers[pedestalIndex]);
        GetTowers();
        pedestalIndex = Mathf.Clamp(pedestalIndex - 1, 0, towers.Count - 1);
        placeTower.ChangeTower(towers[pedestalIndex]);

        UpdateSelector();
    }
}
