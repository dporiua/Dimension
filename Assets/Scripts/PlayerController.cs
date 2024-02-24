using System.Threading.Tasks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody rb;
    private CameraToggle cameraToggle;

    [SerializeField] private int maxhealth = 90;
    [SerializeField] private int thirdhealth = 60;
    [SerializeField] private int secondhealth = 30;
    [SerializeField] private int firsthealth = 0;

    [SerializeField] private float x = 0f;
    [SerializeField] private float y = -1.8f;
    [SerializeField] private float z = 29f;

    [SerializeField] private int currenthealth = 0;
    [SerializeField] private string damage = "Damage";
    [SerializeField] private GameObject deathScene;
    [SerializeField] private GameObject tutortext1;
    [SerializeField] private GameObject tutortext2;
    [SerializeField] Animator animator1;
    [SerializeField] private Animator animator2;
    [SerializeField] private Animator animator3;
    [SerializeField] private Animator animator4;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraToggle = FindObjectOfType<CameraToggle>(); // looks for the camera script
        currenthealth = maxhealth;
        tutortext1.SetActive(true);
        tutortext2.SetActive(false);
    }

    void Update()
    {
        MovePlayer();

    }

    private async void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag(damage) && currenthealth == maxhealth)
        {
            animator4.SetBool("health4", true);
            currenthealth = thirdhealth;
            await Task.Delay(100);
            transform.position = new Vector3(x, y, z);



        }
        if (collision.gameObject.CompareTag(damage) && currenthealth == thirdhealth)
        {
            animator3.SetBool("health3", true);
            currenthealth = secondhealth;
            await Task.Delay(100);
            transform.position = new Vector3(x, y, z);


        }
        if (collision.gameObject.CompareTag(damage) && currenthealth == secondhealth)
        {
            animator2.SetBool("health2", true);
            currenthealth = firsthealth;
            await Task.Delay(100);
            transform.position = new Vector3(x, y, z);


        }
        if (collision.gameObject.CompareTag(damage) && currenthealth == firsthealth)
        {
            animator1.SetBool("health1", true);
            await Task.Delay(100);
            deathScene.SetActive(true);

        }
    }

    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (cameraToggle.IsOrthographic())
        {
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f); //restricts 2d movement in just one direction, change if misalligned
            rb.velocity = movement * speed;
            tutortext2.SetActive(true);
            tutortext1.SetActive(false);
        }
        else
        {
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.velocity = movement * speed;
            tutortext2.SetActive(false);
            tutortext1.SetActive(true);
        }
    }
}
