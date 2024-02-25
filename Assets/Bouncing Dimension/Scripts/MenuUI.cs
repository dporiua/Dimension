using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private GameObject option;

    private void Start()
    {
        option.SetActive(false);
    }
    public void ToGame()
    {

        SceneManager.LoadScene(1);


    }
    public void Option()
    {
        option.SetActive(true);
    }
    public void Back()
    {
        option.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }

}



