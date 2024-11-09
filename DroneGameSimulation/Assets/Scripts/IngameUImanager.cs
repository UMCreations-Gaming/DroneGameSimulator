using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameUImanager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text ringcountText;
    [SerializeField] int ringcointer;


    [SerializeField] GameObject levelcompetepanel;
    [SerializeField] GameObject Alllevelcompetepanel;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateRingcounter(int got, int total)
    {
        ringcountText.text = got.ToString() + "/" + total.ToString();
    }


    public void ShowLevelcompetepanel()
    {
        levelcompetepanel.SetActive(true);
    }


    public void ShowAllLevelcompetepanel()
    {
        Alllevelcompetepanel.SetActive(true);
    }

    public void Nextbutton()
    {
        levelcompetepanel.SetActive(false);
        LevelManager.instance.SetNextLevel();



    }

    public void Restartbutto()
    {
        levelcompetepanel.SetActive(false);
        LevelManager.instance.ReSettLevel();


    }

}
