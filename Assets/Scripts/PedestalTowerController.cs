using UnityEngine;

public class PedestalTowerController : MonoBehaviour
{
    
    void Update()
    {
        foreach (Transform child in transform) {
            child.GetComponent<TowerAI>().HideRange();
            child.GetComponent<TowerAI>().enabled = false;
            child.GetComponent<Attack>().enabled = false;
        }
    }
}
