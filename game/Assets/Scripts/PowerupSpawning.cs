using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawning : MonoBehaviour
{
    
    [SerializeField]
    private float width = 40f;
    [SerializeField]
    private float height = 40f;
    [SerializeField]
    private int min = 3;
    [SerializeField]
    private int max = 15;
    GameObject PowerUpVars;
    // Start is called before the first frame update
    void Start()
    {
        PowerUpVars = GameObject.Find("PowerUpObject");
        int amount = Random.Range(min, max);
        for (int i = 0; i < amount; i++)
        {
            float xcord = Random.Range(-width, width);
            float ycord = Random.Range(-height, height);
            GameObject PPowerup = PowerUpVars.GetComponent<PowerUpVariables>().OnDrop();
            if (PPowerup != null && Random.Range(1, 7) == Random.Range(1, 10))
            {
                GameObject Temp = Instantiate(PPowerup);
                Temp.transform.position = new Vector2(xcord, ycord);
            }
        }
    }

}
