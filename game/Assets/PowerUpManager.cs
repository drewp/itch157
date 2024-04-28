using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public int Type = 0;
    public GameObject PowerUpVars;
    void Start()
    {
        PowerUpVars = GameObject.Find("PowerUpObject");
        switch (Type)
        {
            case 1:
                //Fast Feet
                PowerUpVars.GetComponent<PowerUpVariables>().MovementSpeedMod += 0.7f;
                break;
        }
    }
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PowerUpVars = GameObject.Find("PowerUpObject");
            switch (Type)
            {
                case 1:
                    //Fast Feet
                    PowerUpVars.GetComponent<PowerUpVariables>().MovementSpeedMod += 0.07f;
                    break;
            }
            Destroy(gameObject);
        }
    }
}
