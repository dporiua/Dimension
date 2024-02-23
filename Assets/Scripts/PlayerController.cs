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

        if (cameraToggle.IsOrthographic()) // Checks the camera to find the state
        {
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
            rb.velocity = movement * speed;
        }
        else
        {
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.velocity = movement * speed;
        }
    }
}
