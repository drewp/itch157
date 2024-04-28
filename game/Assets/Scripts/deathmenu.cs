using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathmenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void retry()
    {
        SceneManager.LoadScene("Main");
    }
    public void quit()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
