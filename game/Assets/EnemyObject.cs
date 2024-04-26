using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/EnemyOject", order = 1)]
public class EnemyObject : ScriptableObject
{
    public float agroDst;
    public float Dmg;
    public float Speed;
    public float AttackSpeed;

    public enum AgroMode {Basic};
    public AgroMode Agro;

    private void BasicAgro(GameObject Enemy,GameObject target)
    {
       Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position,target.transform.position,Speed*Time.deltaTime);
    }

    public void DoAgro(GameObject Enemy,GameObject target)
    {
        if (Agro == AgroMode.Basic) BasicAgro(Enemy,target);
    }
}
