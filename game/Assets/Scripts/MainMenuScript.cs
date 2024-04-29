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
        Cursor.visible = false;
        InfoScreen = transform.Find("InfoScreen").gameObject;
        MainScreen = transform.Find("MainScreen").gameObject;
        InfoScreen.SetActive(false);
    }

    public void StartGame()
    {
        Cursor.visible = true;

        SceneManager.LoadScene(MainGameScene);
    }
    public void ChangeScreen()
    {
        MainScreenOn = !MainScreenOn;
        if (MainScreenOn)
        {
            MainScreen.SetActive(true);
            InfoScreen.SetActive(false);
        Cursor.visible = false;

        }
        else
        {
            Cursor.visible = true;

            InfoScreen.SetActive(true);
            MainScreen.SetActive(false);
        }
    }
    
    void Update()
    {
        MouseHitter.transform.position = GetComponent<Camera>().ScreenToWorldPoint( Input.mousePosition);
        MouseHitter.transform.position += new Vector3(0,0,- MouseHitter.transform.position.z);
    }
}
