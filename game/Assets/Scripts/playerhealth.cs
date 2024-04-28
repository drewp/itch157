using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerhealth : MonoBehaviour
{
    private float Healthbar = 30;
    public float MaxHealth = 30;
    [SerializeField]
    private Image hpbarImg;

    public GameObject PowerUpVars;
    public AudioSource PlayerDamage;
    private void Start()
    {
        PowerUpVars = GameObject.Find("PowerUpObject");
        PlayerDamage = GameObject.Find("PlayerHurt").GetComponent<AudioSource>();
    }
    public void TakeDamage(float damage)
    {
        PlayerDamage.Play();
        Healthbar -= damage - PowerUpVars.GetComponent<PowerUpVariables>().SubTotalDamageTakenMod;
    }

    private void FixedUpdate()
    {
        MaxHealth = 30 * PowerUpVars.GetComponent<PowerUpVariables>().HealthAddMod;
        Healthbar += 0.005f;
        if (Healthbar >= MaxHealth)
        {
            Healthbar = MaxHealth;
        }
    }
    private void Update()
    {
        hpbarImg.fillAmount = Healthbar/MaxHealth;
        
        if (Healthbar < 0.2)
        {
            staticscore.score = Timer.setTime;
            SceneManager.LoadScene("death_menu");
        }
    }
}
