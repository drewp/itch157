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
     GameObject PowerUpScript;

    public GameObject Camera;


    float RunTime = 1;
    int TimeRan = 1;

    float SAmount = 0.01f;
    public float ShakeAmount = .1f;
    public float ShakeTime = .2f;
    bool rep = false;
    void Start()
    {
        PowerUpScript = GameObject.Find("PowerUpObject");
    }
    void FixedUpdate()
    {
        if (GetComponent<batt_pickup>().holding == true)
        {
            rigidBody.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * runSpeed * RunTime * PowerUpScript.GetComponent<PowerUpVariables>().MovementSpeedMod * PowerUpScript.GetComponent<PowerUpVariables>().BatteryCarrySpeedMod;
        } else
        {
            rigidBody.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * runSpeed * RunTime * PowerUpScript.GetComponent<PowerUpVariables>().MovementSpeedMod;
        }
        if(Mathf.Abs(rigidBody.velocity.magnitude)>=0.1f)
        {
            TimeRan++;
            if (TimeRan > 95)
            {
                RunTime += 0.005f;
                if (RunTime >= 0.1f)
                {
                    SAmount = 0.01f + RunTime / 50;
                    if (rep == false)
                    {
                        //InvokeRepeating("DoShake", 0, 0.01f);
                        rep = true;
                    }
                }
                if (RunTime >= 2)
                {
                    RunTime = 2;
                }
            }
        } else
        {
            Invoke("Stop", 2.0f);
        }
        //if (TimeRan >= 50)
        //{
        //    Camera.GetComponent<Camera>().orthographicSize = 5.0f + rigidBody.velocity.magnitude / 20;
        //    if (Camera.GetComponent<Camera>().orthographicSize >= 6.0f)
        //    {
        //        Camera.GetComponent<Camera>().orthographicSize = 6;
        //    }
        //}
    }
    //void DoShake()
    //{
    //    if (SAmount > 0)
    //    {
    //        Vector3 CamPos = Camera.GetComponent<Camera>().transform.position;

    //        float OffsetX = (Random.value * SAmount);
    //        float OffsetY = (Random.value * SAmount);
    //        CamPos.x += OffsetX;
    //        CamPos.y += OffsetY;

    //        Camera.GetComponent<Camera>().transform.position = CamPos;
    //    }
    //}
    void Stop()
    {
        if (Mathf.Abs(rigidBody.velocity.magnitude) !>= 0.1f)
        {
            rep = false;
            RunTime = 1;
            TimeRan = 0;
            //CancelInvoke("DoShake");
        }
    }
}
