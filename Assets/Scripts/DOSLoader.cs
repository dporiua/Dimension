using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;

public class SimpleDOSLoader : MonoBehaviour
{
    public TMP_Text loadingText;
    public TMP_InputField inputField;
    private bool isWaitingForInput = false;
    private int attemptCount = 0;
    private float nextLineTime = 0f;
    private float delayBetweenLines = 1f;
    private int currentLineIndex = 0;

    private string[] loadSteps =
    {
        "Initializing Simulation...",
        "Loading Assets...",
        "Verifying User Identity...",
        "Simulation Ready."
    };

    void Start()
    {
        inputField.gameObject.SetActive(false);


        void Update()
        {
            if (!isWaitingForInput)
            {
                if (Time.time >= nextLineTime && currentLineIndex < loadSteps.Length)
                {
                    loadingText.text += "\n" + loadSteps[currentLineIndex];
                    nextLineTime = Time.time + delayBetweenLines;
                    currentLineIndex++;


                    if (currentLineIndex == loadSteps.Length)
                    {
                        AskForConfirmation();
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    CheckConfirmation(inputField.text);
                }
            }
        }

        void AskForConfirmation()
        {
            loadingText.text += "\nType 'confirm' to continue.";
            inputField.gameObject.SetActive(true);
            // Automatically select the input field and focus on it
            inputField.Select();
            inputField.ActivateInputField();
            isWaitingForInput = true;
        }

        void CheckConfirmation(string input)
        {
            if (input.ToLower() == "confirm")
            {
                loadingText.text += "\nAccess Granted.";
                // Proceed with the game
                SceneManager.LoadScene("MainGameSceneName");
            }
            else
            {

                HandleIncorrectInput();
                inputField.text = "";

                inputField.Select();
                inputField.ActivateInputField();
            }
        }

        void HandleIncorrectInput()
        {
            attemptCount++;
            if (attemptCount == 1)
            {
                loadingText.text += "\nError, the test subject is refusing to cooperate.\nType 'confirm' to continue.";
            }
            else
            {
                loadingText.text +=
                    "\nError, the test subject is refusing to cooperate or can't type.\nType 'confirm' to continue.";
            }
        }
    }
}