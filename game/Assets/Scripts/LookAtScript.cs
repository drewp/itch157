using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtScript : MonoBehaviour
{
    public GameObject LookAtObject;
    
    void Update()
    {
        var dir = LookAtObject.transform.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg-90f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
