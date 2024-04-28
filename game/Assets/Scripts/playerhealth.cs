using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerhealth : MonoBehaviour
{
    private float Healthbar = 30;
    [SerializeField]
    private Image hpbarImg;
    public void TakeDamage(float damage)
    {
        
        Healthbar -= damage;
    }

    private void FixedUpdate()
    {
        Healthbar += 0.005f;
    }
    private void Update()
    {
        hpbarImg.fillAmount = Healthbar/30f;
        
        if (Healthbar < 0.2)
        {
            SceneManager.LoadScene("death_menu");
        }
    }
}
