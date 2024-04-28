using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AriIHateyou : MonoBehaviour
{
    bool walking = false;
    public Rigidbody2D Rigidbody;
    void Start()
    {
        walking = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GetComponent<AudioSource>().isPlaying);
        if (Mathf.Abs(Rigidbody.velocity.x) > 0 || Mathf.Abs(Rigidbody.velocity.y) > 0  && walking == false)
        {
            GetComponent<AudioSource>().Play();
            walking = true;
        }
        else
        {
            if (GetComponent<AudioSource>().isPlaying == true && Mathf.Abs(Rigidbody.velocity.x) <= 0 && Mathf.Abs(Rigidbody.velocity.y) <= 0)
            {
                GetComponent<AudioSource>().Stop();
                walking = false;
            }
        }
    }
}
