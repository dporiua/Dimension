using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(2);
        }
    }
}


