using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class PowerUpUi : MonoBehaviour
{
    private List<Sprite> PowerUpSprites;
    private List<GameObject> PowerUpHolders = new List<GameObject>();
    public Sprite testSprite;
    void Start()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            PowerUpHolders.Add(gameObject.transform.GetChild(i).gameObject); 
        }
        for (int i = 0;i < PowerUpHolders.Count; i++)
        {
            PowerUpHolders[i].SetActive(false);
        }
        PickedUpPowerUp(testSprite);
            
    }
    public void PickedUpPowerUp(Sprite sprite)
    {
        int index = PowerUpSprites.IndexOf(sprite);
        if (index!=-1)
        {
            PowerUpHolders[index].transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = (Convert.ToInt32(PowerUpHolders[index].transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text)+1 ).ToString();
        }
        else
        {
            PowerUpSprites.Add(sprite);
            PowerUpHolders[index].GetComponent<SpriteRenderer>().sprite = sprite;
            PowerUpHolders[index].transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = (Convert.ToInt32(PowerUpHolders[index].transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text) + 1).ToString();

        }

    } 
}
