using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public static float Power = 1000;
    public static float MaxPower = 1000;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Power -= 5f;
    }
}
