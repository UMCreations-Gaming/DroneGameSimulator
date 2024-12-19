using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;

public class GPSStarter : MonoBehaviour
{
    // Start is called before the first frame update// Use this for initialization

    public static  GPSStarter Instance;
	void Start ()
     {
        if(Instance == null)
        {
            Instance = this;
        }
       // PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
       // PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

        SignIn();
	}

    void SignIn()
    {
        Social.localUser.Authenticate(success =>
        {
            if (success)
                Debug.Log("Sign-in successful!");
            else
                Debug.LogError("Sign-in failed.");
        });
    }

    #region Achievements
    public static void UnlockAchievement(string id)
    {
    
        Social.ReportProgress(id, 100.0f, success =>
        {
            if (success)
                Debug.Log("Achievement unlocked!");
            else
                Debug.LogError("Failed to unlock achievement.");
        });
        
    }

    public static void IncrementAchievement(string id, int stepsToIncrement)
    {
    
        PlayGamesPlatform.Instance.IncrementAchievement(id, stepsToIncrement, success =>
        {
            if (success)
                Debug.Log("Achievement incremented!");
            else
                Debug.LogError("Failed to increment achievement.");
        });
    }

     public void RevealAchievement(string achievementId)
    {
        Social.ReportProgress(achievementId, 0.0f, success =>
        {
            if (success)
                Debug.Log("Achievement revealed!");
            else
                Debug.LogError("Failed to reveal achievement.");
        });
    }

    public static void ShowAchievementsUI()
    {
        Social.ShowAchievementsUI();
    }
    #endregion /Achievements



    #region Leaderboards
    public static void AddScoreToLeaderboard(string leaderboardId, long score)
    {
    
         Social.ReportScore(score, leaderboardId, success =>
        {
            if (success)
                Debug.Log("Score posted to leaderboard!");
            else
                Debug.LogError("Failed to post score.");
        });
    }

    public static void ShowLeaderboardsUI()
    {
        Social.ShowLeaderboardUI();
    }
    #endregion /Leaderboards

}

