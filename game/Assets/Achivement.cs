using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achivment : MonoBehaviour
{
    public GameObject CanvasThing;
    public List<Sprite> AchPics;

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    void CallAchievement(int type)
    {
        PowerUpUi PUI = GameObject.Find("PowerUpInvintory").GetComponent<PowerUpUi>();
        switch (type){
            case 1:
                PUI.DoAchUpPopUp(AchPics[type-1], "100%", "You got every Aachievement");
                break;
            case 2:
                PUI.DoAchUpPopUp(AchPics[type - 1], "beast", "Kill 30 elite enemies");
                break;
            case 3:
                PUI.DoAchUpPopUp(AchPics[type - 1], "Bot Bath", "Kill 100 Bots");
                break;
            case 4:
                PUI.DoAchUpPopUp(AchPics[type - 1], "Collector", "Get Every PowerUp");
                break;
            case 5:
                PUI.DoAchUpPopUp(AchPics[type - 1], "Crunch", "Hit a bot with a battery");
                break;
            case 6:
                PUI.DoAchUpPopUp(AchPics[type - 1], "How Are You So Good At This?", "Survive 10 minutes");
                break;
            case 7:
                PUI.DoAchUpPopUp(AchPics[type - 1], "Rare", "Get a rare item");
                break;
            case 8:
                PUI.DoAchUpPopUp(AchPics[type - 1], "Not Darksouls", "Pause The Game");
                break;
            case 9:
                PUI.DoAchUpPopUp(AchPics[type - 1], "Out Of Time", "Get The Clock To Go Below 10% Power");
                break;
            case 10:
                PUI.DoAchUpPopUp(AchPics[type - 1], "Power Person", "Get 10 powerups");
                break;
            case 11:
                PUI.DoAchUpPopUp(AchPics[type - 1], "Power Pro", "Get 100 powerups");
                break;
            case 12:
                PUI.DoAchUpPopUp(AchPics[type - 1], "Power Newbie", "Get 1 powerup");
                break;
            case 13:
                PUI.DoAchUpPopUp(AchPics[type - 1], "100%", "You got every Aachievement");
                break;
            case 14:
                PUI.DoAchUpPopUp(AchPics[type - 1], "Unlimited Power", "Get generator power over 10k");
                break;
            case 15:
                PUI.DoAchUpPopUp(AchPics[type - 1], "You Know How To Play", "Survive 1 Minute");
                break;
            case 16:
                PUI.DoAchUpPopUp(AchPics[type - 1], "Steps In", "Take 10k steps");
                break;
        }
    }
}
