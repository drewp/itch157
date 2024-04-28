using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Power : MonoBehaviour
{
    [SerializeField]
    private Image powerbar;
    private float current_power = 1;
    [SerializeField]
    private Generator gen;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        current_power = gen.Power / gen.MaxPower;
        powerbar.fillAmount = current_power;
        if(current_power == 0)
        {
            SceneManager.LoadScene("death_menu");
        }
    }
}
