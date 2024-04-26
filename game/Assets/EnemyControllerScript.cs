using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerScript : MonoBehaviour
{
    public EnemyObject EnemyObject;
    private CircleCollider2D AgroCollider;
    private GameObject Player;
    private bool Agroed = false;
    private float Cooldown;
   



    void Start()
    {
        
        AgroCollider = GetComponent<CircleCollider2D>();
        AgroCollider.radius = EnemyObject.agroDst * 2f;
        Player = GameObject.Find("Player");

    }

    void Update()
    {
        if (Agroed) EnemyObject.DoAgro(gameObject, Player);
        float Dst = Vector3.Distance(transform.position, Player.transform.position);
        if (Dst <= EnemyObject.AttackRange && Cooldown >= EnemyObject.AttackCooldown)
        {
            EnemyObject.DoAttack(gameObject, Player);
            Cooldown = 0;
        }
        Cooldown += Time.deltaTime;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Agroed = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Agroed = false;
        }
    }

   
}
