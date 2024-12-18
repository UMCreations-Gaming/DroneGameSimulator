using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootmanager : MonoBehaviour
{
    // Start is called before the first frame update
    private GPSsignin signInManager;
    private AchievementManager achievementManager;

    private void Start()
    {
        signInManager = new GPSsignin();
        achievementManager = new AchievementManager();

        signInManager.SignIn();
        achievementManager.UnlockAchievement("CgkxxxxxxxQG");
    }
}
