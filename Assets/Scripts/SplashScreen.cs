using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{
    public GameObject uUiObject;
    public GameObject uPlayer;
    public GameObject uUICamera;
    public static bool gameHasStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void StartGame()
    {
        gameHasStarted=true;
        uUICamera.SetActive(false);
        uUiObject.SetActive(false);
        uPlayer.SetActive(true);
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
