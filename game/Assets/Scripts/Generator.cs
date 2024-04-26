using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public float Power = 1000;
    public float MaxPower = 1000;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Power -= 1f;
        if(Power <= 0)
        {
            Power = 0;
        }
    }
}
