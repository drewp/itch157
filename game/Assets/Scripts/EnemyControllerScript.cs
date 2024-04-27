using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerScript : MonoBehaviour
{
    public EnemyObject EnemyObject;
    private GameObject Player;
    private bool Agroed = false;
    private float Cooldown;
    private Vector3 WanderPoint;
    private float WanderCooldown;
    private float WanderWait = 2.5f;
    private Collider2D Collider;
    private Collider2D PlayerCollider;
    private Rigidbody2D rb;
    private float Health;
    private float StartHealth;
    private SpriteRenderer SpriteRender;
    [HideInInspector] public bool IsAttacking;




    void Start()
    {
        StartHealth = Health;
        Player = GameObject.Find("mechanic_fella");
        rb = GetComponent<Rigidbody2D>();
        Collider = GetComponent<BoxCollider2D>();
        PlayerCollider = Player.transform.Find("collider").gameObject.GetComponent<BoxCollider2D>();
        SpriteRender = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 MyClosestPoint = Collider.ClosestPoint(Player.transform.position);
        Vector3 PlayerClosestPoint = PlayerCollider.ClosestPoint(MyClosestPoint);
         
        
        
        float Dst = Vector3.Distance(MyClosestPoint,PlayerClosestPoint) ;
       
        
        Agroed = false;
        if (Dst<EnemyObject.agroDst) Agroed = true;

        if (Agroed)
        {
            WanderPoint = new Vector3(0,0,0);
            WanderCooldown = 0f;
            EnemyObject.DoAgro(gameObject, Player,Dst);
            if (Dst <= EnemyObject.AttackRange && Cooldown >= EnemyObject.AttackCooldown)
            {
                IsAttacking = true;
                Invoke("AttackOver", .4f);
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


    private void AttackOver()
    {
        IsAttacking = false;
    }
   

    public void Wander()
    {
        if (WanderPoint == new Vector3(0,0,0))
        {
            WanderPoint = transform.position;
        }
        Vector3 dir = WanderPoint - transform.position;
        dir = dir.normalized;
        AddForce(EnemyObject.Speed/Random.Range(1.7f,4f)*EnemyObject.SpeedMult * Time.deltaTime,dir);
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

    public void TakeDamage(float Dmg,float Knockback)
    {
        Health -= Dmg;
        if (Health <= StartHealth / 2f)  rb.velocity = new Vector3(0f, 0f, 0f);
        Vector3 dir = Player.transform.position - transform.position;
        dir = dir.normalized;
        rb.AddForce(-dir * Knockback*100f);
    }

    public void AddForce(float force,Vector3 dir)
    {
        rb.AddForce(force*dir);
        if (dir.x < 0) SpriteRender.flipX =true;
        else  SpriteRender.flipX = false;
    }

   
}
