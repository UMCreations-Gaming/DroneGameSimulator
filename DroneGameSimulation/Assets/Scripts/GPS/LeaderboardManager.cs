using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    public void PostScore(string leaderboardId, long score)
    {
        Social.ReportScore(score, leaderboardId, success =>
        {
            if (success)
                Debug.Log("Score posted to leaderboard!");
            else
                Debug.LogError("Failed to post score.");
        });
    }
}
