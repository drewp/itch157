using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public string MainGameScene;
    private GameObject InfoScreen;
    private GameObject MainScreen;
    private bool MainScreenOn = true;
    public GameObject MouseHitter;

    void Start()
    {
        InfoScreen = transform.Find("InfoScreen").gameObject;
        MainScreen = transform.Find("MainScreen").gameObject;
        InfoScreen.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(MainGameScene);
    }
    public void ChangeScreen()
    {
        MainScreenOn = !MainScreenOn;
        if (MainScreenOn)
        {
            MainScreen.SetActive(true);
            InfoScreen.SetActive(false);
        }
        else
        {
            InfoScreen.SetActive(true);
            MainScreen.SetActive(false);
        }
    }
    
    void Update()
    {
        MouseHitter.transform.position = GetComponent<Camera>().ScreenToWorldPoint( Input.mousePosition)+new Vector3(0,0,20f);
    }
}
