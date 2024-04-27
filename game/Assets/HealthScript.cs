using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float Health;

    public void TakeDamage(float Damage)
    {
        Health -= Damage;
    }
}
