using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpUi : MonoBehaviour
{
    public List<Sprite> PowerUpSprites;
    public GameObject SpriteBoxHolder;
    public int BoxesPerRow;
    private float BoxHeight;
    private float BoxWidth;
    void Start()
    {
        SpriteBoxHolder.SetActive(false);
        BoxWidth = SpriteBoxHolder.GetComponent<RectTransform>().sizeDelta.x;
        BoxHeight = SpriteBoxHolder.GetComponent<RectTransform>().sizeDelta.y;

        float x = -130f;
        float y = 30f;
        for (int i = 0; i < PowerUpSprites.Count; i++)
        {
         
            for (int j = 0; j < BoxesPerRow; j++)
            {
                GameObject NewBox =  Instantiate(SpriteBoxHolder);
                NewBox.transform.SetParent(transform);
                NewBox.transform.position = new Vector3(x, y, 0);
                NewBox.SetActive(true);

                x += BoxWidth + 5f;
            }
            y += BoxHeight + 5f;
            x = -130;
        }
    }
}
