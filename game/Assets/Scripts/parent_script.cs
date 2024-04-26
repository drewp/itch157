using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parent_script : MonoBehaviour
{
    [SerializeField]
    private GameObject parent;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(parent.transform.position.x, parent.transform.position.y, transform.position.z);
    }
}
