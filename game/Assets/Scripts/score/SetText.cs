using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI tmp;
    private void Start()
    {
        Debug.Log(staticscore.score);
        Debug.Log("hi");
        float score = staticscore.score;
        tmp.text = "you lasted " + score.ToString() + " seconds" ;
    }
}
