using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class Timer : MonoBehaviour
{
    private int setTime = 0;
    [SerializeField]
    private TextMeshProUGUI tmp;
    // Start is called before the first frame update
    void Start()
    {
        tick();
    }
    private void tick()
    {
        setTime++;
        tmp.text = setTime.ToString();
        Invoke("tick", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
