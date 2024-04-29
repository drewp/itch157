using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowUpScript : MonoBehaviour
{
    [SerializeField]
    private Animator anm;
    private bool BlowingUp;
    public void BlowUp(GameObject target)
    {
        anm.SetBool("BlowUp", true);
    }
}
