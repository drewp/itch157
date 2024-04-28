using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryScriptable : MonoBehaviour
{
    public int PowerRefilled;
    public float TimeToRefill;
    public float Weight;

    public GameObject PowerUpVars;

    void Start()
    {
        PowerUpVars = GameObject.Find("PowerUpObject");
        float min = 500 * PowerUpVars.GetComponent<PowerUpVariables>().BatteryRechargeMod;
        float max = 2000 * PowerUpVars.GetComponent<PowerUpVariables>().BatteryRechargeMod;
        PowerRefilled = Random.Range((int)min, (int)max);
    }
    void Update()
    {
        
    }
}
