using GooglePlayGames;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void ShowAchievementsUI()
    {
        if (Social.localUser.authenticated)
        {
            Social.ShowAchievementsUI();
        }
        else
        {
            Debug.LogError("User not signed in.");
        }
    }

    public void ShowLeaderboardsUI()
    {
        if (Social.localUser.authenticated)
        {
            Social.ShowLeaderboardUI();
        }
        else
        {
            Debug.LogError("User not signed in.");
        }
    }
}
