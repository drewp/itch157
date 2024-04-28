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

    public GameObject Camera;

    float RunTime = 1;
    int TimeRan = 1;

    float SAmount = 1.68f;
    public float ShakeAmount = .1f;
    public float ShakeTime = .2f;
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * runSpeed * RunTime;
        if(Mathf.Abs(rigidBody.velocity.magnitude)>=0.1f)
        {
            TimeRan++;
            if(TimeRan > 95)
            {
                RunTime += 0.005f;
                if(RunTime >= 2)
                {
                    InvokeRepeating("DoShake", 0, 0.01f);
                    RunTime = 2;
                }
            }
        } else
        {
            RunTime = 1;
            TimeRan = 0;
            CancelInvoke("DoShake");
        }
        Camera.GetComponent<Camera>().orthographicSize = 5.0f + rigidBody.velocity.magnitude/12;
    }
    void DoShake()
    {
        if (SAmount > 0)
        {
            Vector3 CamPos = Camera.GetComponent<Camera>().transform.position;

            float OffsetX = (Random.value * SAmount) * 2 - SAmount;
            float OffsetY = (Random.value * SAmount) * 2 - SAmount;
            CamPos.x += OffsetX;
            CamPos.y += OffsetY;

            Camera.GetComponent<Camera>().transform.position = CamPos;
        }
    }
}
