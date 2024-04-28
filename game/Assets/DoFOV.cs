using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoFOV : MonoBehaviour
{
    public Rigidbody2D PlayerRigidBody;
    float length = 0;
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        Debug.Log(gameObject.GetComponent<Camera>().orthographicSize);
        if (Mathf.Abs(PlayerRigidBody.velocity.magnitude) >= 0)
        {
            length += 0.01f;
            if(length >= 1)
            {
                length = 1;
            }
            GetComponent<Camera>().orthographicSize = 5.0f + length;
        } else
        {
            GetComponent<Camera>().orthographicSize = 5f;
            length = 0;
        }
    }
}
