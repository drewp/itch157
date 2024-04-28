using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpVariables : MonoBehaviour
{
    public float EnergyDrainMod; // Speed Of Light -1
    public float ClockSpeedMod; // Speed Of Light +1
    public float AttackSpeedMod; // Degreased Fingers
    public float HealthAddMod; // Steel Gears
    public float BatteryDropChanceMod; // Delicate Fingers
    public float BatteryRechargeMod; // Bigger Batteries
    public float ClockPowerAddMod; // Unlimited Power
    public float DamageMod; // Steroids
    public float MovementSpeedMod; // Fast Feet

    public float BatteryCarrySpeedMod; // Creatine
    public float BatteryThrowingDistanceAddMod; // Thor
    public float EnemyExplosionChance; // Greasy Gears
    public float SubTotalDamageTakenMod; // Titanium Gears
    public float ClockPowerMod; // Clock Power
    public float ImmunityFramesAddMod; // Ninja

    public float BatteryExplosionChance; // Chemical Warfare
    public float BatteryHitMoveMod; // Baseball
    public float FullyRechargeChanceMod; // Cosmic Rays

    public bool MechanicsGambit;
    public bool ImHungry;

    [SerializeField]
    private List<GameObject> CommonPowerups;
    public List<GameObject> UncommonPowerups;
    public List<GameObject> RarePowerups;
    public List<GameObject> LegendaryPowerups;

    public int[] PickedUp = new int[17];

    void Start()
    {
        for (int i = 0; i < 16; i++)
        {
            PickedUp[i] = 0;
        }
    }
    void Update()
    {
        
    }

    int DropChance()
    {
        var Chance = Random.Range(0, 100);
        if (Chance <= 150)
        {
            if (Chance <= 5)
            {
                if(Chance <= 2)
                {
                    if (Chance <= 1)
                    {
                        return 4;
                    }
                    return 3;
                }
                return 2;
            }
            return 1;
        }
        return 0;
    }
    public GameObject OnDrop()
    {
        int D = DropChance();
        if (D == 0)
        {
            return null;
        }
        //Debug.Log(CommonPowerups.Count);
        Debug.Log(UncommonPowerups.Count);
        switch (D)
        {
            case 1:
                return CommonPowerups[Random.Range(0, CommonPowerups.Count)];
            case 2:
                return UncommonPowerups[Random.Range(0, UncommonPowerups.Count)];
            case 3:
                return RarePowerups[Random.Range(0, RarePowerups.Count)];
            case 4:
                return LegendaryPowerups[Random.Range(0, LegendaryPowerups.Count)];
        }
        return null;
    }
}
