using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody MyRigidBody;
    public float MyPlayerSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MyRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            MyRigidBody.MovePosition(transform.position + new Vector3(0, 0, Constants.PLAYER_SPEED * Time.deltaTime));
            //transform.forward = Vector3.forward;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            MyRigidBody.MovePosition(transform.position + new Vector3(0, 0, -Constants.PLAYER_SPEED * Time.deltaTime));
            //transform.forward = Vector3.back;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MyRigidBody.MovePosition(transform.position + new Vector3(-Constants.PLAYER_SPEED * Time.deltaTime, 0, 0));
            //transform.forward = Vector3.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MyRigidBody.MovePosition(transform.position + new Vector3(Constants.PLAYER_SPEED * Time.deltaTime, 0, 0));
            //transform.forward = Vector3.right;
        }
    }
}
