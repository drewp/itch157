using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class batt_pickup : MonoBehaviour
{
    private GameObject batt;
    
    private bool inRange = false;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Battery")
        {
            inRange = true;
            batt = col.gameObject;
        }
        
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Battery")
        {
            inRange = true;
        }

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange == true)
        {
            Destroy(batt);
        }
    }
}
