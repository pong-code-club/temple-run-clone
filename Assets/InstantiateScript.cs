using UnityEngine;

public class InstantiateScript : MonoBehaviour
{
    public GameObject GameObjectToInstantiate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject.Instantiate(GameObjectToInstantiate, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
