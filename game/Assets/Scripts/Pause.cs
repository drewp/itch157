using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
    bool pause = false;
    public GameObject PauseMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause == false)
            {
                PauseMenu.SetActive(true);
                pause = true;
                Time.timeScale = 0;
            } else {
                pause = false;
                Time.timeScale = 1;
                PauseMenu.SetActive(false);
            }
        }
    }
    public void resume()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
    }
    public void retry()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
