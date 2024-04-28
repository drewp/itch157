using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class Timer : MonoBehaviour
{
    public static int setTime = 0;
    [SerializeField]
    private TextMeshProUGUI tmp;
    public GameObject PowerUpObj;
    // Start is called before the first frame update
    void Start()
    {
        setTime = 0;
        PowerUpObj = GameObject.Find("PowerUpObject");
        tick();
    }
    private void tick()
    {
        setTime++;
        tmp.text = setTime.ToString();
        Invoke("tick", 2 - PowerUpObj.GetComponent<PowerUpVariables>().ClockSpeedMod);
    }

    void Update()
    {
        
    }
}
