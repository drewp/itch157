using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    public static float ObjScale;
    void Start()
    {
        ObjScale = transform.localScale.x;
    }
    void Update()
    {
        transform.localScale = new Vector3(ObjScale * (Generator.Power/ Generator.MaxPower), transform.localScale.y, transform.localScale.z);
    }
}
