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
    // Start is called before the first frame update
    void Start()
    {
        
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
            Invoke("swing", 0.3f);
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
