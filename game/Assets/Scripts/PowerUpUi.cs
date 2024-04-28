using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpUi : MonoBehaviour
{
    private List<Sprite> PowerUpSprites;
    private List<GameObject> PowerUpHolders = new List<GameObject>();
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
    public void PickedUpPowerUp(Sprite sprite)
    {
        int index = PowerUpSprites.IndexOf(sprite);
        Debug.Log(index);
        
    } 
}
