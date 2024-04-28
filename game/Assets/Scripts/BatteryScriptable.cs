using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryScriptable : MonoBehaviour
{
    public int PowerRefilled;
    public float TimeToRefill;
    public float Weight;

    void Start()
    {
        PowerRefilled = Random.Range(1000, 3000);
    }
    void Update()
    {
        
    }
}
