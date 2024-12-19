using GooglePlayGames;
using UnityEngine;
using UnityEngine.UI;

public class GPSUI : MonoBehaviour
{

    private int score = 0;
    public Text pointsTxt ;
    

     

      public void AddSCore()
    {
        score++;
        UpdatePointsText();
        //GPSStarter.Instance.IncrementCounter();
    }

    public void Restart()
    {
    
        GPSStarter.AddScoreToLeaderboard(GPGSIds.leaderboard_hscoreborad, score);
        score = 0;
        UpdatePointsText();
         
    }

    public void Increment()
    { 
        GPSStarter.IncrementAchievement(GPGSIds.achievement_onlevel5, 5);
    }

    public void Unlock()
    {
        GPSStarter.UnlockAchievement(GPGSIds.achievement_100coin);
    }

    public void ShowAchievements()
    {
        GPSStarter.ShowAchievementsUI();
    }

    public void ShowLeaderboards()
    {
        GPSStarter.ShowLeaderboardsUI();
    }

    public void UpdatePointsText()
    {
        pointsTxt.text = score.ToString();
    }
}
