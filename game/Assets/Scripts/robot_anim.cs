using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robot_anim : MonoBehaviour
{
    public static Animator anm;
    [SerializeField]
    private Rigidbody2D rb;
    public EnemyControllerScript ControllScript;

    private void Update()
    {
        if (!ControllScript.IsAttacking)
        {

            anm.SetBool("isAttacking", false);

            if (rb.velocity.x < 0.5 && rb.velocity.x > -0.5 && rb.velocity.y < 0.5 && rb.velocity.y > -0.5)
            {
                anm.SetBool("isWalking", false);
                anm.SetBool("isIdle", true);


            }
            else
            {
                anm.SetBool("isWalking", true);
                anm.SetBool("isIdle", false);

            }
        }
        else
        {
            anm.SetBool("isWalking", false);
            anm.SetBool("isIdle", false);
            anm.SetBool("isAttacking",true);
        }
    }
}
