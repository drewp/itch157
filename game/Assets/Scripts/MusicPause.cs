using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPause : MonoBehaviour
{
    bool paused = false;
    void Start()
    {
        
    }
    void Update()
    {
        if(Time.timeScale == 0 && paused == false)
        {
            this.gameObject.GetComponent<AudioSource>().Pause();
            paused = true;
        }
        if(paused == true && Time.timeScale == 1)
        {
            paused = false;
            this.gameObject.GetComponent<AudioSource>().UnPause();
        }
    }
}
