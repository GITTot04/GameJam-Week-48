using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubmitButtonScript : MonoBehaviour
{
    GameObject appealText;
    GameObject kingsAnswer;
    GameObject continueButton;
    private void Awake()
    {
        appealText = GameObject.Find("AppealInput");
        kingsAnswer = GameObject.Find("KingsAnswer");
        continueButton = GameObject.Find("ContinueButton");
        continueButton.SetActive(false);
    }
    public void SubmitAppeal()
    {
        if (appealText.GetComponent<TMP_InputField>().text != "")
        {
            if (appealText.GetComponent<TMP_InputField>().text.ToLower().Contains("banana"))
            {
                kingsAnswer.GetComponent<TextMeshProUGUI>().text = "Ok... I guess you can live";
            }
            else if (appealText.GetComponent<TMP_InputField>().text.ToLower().Contains("jester"))
            {
                kingsAnswer.GetComponent<TextMeshProUGUI>().text = "HOW DARE YOU! IMMEDIATE DECAPITATION!!!";
            }
            else if (appealText.GetComponent<TMP_InputField>().text.ToLower().Contains("league"))
            {
                kingsAnswer.GetComponent<TextMeshProUGUI>().text = "DEATH";
            }
            else
            {
                kingsAnswer.GetComponent<TextMeshProUGUI>().text = "Cool story bro... TO THE DUNGEON";
            }
        }
        else
        {
            kingsAnswer.GetComponent<TextMeshProUGUI>().text = "No APPEAL!?!? TO THE DUNGEON!";
        }
        continueButton.SetActive(true);
    }
}
