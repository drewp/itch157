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
    private GameObject PowerUpImage;
    private GameObject PowerUpInfo;
    private GameObject PowerUPPopUp;
    private GameObject PowerUpName;
    private bool DoingPopUp = false;
    private List<string> PopUpInfos = new List<string>();
    private List<Sprite> PopUpSprites = new List<Sprite>();
    private List<Color> PopUpColors = new List<Color>();
    private List<string> PopUpNames = new List<string>();
    void Start()
    {
        PowerUpImage = transform.Find("PowerUpPopUp").Find("PowerUpImage").gameObject;
        PowerUpInfo = transform.Find("PowerUpPopUp").Find("PowerUpInfo").gameObject;
        PowerUpName = transform.Find("PowerUpPopUp").Find("PowerUpName").gameObject;
        PowerUPPopUp = transform.Find("PowerUpPopUp").gameObject;

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (gameObject.transform.GetChild(i).gameObject.name != "PowerUpPopUp") { PowerUpHolders.Add(gameObject.transform.GetChild(i).gameObject); }
        }
        for (int i = 0; i < PowerUpHolders.Count; i++)
        {
            PowerUpHolders[i].SetActive(false);
        }
        

    }
    public void PickedUpPowerUp(Sprite sprite, Color TextColor)
    {
        int index = PowerUpSprites.IndexOf(sprite);
        if (index != -1)
        {
            PowerUpHolders[index].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = (Convert.ToInt32(PowerUpHolders[index].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text) + 1).ToString();
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

    void Update()
    {
        if (PopUpInfos.Count != 0 && !DoingPopUp)
        {
            PowerUpImage.GetComponent<Image>().sprite = PopUpSprites[0];
            PowerUpInfo.GetComponent<TextMeshProUGUI>().text = PopUpInfos[0];
            PowerUpInfo.GetComponent<TextMeshProUGUI>().color = PopUpColors[0];
            PowerUpName.GetComponent<TextMeshProUGUI>().text = PopUpNames[0];
            StartCoroutine(PopUpPopOut());
            PopUpColors.RemoveAt(0);
            PopUpInfos.RemoveAt(0);
            PopUpSprites.RemoveAt(0);
            PopUpNames.RemoveAt(0);
        }
    }



    public void DoPowerUpPopUp(Sprite Image,string name ,string description, Color TextColor)
    {
        PopUpSprites.Add(Image);
        PopUpInfos.Add(description); 
        PopUpColors.Add(TextColor);
        PopUpNames.Add(name);

    }

    IEnumerator PopUpPopOut()
    {
        DoingPopUp = true;
        for (int i = 0; i < 500; i++)
        {
            PowerUPPopUp.transform.position -= new Vector3(.6f,0,0);
            yield return new WaitForSeconds(.001f);
        }
        yield return new WaitForSeconds(5);
        for (int i = 0; i < 500; i++)
        {
            PowerUPPopUp.transform.position += new Vector3(.6f, 0, 0);
            yield return new WaitForSeconds(.001f);
        }
        DoingPopUp = false;
    }
}
