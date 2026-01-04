using System.Collections.Generic;
using UnityEngine;

public class PathData : MonoBehaviour
{
    public List<GameObject> pathBlocks = new List<GameObject>();

    [SerializeField] public float pathLength;
    private float stepSize = 100f; // The number of units per tile

    void Start()
    {
        pathLength = stepSize * pathBlocks.Count;
    }

    public Vector3 GetPos(float step)
    {
        step = Mathf.Clamp(step,0,pathLength - stepSize);
        int index = (int)Mathf.Floor(step / 100); // get the index

        if (index < pathBlocks.Count - 1)
        {
            float percentage = (step - (index * stepSize)) / stepSize;
            Vector3 pos1 = pathBlocks[index].transform.position;
            Vector3 pos2 = pathBlocks[index + 1].transform.position;

            Vector3 finalPos = (pos1 * (1 - percentage)) + (pos2 * (percentage));

            return finalPos;
        }
        else
        {
            return pathBlocks[index].transform.position;
        }

    }

    public Vector3 GetNext(float step)
    {
        step = Mathf.Clamp(step, 0, pathLength - stepSize);
        int index = (int)Mathf.Floor(step / 100); // get the index
        return pathBlocks[index].transform.position;
    }

}
