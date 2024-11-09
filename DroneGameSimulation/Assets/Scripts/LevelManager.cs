using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame
    // 
    public static LevelManager instance;

    [SerializeField] GameObject player;
    [SerializeField] GameObject Path;
    [SerializeField] GameObject Path1;
    [SerializeField] GameObject[] Levelpaths;


    [SerializeField] GameObject startpont;
    [SerializeField] GameObject endpont;
    public int totalpointrequiuerd ;
    public int Current_levelindex;

    void Start()
    {
        instance = this;
        Current_levelindex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNextLevel()
    {
        Current_levelindex++;
        if (Current_levelindex < Levelpaths.Length)
        {

         GameObject _path = Levelpaths[Current_levelindex];
        totalpointrequiuerd = _path.transform.childCount;
        Gamemanager.instance.ringcount = 0;
        /* for (int i = 0; i < Path.transform.GetChildCount(); i++)
         {
             Path.transform.GetChild(i).gameObject.SetActive(true);
         }*/
        Gamemanager.instance.UpdateRingcountInUI(0, totalpointrequiuerd);
          _path.SetActive(true);

        player.transform.position = startpont.transform.position;
        }
        else
        {
            //all lecels are competed
            Debug.Log("all levels are compelted");
            Gamemanager.instance.AllLevelsCompeted();
        }
    }


    public void ReSettLevel()
    {

        GameObject _path = Levelpaths[Current_levelindex];
        totalpointrequiuerd = _path.transform.childCount; 
        Gamemanager.instance.ringcount = 0;
        for (int i = 0; i < Path.transform.childCount; i++)
        {
            _path.transform.GetChild(i).gameObject.SetActive(true);
        }
        Gamemanager.instance.UpdateRingcountInUI(0, totalpointrequiuerd);
        player.transform.position = startpont.transform.position;
    }

}
