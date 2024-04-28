using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class robot_anim : MonoBehaviour
{
    [SerializeField]
    private Animator anm;
    [SerializeField]
    private Rigidbody2D rb;
    public EnemyControllerScript ControllScript;
    private bool dying = false;
    private void Update()
    {
        if (!ControllScript.IsAttacking && !dying)
        {

            anm.SetBool("isAttacking", false);

            if (rb.velocity.x < 0.5 && rb.velocity.x > -0.5 && rb.velocity.y < 0.5 && rb.velocity.y > -0.5)
            {
                anm.SetBool("isWalking", false);
                anm.SetBool("isIdle", true);
                anm.SetBool("isAttacking", false);


            }
            else
            {
                anm.SetBool("isWalking", true);
                anm.SetBool("isIdle", false);
                anm.SetBool("isAttacking", false);

            }
        }
        else if (!dying)
        {
            anm.SetBool("isWalking", false);
            anm.SetBool("isIdle", false);
            anm.SetBool("isAttacking",true);
        }
        
    }
    public void deathanim()
    {
        Debug.Log("die");
        dying = true;
        anm.SetBool("isAttacking", false);
        anm.SetBool("isWalking", false);
        anm.SetBool("isIdle", false);
        anm.SetBool("isDead", true);
    }
}
