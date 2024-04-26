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
        Generator Gen = this.GetComponentInParent<Generator>();
        transform.localScale = new Vector3(ObjScale * (Gen.Power/Gen.MaxPower), transform.localScale.y, transform.localScale.z);
    }
}
