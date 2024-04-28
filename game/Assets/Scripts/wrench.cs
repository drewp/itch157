using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrench : MonoBehaviour
{
    private bool lethal = false;
    [SerializeField]
    private Animator anm;
    [SerializeField]
    private batt_pickup bp;

    public AudioSource SwingSound;

    bool Swinging = false;

    public GameObject PowerUpVars;
    // Start is called before the first frame update
    void Start()
    {
        PowerUpVars = GameObject.Find("PowerUpObject");
    }
    private void swing()
    {
        anm.SetBool("isIdle", true);
        anm.SetBool("isSwinging", false);
        lethal = false;
        Swinging = false;
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Swinging == false)
        {
            lethal = true;
            anm.SetBool("isIdle", false);
            anm.SetBool("isSwinging", true);
            SwingSound.Play();
            Invoke("swing", 0.3f - PowerUpVars.GetComponent<PowerUpVariables>().AttackSpeedMod/10);
            Swinging = true;
        }
        if (bp.holding == true)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "Enemy" && lethal)
        {
            other.gameObject.GetComponent<EnemyControllerScript>().TakeDamage(10f, 20f);
            lethal = false;
        }
    }
}
