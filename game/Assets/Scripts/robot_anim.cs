using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robot_anim : MonoBehaviour
{
    [SerializeField]
    private Animator anm;
    [SerializeField]
    private Rigidbody2D rb;
    private void Update()
    {
        if (rb.velocity.x != 0 || rb.velocity.y != 0)
        {
            anm.SetBool("isWalking", true);
            anm.SetBool("isIdle", false);

        }
        else if (rb.velocity.x == 0 && rb.velocity.y == 0)
        {
            anm.SetBool("isWalking", false);
            anm.SetBool("isIdle", true);
        }
    }
}
