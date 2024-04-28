using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    //Line
    [SerializeField]
    private Rigidbody2D rigidBody;
    [SerializeField]
    private float runSpeed = 10.0f;
    public GameObject PowerUpScript;

    public AudioSource Step;

    bool walking = false;

    public

    void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * runSpeed;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) && walking == false)
        {
            Step.Play();
        } else
        {
            Step.Stop();
            walking = false;
        }
    }
}
