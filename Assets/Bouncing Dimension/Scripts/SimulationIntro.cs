using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DOSPrompt : MonoBehaviour
{
    public TMP_Text displayText; 
    public TMP_InputField inputField; 

    private void Start()
    {
        StartCoroutine(SimulationSequence());
    }

    IEnumerator SimulationSequence()
    {
       
        string[] lines = {
            "Initializing Simulation...",
            "Loading Assets...",
            "Verifying Prisoner Identity..."
        };

        
        foreach (var line in lines)
        {
            AppendText(line);
            yield return new WaitForSeconds(2);
        }

        
        CorrectIdentity();
        yield return new WaitForSeconds(2);

        AppendText("Simulation Ready.\nType 'confirm' to consent to the experiment.");
        ActivateInputField();
    }

    private void AppendText(string text)
    {
        displayText.text += (displayText.text == "" ? "" : "\n") + text;
    }

    private void CorrectIdentity()
    {
        displayText.text = displayText.text.Replace("Verifying Prisoner Identity...", "Verifying User Identity..."); //Reminder to use this from now on
    }

    private void ActivateInputField()
    {
        inputField.gameObject.SetActive(true);
        inputField.onEndEdit.AddListener(delegate { ValidateInput(inputField.text); });
        inputField.ActivateInputField();
    }

    private void ValidateInput(string input)
    {
        if (input.ToLower() == "confirm")
        {
            displayText.text += "\n> User confirmed, commencing simulation ";
            SceneManager.LoadScene("Tutorail 1");
        }
        else
        {
            displayText.text += "\nError, the test subject is refusing to cooperate or can't type.\nType 'confirm' to continue.";
            inputField.text = ""; 
            inputField.ActivateInputField(); 
        }
    }
}