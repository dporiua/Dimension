using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(3);
        }
    }
}
