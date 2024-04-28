using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class setText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI tmp;
    // Start is called before the first frame update
    void Start()
    {
        tmp.text = "you lasted " + staticscore.score.ToString() + " seconds!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
