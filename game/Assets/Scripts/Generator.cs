using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public float Power = 1000;
    public float MaxPower = 1000;
    float ToRecharge = 0;
    float Decay = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Power += ToRecharge;
        ToRecharge -= Decay;
        if(ToRecharge <= 0)
        {
            Decay = 0;
            ToRecharge = 0;
        }
        Power -= 1f;
        if(Power <= 0)
        {
            Power = 0;
        }
    }

    private void OnTriggerEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Battery")
        {
            Debug.Log(collision.gameObject.tag);
            ToRecharge = collision.gameObject.GetComponent<BatteryScriptable>().PowerRefilled;
            Decay = collision.gameObject.GetComponent<BatteryScriptable>().TimeToRefill;
            Destroy(collision.gameObject);
        }
    }
}
