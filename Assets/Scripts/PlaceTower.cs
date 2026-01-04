using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.LowLevelPhysics2D.PhysicsShape;

public class PlaceTower : MonoBehaviour
{
    [SerializeField] private List<GameObject> towers = new List<GameObject>();
    [SerializeField] private GameObject currentTower;
    private int towerID = 0;

    private Vector3 currentPosition = Vector3.zero;
    private GameObject currentTile = null;
    private bool onTile = false;
    private bool tileFree = false;

    [SerializeField] private GameObject towerParent;


    [SerializeField] private bool gameActive = false;
    [SerializeField] private TowerData towerData;
    [SerializeField] private EnemyData enemyData;

    [SerializeField] private GameObject tileSelector;
    [SerializeField] private PedestalSelector pedestalSelector;
    [SerializeField] private GameObject pedestalParent;
    [SerializeField] private GameObject emptyTower;

    [SerializeField] private GameObject projectileController;
    void Start()
    {
        currentTower = Instantiate(towers[towerID]);
    }

    
    void Update()
    {
        // Whether game is active or not
        if (Input.GetKeyDown(KeyCode.Space) && !gameActive)
        {
            towerData.ActivateAllTowers();
            enemyData.ActivateAllEnemies();
            gameActive = true;


            currentTower.SetActive(false);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && gameActive)
            {
                towerData.DeactivateAllTowers();
                enemyData.DeactivateAllEnemies();
                gameActive = false;


                currentTower.SetActive(true);
            }
        }

        

        // Game is not running
        if (!gameActive)
        {
            /*
            if (Input.mouseScrollDelta.y > 0)
            {
                Destroy(currentTower);
                towerID += 1;
                if (towerID >= towers.Count)
                {
                    towerID = 0;
                }
                currentTower = Instantiate(towers[towerID]);
            }
            if (Input.mouseScrollDelta.y < 0)
            {
                Destroy(currentTower);
                towerID -= 1;
                if (towerID < 0)
                {
                    towerID = towers.Count - 1;
                }
                currentTower = Instantiate(towers[towerID]);
            }
            */

            RaycastToGrid();
            currentTower.transform.position = currentPosition;

            if (onTile)
            {
                if (Input.GetMouseButtonDown(0) && tileFree && currentTower.GetComponent<TowerAI>() != null)
                {
                    PlaceDownTower();
                    pedestalSelector.RemoveTower();
                }
                if (Input.GetMouseButtonDown(1) && !tileFree)
                {
                    DestroyTower();
                }
            }
        }
        else
        {
            currentTower.transform.position = new Vector3(0, -100f, 0);
        }
            // ===============================


            UpdateSelector();
    }


    public void ResetRound()
    {
        towerData.DeactivateAllTowers();
        enemyData.DeactivateAllEnemies();
        gameActive = false;
        projectileController.GetComponent<CleanupProjectiles>().CleanupAllProjectiles();

        currentTower.SetActive(true);
    }

    private void RaycastToGrid()
    {
        int layer_mask = LayerMask.GetMask("Placeable");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        currentTile = null;
        onTile = false;
        tileFree = false;
        currentPosition = new Vector3(0, -100f, 0);

        if (Physics.Raycast(ray, out hit, 100f, layer_mask))
        {
            if (hit.collider.gameObject.GetComponent<TileData>() != null) // Real tile
            {
                currentTile = hit.collider.gameObject;
                onTile = true;
                if (hit.collider.gameObject.GetComponent<TileData>().IsFree())
                {
                    currentPosition = currentTile.transform.position;
                    tileFree = true;
                }
            }
        }
    }

    public void PlaceDownTower()
    {
        currentTower.transform.position = currentPosition;
        currentTower.transform.parent = towerParent.transform;
        currentTile.GetComponent<TileData>().AddTower(currentTower);


        currentTower = Instantiate(towers[towerID], currentPosition, transform.rotation);
    }

    public void DestroyTower()
    {
        GameObject tempTower = Instantiate(currentTile.GetComponent<TileData>().GetTowerData());
        tempTower.transform.parent = pedestalParent.transform;
        currentTile.GetComponent<TileData>().RemoveTower();
    }


    private void UpdateSelector()
    {
        int layer_mask = LayerMask.GetMask("Placeable");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        GameObject selectedTile = null;
        Vector3 selectedPosition = new Vector3(0, -100f, 0);

        if (Physics.Raycast(ray, out hit, 100f, layer_mask))
        {
            selectedTile = hit.collider.gameObject;
            selectedPosition = selectedTile.transform.position;
        }

        tileSelector.transform.position = selectedPosition;
    }

    public void ChangeTower(GameObject newTower)
    {
        //Debug.Log("change tower");
        Destroy(currentTower);
        if (newTower != null)
        {
            currentTower = Instantiate(newTower);
            currentTower.name = newTower.name;
            currentTower.GetComponent<TowerAI>().enabled = true;
            currentTower.GetComponent<TowerAI>().ShowRange();
            currentTower.GetComponent<Attack>().enabled = true;
        }
        else
        {
            currentTower = Instantiate(emptyTower);
        }
    }

}
