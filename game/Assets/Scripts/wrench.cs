using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrench : MonoBehaviour
{
    private bool lethal = false;
    [SerializeField]
    private Animator anm;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void swing()
    {
        lethal = false;
        anm.SetBool("isIdle", true);
        anm.SetBool("isSwinging", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            lethal = true;
            anm.SetBool("isIdle", false);
            anm.SetBool("isSwinging", true);
            Invoke("swing", 2.0f);

        }
    }
}
