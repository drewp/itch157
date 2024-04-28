using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/EnemyOject", order = 1)]
public class EnemyObject : ScriptableObject
{
    public float Health;
    public float agroDst;
    public float Dmg;
    public float Speed;
    public float AttackCooldown;
    public float AttackRange;
    public float WanderRange;
    public bool AffectedByBattery = true;
    [HideInInspector] public float SpeedMult = 10f;
    public GameObject Projectile;
    public float ProjectileForce;
    public enum AgroMode {Basic};
    public AgroMode Agro;

    public enum AttackMode { Basic, Projectile };
    public AttackMode Attack;





    private void BasicAgro(GameObject Enemy, GameObject target, float Dst)
    {
        if (Dst > AttackRange)
        {
            Vector3 dir = target.transform.position - Enemy.transform.position;
            dir = dir.normalized;
            Enemy.GetComponent<EnemyControllerScript>().AddForce(Speed * SpeedMult * Time.deltaTime,dir);

        }
    }

    public void DoAgro(GameObject Enemy,GameObject target,float Dst)
    {
        if (Agro == AgroMode.Basic) BasicAgro(Enemy,target,Dst);
    }


    private void BasicAttack(GameObject Enemy, GameObject target)
    {
        
        playerhealth HealthScript = target.GetComponent<playerhealth>();
        if (HealthScript != null ) HealthScript.TakeDamage(Dmg);
        
    }

    private void ProjectileAttack(GameObject Enemy, GameObject target)
    {
        Vector3 dir = target.transform.position - Enemy.transform.position;
        dir = dir.normalized;
        GameObject NewProj =  Instantiate(Projectile);
        NewProj.GetComponent<ProjectileScript>().target = target;
        NewProj.GetComponent<ProjectileScript>().Damage = Dmg;
        NewProj.GetComponent<Rigidbody>().AddForce(ProjectileForce*100f*dir);
    }
  

    public void DoAttack(GameObject Enemy, GameObject target)
    {
        if (Attack == AttackMode.Basic) BasicAttack(Enemy, target);
        if (Attack == AttackMode.Projectile) BasicAttack(Enemy, target);
    }




}
