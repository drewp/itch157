using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerhealth : MonoBehaviour
{
    private float Healthbar = 50;
    [SerializeField]
    private Image hpbarImg;
    public void TakeDamage(float damage)
    {
        Debug.Log("Takedamage");
        Healthbar -= damage;
    }

    private void FixedUpdate()
    {
        //Healthbar += 0.05f;
    }
    private void Update()
    {
        hpbarImg.fillAmount = Healthbar/50f;
        Debug.Log(hpbarImg.fillAmount);
        if (Healthbar == 0)
        {
            SceneManager.LoadScene("death_menu");
        }
    }
}
