using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;


public class PowerUpUi : MonoBehaviour
{
    private List<Sprite> PowerUpSprites = new List<Sprite>();
    private List<GameObject> PowerUpHolders = new List<GameObject>();
    private int PlaceInHolderOn = 0;
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

    }
    public void PickedUpPowerUp(Sprite sprite,Color TextColor)
    {
        Debug.Log(sprite);
        int index = PowerUpSprites.IndexOf(sprite);
        if (index!=-1)
        {
            PowerUpHolders[index].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = (Convert.ToInt32(PowerUpHolders[index].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text)+1 ).ToString();
        }
        else
        {
            PowerUpSprites.Add(sprite);
            PowerUpHolders[PlaceInHolderOn].GetComponent<Image>().sprite = sprite;
            PowerUpHolders[PlaceInHolderOn].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "1";
            PowerUpHolders[PlaceInHolderOn].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = TextColor;
            PowerUpHolders[PlaceInHolderOn].SetActive(true);
            PlaceInHolderOn++;
        }

    } 
}
