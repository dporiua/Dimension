using UnityEngine;

public class BulletFire : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float delay = 1.0f;
    [SerializeField] private string obstacle = "Obstacle";
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(gameObject, delay);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(obstacle))
        {

            Destroy(gameObject);
        }

    }
}
