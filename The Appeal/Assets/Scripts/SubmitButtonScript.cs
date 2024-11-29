using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SubmitButtonScript : MonoBehaviour
{
    GameObject appealText;
    GameObject kingsAnswer;
    GameObject continueButton;
    GameObject inputField;
    int nextScene;
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        appealText = GameObject.Find("AppealInput");
        kingsAnswer = GameObject.Find("KingsAnswer");
        continueButton = GameObject.Find("ContinueButton");
        inputField = GameObject.Find("AppealInput");
        continueButton.SetActive(false);
    }
    public void SubmitAppeal()
    {
        if (appealText.GetComponent<TMP_InputField>().text != "")
        {
            if (appealText.GetComponent<TMP_InputField>().text.ToLower().Contains("banana"))
            {
                kingsAnswer.GetComponent<TextMeshProUGUI>().text = "Ok... I guess you can live";
                nextScene = 2;
            }
            else if (appealText.GetComponent<TMP_InputField>().text.ToLower().Contains("jester"))
            {
                kingsAnswer.GetComponent<TextMeshProUGUI>().text = "HOW DARE YOU! IMMEDIATE DECAPITATION!!!";
                nextScene = 0;
            }
            else if (appealText.GetComponent<TMP_InputField>().text.ToLower().Contains("league"))
            {
                kingsAnswer.GetComponent<TextMeshProUGUI>().text = "DEATH";
                nextScene = 0;
            }
            else
            {
                kingsAnswer.GetComponent<TextMeshProUGUI>().text = "Cool story bro... TO THE DUNGEON";
                nextScene = 1;
            }
        }
        else
        {
            kingsAnswer.GetComponent<TextMeshProUGUI>().text = "No APPEAL!?!? TO THE DUNGEON!";
            nextScene = 1;
        }
        continueButton.SetActive(true);
        inputField.SetActive(false);
    }
    public void SwapToNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
