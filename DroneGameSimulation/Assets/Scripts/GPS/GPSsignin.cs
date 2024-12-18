using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;

public class GPSsignin : MonoBehaviour
{
    public void SignIn()
    {
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate(success =>
        {
            if (success)
                Debug.Log("Sign-in successful!");
            else
                Debug.LogError("Sign-in failed.");
        });
    }
}
