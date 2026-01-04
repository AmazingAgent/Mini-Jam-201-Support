using UnityEngine;

public class BasicTower : MonoBehaviour
{
    [SerializeField] private TowerAI towerAI;
    private bool activated = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activated && activated != towerAI.active)
        {
            transform.localEulerAngles = new Vector3(-30f, -180f, 0f);
            activated = towerAI.active;
        }
        if (!activated && activated != towerAI.active)
        {
            transform.localEulerAngles = new Vector3(0f, -180f, 0f);
            activated = towerAI.active;
        }
    }
}
