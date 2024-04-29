using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [HideInInspector] public GameObject target;
    [HideInInspector] public float Damage;
    [HideInInspector] public float Range;
    [HideInInspector] public Vector3 StartPos;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == target.tag)
        {
            playerhealth HealthScript = other.GetComponent<playerhealth>();
            if (HealthScript != null) HealthScript.TakeDamage(Damage);
            
        }
    }
    void Update()
    {
        if (Vector3.Distance(StartPos,transform.position)>Range)
        {
            
            Destroy(gameObject);
        }
    }
   
}
