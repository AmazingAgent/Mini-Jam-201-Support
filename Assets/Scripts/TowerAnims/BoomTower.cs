using UnityEngine;

public class BoomTower : MonoBehaviour
{
    [SerializeField] private TowerAI towerAI;
    private bool activated = false;

    public BoomAnim boomAnim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activated && activated != towerAI.active)
        {
            GetComponent<MeshRenderer>().enabled = false;
            boomAnim.StartBoom();
            activated = towerAI.active;
        }
        if (!activated && activated != towerAI.active)
        {
            GetComponent<MeshRenderer>().enabled = true;
            activated = towerAI.active;
        }

    }
}
