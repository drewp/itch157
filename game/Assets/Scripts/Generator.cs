using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public float Power = 10000;
    public float MaxPower = 10000;
    float ToRecharge = 0;
    float going = 0;
    public GameObject PowerUpObj;

    public AudioSource ClockSound;
    
    void Start()
    {
        PowerUpObj = GameObject.Find("PowerUpObject");
        Power = 10000;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var BaseMaxPower = 10000 * PowerUpObj.GetComponent<PowerUpVariables>().ClockPowerAddMod;
        MaxPower = BaseMaxPower * PowerUpObj.GetComponent<PowerUpVariables>().EnergyDrainMod;
        if (Power > MaxPower)
        {
            Power = MaxPower;
        }
        if(going <= 1)
        {
            going = 1;
            ToRecharge = 0;
            Power -= 1f;
        } else
        {
            Invoke("Charge", 0.1f);
        }
        if(Power <= 0)
        {
            Power = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Battery")
        {
            ToRecharge = collision.gameObject.GetComponent<BatteryScriptable>().PowerRefilled;
            going = 40;
            Destroy(collision.gameObject);
            ClockSound.Play();
        }
    }

    private void Charge()
    {
        Power += (ToRecharge/40);
        going--;
    }
}
