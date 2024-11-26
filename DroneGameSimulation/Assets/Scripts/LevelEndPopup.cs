using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndPopup : BasePopup
{

     
    public override void Show()
    {
        //titleText.text = "Warning"; // Set the title
        //messageText.text = "This is a warning popup"; // Set the message
        AnimateShow(); // Call the animation method
        
    }

    public void Nextbutton()
    {
        LevelManager.instance.SetNextLevel();
    }

    public void Restartbutto()
    {
        LevelManager.instance.ReSettLevel();
    }
}
