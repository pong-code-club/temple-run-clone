using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody MyRigidBody;
    public float MyPlayerSpeed;

    void Start()
    {
        MyRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -90, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Rotate(0, 90, 0);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            didJumpThisFixedUpdate = true;
        }
    }

    private bool didJumpThisFixedUpdate = false;

    private void FixedUpdate()
    {
        if (didJumpThisFixedUpdate == true)
        {
            MyRigidBody.AddForce(Vector3.up * 8, ForceMode.Impulse);
            didJumpThisFixedUpdate = false;
        }

        Vector3 directionToMoveIn = Vector3.zero;

        directionToMoveIn += transform.forward;

        if (Input.GetKey(KeyCode.A))
        {
            directionToMoveIn -= transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            directionToMoveIn += transform.right;
        }

        MyRigidBody.MovePosition(transform.position + (directionToMoveIn * Constants.PLAYER_SPEED * Time.fixedDeltaTime));

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //slide
        }
    }
}
