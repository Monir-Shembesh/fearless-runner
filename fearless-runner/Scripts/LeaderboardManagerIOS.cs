using UnityEngine;
using System.Collections;
using VoxelBusters.NativePlugins;
using System;

public class LeaderboardManagerIOS : MonoBehaviour
{

    // only using this for apple

    private void Start()
    {
        UserSignin();
    }

    void UserSignin()
    {
        // check if GameService is available
        if (!NPBinding.GameServices.IsAvailable()) return;


        // user not logged-in
        if (!NPBinding.GameServices.LocalUser.IsAuthenticated)
        {
            NPBinding.GameServices.LocalUser.Authenticate((bool _success, string _error) =>
            {
                if (_success)
                {
                    Debug.Log("Sign-In Successfully");
                    Debug.Log("Local User Details : " + NPBinding.GameServices.LocalUser.ToString());
                }
                else
                {
                    Debug.Log("Sign-In Failed with error " + _error);
                }
            });
        }

        //  NPBinding.GameServices.LocalUser; // returns currently logged-in play-games user

    }



    public void ShowLeaderboard()
    {
        UserSignin();
        NPBinding.GameServices.ShowLeaderboardUIWithGlobalID("globalId", eLeaderboardTimeScope.ALL_TIME, onLeaderboardShown);
    }

    private void onLeaderboardShown(string _error)
    {
        Debug.Log("Error during leaderboard event :: " + _error);
    }

}
