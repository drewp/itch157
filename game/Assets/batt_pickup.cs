using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.XR;

public class batt_pickup : MonoBehaviour
{
    private GameObject batt;
    [SerializeField]
    private GameObject heldbatt;
    private bool inRange = false;
    private bool holding = false;
    private bool facingright = true;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Battery" && holding == false)
        {
            inRange = true;
            batt = col.gameObject;
        }
        
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Battery")
        {
            inRange = false;
        }

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            facingright= true;
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            facingright= false;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(holding);
            if (holding == false)
            {
                if (inRange == true)
                {
                    holding = true;
                    Destroy(batt);

                }
            }
            else
            {

                var instance = Instantiate(heldbatt, transform.position, Quaternion.identity);
                if (facingright == true)
                {
                    instance.GetComponent<Rigidbody2D>().AddForce(transform.right * 100);
                }
                else
                {
                    instance.GetComponent<Rigidbody2D>().AddForce(transform.right * -100);
                }
                

                holding = false;
            }
            
        }

    }
}
