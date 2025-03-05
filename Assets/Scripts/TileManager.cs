using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public List<GameObject> CurrentActiveTileGameObjectList;

    void Start()
    {

    }

    void Update()
    {
        if(CurrentActiveTileGameObjectList.Count > 3)
        {
            Destroy(CurrentActiveTileGameObjectList[0]);
            CurrentActiveTileGameObjectList.RemoveAt(0);
        }
    }
}
