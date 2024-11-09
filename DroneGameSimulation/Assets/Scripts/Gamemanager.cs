using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    public IngameUImanager ingameUImanager;

    public int ringcount = 0;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
        
    } 

    public void IncrementRingcount()
    {
        ringcount += 1;
        SoundManager.instance.PlayRingPassSound();
        ingameUImanager.UpdateRingcounter(ringcount, LevelManager.instance.totalpointrequiuerd);
    }

    public void LevelCompeted()
    {
        //show level competepanel
        SoundManager.instance.PlayLevelreachSound();
        ingameUImanager.ShowLevelcompetepanel();
        ingameUImanager.UpdateRingcounter(0, LevelManager.instance.totalpointrequiuerd);
 
    }

    public void UpdateRingcountInUI(int got,int total)
    {
        ingameUImanager.UpdateRingcounter(got, total);
    }


    public void AllLevelsCompeted()
    {
        //show level competepanel

        ingameUImanager.ShowAllLevelcompetepanel();
       // ingameUImanager.UpdateRingcounter(0, LevelManager.instance.totalpointrequiuerd);

    }
}
