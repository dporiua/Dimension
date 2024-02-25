using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    [SerializeField] bool paused;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject tutorset;
    [SerializeField] GameObject player;

    public void Start()
    {
        paused = false;
        Time.timeScale = 1;
        pauseScreen.SetActive(false);

    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            pauseScreen.SetActive(true);

            player.SetActive(false);
            tutorset.SetActive(false);

        }
    }

    public void Resume()
    {
        pauseScreen.SetActive(false);

        player.SetActive(true);
        tutorset.SetActive(true);
        paused = false;
        Time.timeScale = 1;
    }
    public void Reset()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void TitleScreen()
    {
        SceneManager.LoadScene(0);
    }
}



