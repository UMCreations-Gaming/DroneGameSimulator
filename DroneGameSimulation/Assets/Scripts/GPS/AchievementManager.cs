using UnityEngine;
using GooglePlayGames;

public class AchievementManager : MonoBehaviour
{
    public void UnlockAchievement(string achievementId)
    {
        Social.ReportProgress(achievementId, 100.0f, success =>
        {
            if (success)
                Debug.Log("Achievement unlocked!");
            else
                Debug.LogError("Failed to unlock achievement.");
        });
    }

    public void IncrementAchievement(string achievementId, int steps)
    {
        PlayGamesPlatform.Instance.IncrementAchievement(achievementId, steps, success =>
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
}
