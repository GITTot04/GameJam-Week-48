using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    GameObject pauseScreen;
    private void Awake()
    {
        pauseScreen = GameObject.Find("PauseScreen");
        pauseScreen.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
        }
    }
}
