using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_animations : MonoBehaviour
{
    private bool facingright = true;
    [SerializeField]
    private SpriteRenderer sr;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Animator anm;
    // Start is called before the first frame update
    void Start()
    {
        anm = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
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
        if (Input.GetKeyDown(KeyCode.D))
        {
            facingright = true;
            sr.flipX = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            facingright = false;
            sr.flipX = true;
        }
    }
}
