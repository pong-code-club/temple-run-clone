using System.Collections.Generic;
using UnityEngine;

public class LargeTile : MonoBehaviour
{
    public LargeTileType MyLargeTileType;
    public List<ConnectionPoint> MyConnectionPointList;
    private GameObject player;

    private bool shouldStartLifetimeCounter;
    private float lifetimeCounter;

    void Start()
    {
        player = GameObject.Find("Player");
        lifetimeCounter = Constants.LIFE_TIME_AFTER_PLAYER_EXITS_TILE;
    }

    void Update()
    {
        if (shouldStartLifetimeCounter == true)
        {
            RunLifetimeCounter();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InstantiateNextTile(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shouldStartLifetimeCounter = true;
        }
    }

    private void RunLifetimeCounter()
    {
        lifetimeCounter -= Time.deltaTime;
        if(lifetimeCounter < 0)
        {
            Debug.Log("destroy this");
            Destroy(gameObject);
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

            if (Vector3.Distance(connectionPointPos, playerPos) > Constants.TILE_WIDTH / 2)
            {
                possibleConnectionPoints.Add(MyConnectionPointList[i]);
            }
        }

        //for each connection point randomly select which of the possible tiles you could instantiate on each connection point

        for (int i = 0; i < possibleConnectionPoints.Count; i++)
        {
            GameObject tileToInstantiate = possibleConnectionPoints[i].MyConnectableTileGameObjectList[Random.Range(0, possibleConnectionPoints[i].MyConnectableTileGameObjectList.Count)].gameObject;

            //instantiate the tile
            GameObject instantiatedTile = Instantiate(tileToInstantiate, Vector3.zero, Quaternion.identity);

            Vector3 thisTileConnectionPointDirection = possibleConnectionPoints[i].transform.forward.normalized;

            List<ConnectionPoint> otherTileConnectionPoints = instantiatedTile.GetComponent<LargeTile>().MyConnectionPointList;

            ConnectionPoint targetTileMatchingConnectionPoint = null;

            //find the connection point on the target tile with the opposite direction
            for (int j = 0; j < otherTileConnectionPoints.Count; j++)
            {
                if (otherTileConnectionPoints[j].gameObject.transform.forward.normalized == -thisTileConnectionPointDirection)
                {
                    targetTileMatchingConnectionPoint = otherTileConnectionPoints[j];
                }
            }

            //create empty GO to child the matching other tile to
            GameObject parentNode = new GameObject();

            //move empty game object to same position as target connection point of your target tile
            parentNode.transform.position = targetTileMatchingConnectionPoint.transform.position;

            //parent the target tile to your parent node
            instantiatedTile.transform.parent = parentNode.transform;

            //move parent node into position
            parentNode.transform.position = possibleConnectionPoints[i].transform.position;
        }
    }
}
