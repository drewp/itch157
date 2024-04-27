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
    [HideInInspector] public float SpeedMult = 10f;

    public enum AgroMode {Basic};
    public AgroMode Agro;

    public enum AttackMode { Basic };
    public AttackMode Attack;



    private void BasicAgro(GameObject Enemy, GameObject target, float Dst)
    {
        if (Dst > AttackRange)
        {
            Vector3 dir = target.transform.position - Enemy.transform.position;
            dir = dir.normalized;
            Enemy.GetComponent<Rigidbody2D>().AddForce(dir * Speed*SpeedMult * Time.deltaTime);

        }
    }

    public void DoAgro(GameObject Enemy,GameObject target,float Dst)
    {
        if (Agro == AgroMode.Basic) BasicAgro(Enemy,target,Dst);
    }


    private void BasicAttack(GameObject Enemy, GameObject target)
    {
        HealthScript HealthScript = target.GetComponent<HealthScript>();
        if (HealthScript != null ) HealthScript.TakeDamage(Dmg);
        
    }
  

    public void DoAttack(GameObject Enemy, GameObject target)
    {
        if (Attack == AttackMode.Basic) BasicAttack(Enemy, target);
    }




}
