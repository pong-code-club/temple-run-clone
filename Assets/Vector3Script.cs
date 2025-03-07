using UnityEngine;

public class Vector3Script : MonoBehaviour
{
    public Vector3 MyForwardDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MyForwardDirection = transform.forward;
    }
}
