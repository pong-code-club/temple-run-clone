using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public GameObject MyCharacter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MyCharacter.transform.position.z - transform.position.z >= 10)
        {
            transform.position = transform.position + new Vector3(0, 0, 15);
        }
    }
}
