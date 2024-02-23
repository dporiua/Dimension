using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody rb;
    private CameraToggle cameraToggle;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraToggle = FindObjectOfType<CameraToggle>(); // looks for the camera script
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (cameraToggle.IsOrthographic()) 
        {
            Vector3 movement = new Vector3(0.0f, 0.0f, moveVertical); //restricts 2d movement in just one direction, change if misalligned
            rb.velocity = movement * speed;
        }
        else
        {
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.velocity = movement * speed;
        }
    }
}
