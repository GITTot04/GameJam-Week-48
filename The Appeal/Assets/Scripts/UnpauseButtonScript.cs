using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpauseButtonScript : MonoBehaviour
{
    GameObject pauseScreen;
    private void Awake()
    {
        pauseScreen = GameObject.Find("PauseScreen");
    }
    public void Unpause()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }
}
