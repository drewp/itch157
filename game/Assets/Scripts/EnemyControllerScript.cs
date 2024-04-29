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
    private float WanderCooldown = 5f;
    private float WanderWait = 0;
    private Collider2D Collider;
    private Collider2D PlayerCollider;
    private Rigidbody2D rb;
    private float Health;
    private float StartHealth;
    private SpriteRenderer SpriteRender;
    [HideInInspector] public bool IsAttacking;
    public GameObject Battery;
    public AudioSource RoboSound;
    public AudioSource RoboHitSound;
    private ParticleSystem BloodParticles;
    private bool FacingRight = true;
    [SerializeField]
    robot_anim ranm;

    GameObject PowerUpVars;
    public AudioSource DeathSound;
    public AudioSource SwingSound;
    public AudioSource RobotSmashSound;


    void Start()
    {
        DeathSound = GameObject.Find("WhenKilledAudio").GetComponent<AudioSource>();
        SwingSound = GameObject.Find("SwingAudio").GetComponent<AudioSource>();
        RobotSmashSound = GameObject.Find("RobotSmash").GetComponent<AudioSource>();
        BloodParticles = transform.Find("ParticleSystem").gameObject.GetComponent<ParticleSystem>();
        BloodParticles.Stop();
        WanderPoint = new Vector3(0, 0, 0);
        StartHealth = Health;
        Player = GameObject.Find("mechanic_fella");
        rb = GetComponent<Rigidbody2D>();
        Collider = GetComponent<BoxCollider2D>();
        PlayerCollider = Player.transform.Find("collider").gameObject.GetComponent<BoxCollider2D>();
        SpriteRender = GetComponent<SpriteRenderer>();
        Health = EnemyObject.Health;
        PowerUpVars = GameObject.Find("PowerUpObject");        
    }

    void FixedUpdate()
    {
        Vector3 MyClosestPoint = Collider.ClosestPoint(Player.transform.position);
        Vector3 PlayerClosestPoint = PlayerCollider.ClosestPoint(MyClosestPoint);
        float Dst = Vector3.Distance(MyClosestPoint, PlayerClosestPoint);

        
        int RS = Random.Range(0, 1500);
        if (RS == 10&& Dst < 30) RoboSound.Play();
    }
    void death()
    {
        int RS = Random.Range(0, 500);
        if (RS <= 33 + PowerUpVars.GetComponent<PowerUpVariables>().BatteryDropChanceMod)
        {
            GameObject NewBat = Instantiate(Battery);
            NewBat.transform.position = transform.position;
        }
        GameObject PPowerup = PowerUpVars.GetComponent<PowerUpVariables>().OnDrop();
        if (PPowerup != null && Random.Range(1, 7) == Random.Range(1, 10))
        {
            GameObject Temp = Instantiate(PPowerup);
            Temp.transform.position = transform.position;
        }
        Destroy(gameObject);
    }
    void Update()
    {
        Vector3 dir = Player.transform.position - transform.position;
        dir = dir.normalized;
        Vector3 newScale = transform.localScale;
        float flip = 1f;

        if ((dir.x < 0 && FacingRight) || (dir.x > 0 && !FacingRight))
        {
            flip = -1f;
            FacingRight = !FacingRight;
        }
        newScale.x *= flip;
        transform.localScale = newScale;

        if (Health <= 0)
        {
            
            DeathSound.Play();
            IsAttacking = false;
            ranm.deathanim();
            Invoke("death", 0.75f);
        }
            
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
            if (Dst <= EnemyObject.AttackRange && Cooldown >= EnemyObject.AttackCooldown&& !IsAttacking)
            {
                IsAttacking = true;
                Invoke("AttackOver", .54f);
                Invoke("DoDoAttack",.27f);
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

    private void DoDoAttack()
    {
        SwingSound.Play();
        RobotSmashSound.Play();
        EnemyObject.DoAttack(gameObject, Player);

    }
    private void AttackOver()
    {
        IsAttacking = false;
        Cooldown = 0;

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

                WanderPoint = new Vector3(Random.Range(transform.position.x-EnemyObject.WanderRange, transform.position.x+EnemyObject.WanderRange), Random.Range(transform.position.y - EnemyObject.WanderRange, transform.position.y+EnemyObject.WanderRange), 0f);
                WanderWait = Random.Range(1f, 3f);
                WanderCooldown = 0f;
            }
        }
      
    }

    public void TakeDamage(float Dmg,float Knockback)
    {
        BloodParticles.Play();
        RoboHitSound.Play();
        Health -= Dmg*PowerUpVars.GetComponent<PowerUpVariables>().DamageMod;
        if (Health <= StartHealth / 2f)  rb.velocity = new Vector3(0f, 0f, 0f);
        Vector3 dir = Player.transform.position - transform.position;
        dir = dir.normalized;
        rb.AddForce(-dir * Knockback*100f);
    }

    public void AddForce(float force,Vector3 dir)
    {

        rb.AddForce(force*dir);
        
        

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Battery" && other.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude>.1f && EnemyObject.AffectedByBattery)
        {
            DeathSound.Play();
            Destroy(other.gameObject);
            Invoke("death", 0.75f);
        }
    }

   
}
