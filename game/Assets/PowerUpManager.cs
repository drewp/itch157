using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public int Type = 0;
    public GameObject PowerUpVars;
    public GameObject PowerPickupSound;
    public GameObject CanvasThing;
    void Start()
    {
        PowerPickupSound = GameObject.Find("PickUpPowerUp");
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
            PowerPickupSound.GetComponent<AudioSource>().Play();
            switch (Type)
            {
                case 1:
                    //Fast Feet
                    PowerUpVars.GetComponent<PowerUpVariables>().MovementSpeedMod += 0.07f;
                    break;
                case 2:
                    PowerUpVars.GetComponent<PowerUpVariables>().ClockSpeedMod += 0.10f;
                    break;
                case 3:
                    PowerUpVars.GetComponent<PowerUpVariables>().EnergyDrainMod += 0.10f;
                    break;
                case 4:
                    PowerUpVars.GetComponent<PowerUpVariables>().ClockPowerAddMod += 0.10f;
                    break;
            }
            CanvasThing.GetComponent<PowerUpUi>().PickedUpPowerUp(PowerUpVars.GetComponent<SpriteRenderer>().sprite);
            Destroy(gameObject);
        }
    }
}
