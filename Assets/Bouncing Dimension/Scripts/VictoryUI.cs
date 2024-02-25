using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryUI : MonoBehaviour
{
    public void Reset()
    {

        SceneManager.LoadScene(1);

    }

    public void TitleScreen()
    {
        SceneManager.LoadScene(0);
    }
}
