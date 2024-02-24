using UnityEngine;

public class TutorialPuzzle : MonoBehaviour
{
    [SerializeField] private GameObject tutortext3;

    private void Start()
    {
        tutortext3.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            tutortext3.SetActive(true);


        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            tutortext3.SetActive(true);

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            tutortext3.SetActive(false);

        }
    }
}
