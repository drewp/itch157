using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class batt_pickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "battery")
        {
            Destroy(col.gameObject);
        }
        
    }
}
