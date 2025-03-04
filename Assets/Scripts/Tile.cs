using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileType MyTileType;
    public List<ConnectionPoint> MyConnectionPointList;
    public TileManager MyTileManager;

    void Start()
    {
        MyTileManager = GameObject.Find("TileManager").GetComponent<TileManager>();
        MyTileManager.CurrentActiveTileGameObjectList.Add(gameObject);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("on trigger enter");
        if (other.CompareTag("Player"))
        {
            Debug.Log("inside compare tag");
            InstantiateNextTile(other.gameObject);
        }
    }

    private void InstantiateNextTile(GameObject player)
    {
        //get all the possible connection points that we could instantiate a tile on

        List<ConnectionPoint> possibleConnectionPoints = new List<ConnectionPoint>();

        for (int i = 0; i < MyConnectionPointList.Count; i++)
        {
            if (Vector3.Distance(MyConnectionPointList[i].transform.position, player.transform.position) > Constants.TILE_WIDTH/2)
            {
                possibleConnectionPoints.Add(MyConnectionPointList[i]);
            }
        }

        //Debug.Log("possible connection points: " + possibleConnectionPoints.Count);

        //randomly select which of the possible tiles you could instantiate on each connection point

        for (int i = 0; i < possibleConnectionPoints.Count; i++)
        {
            GameObject tileToInstantiate = possibleConnectionPoints[i].MyConnectableTileGameObjectList[Random.Range(0, possibleConnectionPoints[i].MyConnectableTileGameObjectList.Count)].gameObject;

            Vector3 instantiatedTileOffsetDirection = (possibleConnectionPoints[i].transform.position - transform.position).normalized;

            Instantiate(tileToInstantiate, transform.position + (instantiatedTileOffsetDirection * Constants.TILE_WIDTH), Quaternion.identity);
        }
    }
}
