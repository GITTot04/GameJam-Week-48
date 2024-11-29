using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject submitButton;
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void ActivateNextScene()
    {
        submitButton.GetComponent<SubmitButtonScript>().SwapToNextScene();
    }
}
