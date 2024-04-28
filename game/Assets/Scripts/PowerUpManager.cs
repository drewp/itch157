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
    }
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Color color = new Color();
            PowerUpVars = GameObject.Find("PowerUpObject");
            PowerPickupSound.GetComponent<AudioSource>().Play();
            switch (Type)
            {
                case 1:
                    //Fast Feet
                    PowerUpVars.GetComponent<PowerUpVariables>().MovementSpeedMod += 0.07f;
                    color = Color.white;
                    break;
                case 2:
                    PowerUpVars.GetComponent<PowerUpVariables>().ClockSpeedMod += 0.10f;
                    color = Color.white;
                    break;
                case 3:
                    PowerUpVars.GetComponent<PowerUpVariables>().EnergyDrainMod += 0.10f;
                    color = Color.white;
                    break;
                case 4:
                    PowerUpVars.GetComponent<PowerUpVariables>().ClockPowerAddMod += 0.10f;
                    color = Color.white;
                    break;
                case 5:
                    PowerUpVars.GetComponent<PowerUpVariables>().AttackSpeedMod += 0.10f;
                    color = Color.white;
                    break;
                case 6:
                    PowerUpVars.GetComponent<PowerUpVariables>().HealthAddMod += 0.10f;
                    color = Color.white;
                    break;                
                case 7:
                    PowerUpVars.GetComponent<PowerUpVariables>().BatteryDropChanceMod += 20f;
                    color = Color.white;
                    break;
                case 8:
                    PowerUpVars.GetComponent<PowerUpVariables>().BatteryRechargeMod += 0.2f;
                    color = Color.white;
                    break;
                case 9:
                    PowerUpVars.GetComponent<PowerUpVariables>().DamageMod += 0.1f;
                    color = Color.white;
                    break;
                case 10:
                    PowerUpVars.GetComponent<PowerUpVariables>().BatteryCarrySpeedMod += 0.2f;
                    color = Color.green;
                    break;
                case 11:
                    PowerUpVars.GetComponent<PowerUpVariables>().BatteryThrowingDistanceAddMod += 0.3f;
                    color = Color.green;
                    break;
                case 12:
                    PowerUpVars.GetComponent<PowerUpVariables>().SubTotalDamageTakenMod += 0.1f;
                    color = Color.green;
                    break;
                case 13:
                    PowerUpVars.GetComponent<PowerUpVariables>().ClockPowerMod += 0.3f;
                    color = Color.green;
                    break;
                case 14:
                    PowerUpVars.GetComponent<PowerUpVariables>().FullyRechargeChanceMod += 2;
                    color = new Color(128, 0, 128);
                    break;
            }
            GameObject.Find("PowerUpInvintory").GetComponent<PowerUpUi>().PickedUpPowerUp(GetComponent<SpriteRenderer>().sprite, color);
            GameObject.Find("PowerUpInvintory").GetComponent<PowerUpUi>().DoPowerUpPopUp(GetComponent<SpriteRenderer>().sprite, "meth", "I love meth", color);
            Destroy(gameObject);
        }
    }
}
