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
    private Vector3 WanderPoint;
    private float WanderCooldown;
    private float WanderWait = 2.5f;
   



    void Start()
    {
        
        AgroCollider = GetComponent<CircleCollider2D>();
        AgroCollider.radius = EnemyObject.agroDst * 2f;
        Player = GameObject.Find("Player");

    }

    void Update()
    {
        if (Agroed)
        {
            WanderPoint = new Vector3(0,0,0);
            WanderCooldown = 0f;
            EnemyObject.DoAgro(gameObject, Player);
            float Dst = Vector3.Distance(transform.position, Player.transform.position);
            if (Dst <= EnemyObject.AttackRange && Cooldown >= EnemyObject.AttackCooldown)
            {
                EnemyObject.DoAttack(gameObject, Player);
                Cooldown = 0;
            }
            Cooldown += Time.deltaTime;
        }
        else
        {
            Cooldown = 0f;
           
            Wander();
        }
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

    public void Wander()
    {
        if (WanderPoint == new Vector3(0,0,0))
        {
            WanderPoint = transform.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, WanderPoint, EnemyObject.Speed/2f * Time.deltaTime);
        if (Vector3.Distance(transform.position, WanderPoint) < 1f)
        {
            WanderCooldown += Time.deltaTime;

            if (WanderCooldown > WanderWait)
            {
                WanderPoint = new Vector3(Random.Range(-EnemyObject.WanderRange, EnemyObject.WanderRange), Random.Range(-EnemyObject.WanderRange, EnemyObject.WanderRange), 0f);
                WanderWait = Random.Range(1f, 3f);
                WanderCooldown = 0f;
            }
        }
      
    }

   
}
