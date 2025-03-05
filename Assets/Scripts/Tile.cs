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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InstantiateNextTile(other.gameObject);
        }
    }

    private void InstantiateNextTile(GameObject player)
    {
        //get all the possible connection points that we could instantiate a tile on

        List<ConnectionPoint> possibleConnectionPoints = new List<ConnectionPoint>();

        for (int i = 0; i < MyConnectionPointList.Count; i++)
        {
            //0 out the y position so that jumping does not effect this calculation

            Vector3 connectionPointPos = new Vector3(MyConnectionPointList[i].transform.position.x, 0, MyConnectionPointList[i].transform.position.z);
            Vector3 playerPos = new Vector3(player.transform.position.x, 0, player.transform.position.z);

            if (Vector3.Distance(connectionPointPos, playerPos) > Constants.TILE_WIDTH/2)
            {
                possibleConnectionPoints.Add(MyConnectionPointList[i]);
            }
        }

        //randomly select which of the possible tiles you could instantiate on each connection point

        for (int i = 0; i < possibleConnectionPoints.Count; i++)
        {
            GameObject tileToInstantiate = possibleConnectionPoints[i].MyConnectableTileGameObjectList[Random.Range(0, possibleConnectionPoints[i].MyConnectableTileGameObjectList.Count)].gameObject;

            Vector3 instantiatedTileOffsetDirection = (possibleConnectionPoints[i].transform.position - transform.position).normalized;

            Instantiate(tileToInstantiate, transform.position + (instantiatedTileOffsetDirection * Constants.TILE_WIDTH), Quaternion.identity);
        }
    }
}
