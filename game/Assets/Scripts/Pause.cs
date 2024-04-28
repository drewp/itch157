using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool pause = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause == false)
            {
                pause = true;
                Time.timeScale = 0;
            } else {
                pause = false;
                Time.timeScale = 1;
            }
        }
    }
}
