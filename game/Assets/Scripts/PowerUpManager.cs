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
            PowerUpUi PUI = GameObject.Find("PowerUpInvintory").GetComponent<PowerUpUi>();
            switch (Type)
            {
                case 1:
                    //Fast Feet
                    PowerUpVars.GetComponent<PowerUpVariables>().MovementSpeedMod += 0.07f;
                    color = Color.white;
                    PUI.DoPowerUpPopUp(GetComponent<SpriteRenderer>().sprite, "Fast Feet", "Raises your speed by 7%", color);
                    if (PowerUpVars.GetComponent<PowerUpVariables>().PickedUp[Type] < 1)
                    {
                        PUI.DoPowerUpPopUp(GetComponent<SpriteRenderer>().sprite, "Fast Feet", "Raises your speed by 7%", color);
                        PowerUpVars.GetComponent<PowerUpVariables>().PickedUp[Type] += 1;
                    }
                    break;
                case 2:
                    PowerUpVars.GetComponent<PowerUpVariables>().ClockSpeedMod += 0.5f;
                    color = Color.white;
                    if (PowerUpVars.GetComponent<PowerUpVariables>().PickedUp[Type] < 1)
                    {
                        PUI.DoPowerUpPopUp(GetComponent<SpriteRenderer>().sprite, "Speed Of Light + 1", "Raises clock speed by 5%", color);
                        PowerUpVars.GetComponent<PowerUpVariables>().PickedUp[Type] += 1;
                    }
                    break;
                case 3:
                    PowerUpVars.GetComponent<PowerUpVariables>().EnergyDrainMod += 0.10f;
                    color = Color.white;
                    if (PowerUpVars.GetComponent<PowerUpVariables>().PickedUp[Type] < 1)
                    {
                        PUI.DoPowerUpPopUp(GetComponent<SpriteRenderer>().sprite, "Speed Of Light - 1", "Lowers energy drain by 10%", color);
                        PowerUpVars.GetComponent<PowerUpVariables>().PickedUp[Type] += 1;
                    }
                    break;
                case 4:
                    PowerUpVars.GetComponent<PowerUpVariables>().ClockPowerAddMod += 0.10f;
                    color = Color.white;
                    if (PowerUpVars.GetComponent<PowerUpVariables>().PickedUp[Type] < 1)
                    {
                        PUI.DoPowerUpPopUp(GetComponent<SpriteRenderer>().sprite, "Unlimited Power", "Adds 100 to the clock power", color);
                        PowerUpVars.GetComponent<PowerUpVariables>().PickedUp[Type] += 1;
                    }
                    break;
                case 5:
                    PowerUpVars.GetComponent<PowerUpVariables>().AttackSpeedMod += 0.10f;
                    color = Color.white;
                    if (PowerUpVars.GetComponent<PowerUpVariables>().PickedUp[Type] < 1)
                    {
                        PUI.DoPowerUpPopUp(GetComponent<SpriteRenderer>().sprite, "Degreased Fingers", "Raises attack speed by 10%", color);
                        PowerUpVars.GetComponent<PowerUpVariables>().PickedUp[Type] += 1;
                    }
                    break;
                case 6:
                    PowerUpVars.GetComponent<PowerUpVariables>().HealthAddMod += 0.10f;
                    color = Color.white;
                    if (PowerUpVars.GetComponent<PowerUpVariables>().PickedUp[Type] < 1)
                    {
                        PUI.DoPowerUpPopUp(GetComponent<SpriteRenderer>().sprite, "Steel Gears", "Raises mechanics health by 10%", color);
                        PowerUpVars.GetComponent<PowerUpVariables>().PickedUp[Type] += 1;
                    }
                    break;                
                case 7:
                    PowerUpVars.GetComponent<PowerUpVariables>().BatteryDropChanceMod += 20f;
                    color = Color.white;
                    if (PowerUpVars.GetComponent<PowerUpVariables>().PickedUp[Type] < 1)
                    {
                        PUI.DoPowerUpPopUp(GetComponent<SpriteRenderer>().sprite, "Delicate Fingers", "Raises Battery Drop Chance By 10%", color);
                        PowerUpVars.GetComponent<PowerUpVariables>().PickedUp[Type] += 1;
                    }
                    break;
                case 8:
                    PowerUpVars.GetComponent<PowerUpVariables>().BatteryRechargeMod += 0.2f;
                    color = Color.white;
                    if (PowerUpVars.GetComponent<PowerUpVariables>().PickedUp[Type] < 1)
                    {
                        PUI.DoPowerUpPopUp(GetComponent<SpriteRenderer>().sprite, "Bigger Batteries", "Increases amount recharged by batteries by 20%", color);
                        PowerUpVars.GetComponent<PowerUpVariables>().PickedUp[Type] += 1;
                    }
                    break;
                case 9:
                    PowerUpVars.GetComponent<PowerUpVariables>().DamageMod += 0.1f;
                    color = Color.white;
                    if (PowerUpVars.GetComponent<PowerUpVariables>().PickedUp[Type] < 1)
                    {
                        PUI.DoPowerUpPopUp(GetComponent<SpriteRenderer>().sprite, "Steriods", "Raises mechanics damage by 10%", color);
                        PowerUpVars.GetComponent<PowerUpVariables>().PickedUp[Type] += 1;
                    }
                    break;
                case 10:
                    PowerUpVars.GetComponent<PowerUpVariables>().BatteryCarrySpeedMod += 0.2f;
                    color = Color.green;
                    if (PowerUpVars.GetComponent<PowerUpVariables>().PickedUp[Type] < 1)
                    {
                        PUI.DoPowerUpPopUp(GetComponent<SpriteRenderer>().sprite, "Creatine", "While carrying a battery mechanic is 20% faster", color);
                        PowerUpVars.GetComponent<PowerUpVariables>().PickedUp[Type] += 1;
                    }
                    break;
                case 11:
                    PowerUpVars.GetComponent<PowerUpVariables>().BatteryThrowingDistanceAddMod += 0.3f;
                    color = Color.green;
                    if (PowerUpVars.GetComponent<PowerUpVariables>().PickedUp[Type] < 1)
                    {
                        PUI.DoPowerUpPopUp(GetComponent<SpriteRenderer>().sprite, "Thor", "Allows the mechanic to throw batteries 30% farther", color);
                        PowerUpVars.GetComponent<PowerUpVariables>().PickedUp[Type] += 1;
                    }
                    break;
                case 12:
                    PowerUpVars.GetComponent<PowerUpVariables>().SubTotalDamageTakenMod += 0.1f;
                    color = Color.green;
                    if (PowerUpVars.GetComponent<PowerUpVariables>().PickedUp[Type] < 1)
                    {
                        PUI.DoPowerUpPopUp(GetComponent<SpriteRenderer>().sprite, "Titanium Gears", "Decreases damage taken by 10%", color);
                        PowerUpVars.GetComponent<PowerUpVariables>().PickedUp[Type] += 1;
                    }
                    break;
                case 13:
                    PowerUpVars.GetComponent<PowerUpVariables>().ClockPowerMod += 0.3f;
                    color = Color.green;
                    if (PowerUpVars.GetComponent<PowerUpVariables>().PickedUp[Type] < 1)
                    {
                        PUI.DoPowerUpPopUp(GetComponent<SpriteRenderer>().sprite, "Unlimited Unlimted Power", "Increase clock power by 30%", color);
                        PowerUpVars.GetComponent<PowerUpVariables>().PickedUp[Type] += 1;
                    }
                    break;
                case 14:
                    PowerUpVars.GetComponent<PowerUpVariables>().FullyRechargeChanceMod += 2;
                    color = new Color(128, 0, 128);
                    if (PowerUpVars.GetComponent<PowerUpVariables>().PickedUp[Type] < 1)
                    {
                        PUI.DoPowerUpPopUp(GetComponent<SpriteRenderer>().sprite, "Cosmic Rays", "There is an extremley low chance every second to fully reacharge the clock", color);
                        PowerUpVars.GetComponent<PowerUpVariables>().PickedUp[Type] += 1;
                    }
                    break;
            }
            GameObject.Find("PowerUpInvintory").GetComponent<PowerUpUi>().PickedUpPowerUp(GetComponent<SpriteRenderer>().sprite, color);   
            Destroy(gameObject);
        }
    }
}
