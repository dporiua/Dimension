using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    public float speed = 0.1f;
    public float rotateValue;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed, 0);
        rotateValue += speed;
    }
}
