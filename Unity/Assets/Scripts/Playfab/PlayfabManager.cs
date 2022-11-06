using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
//using PlayFab.Json;
//using Newtonsoft.Json;
using TMPro;

public class PlayfabManager : MonoBehaviour
{
    private void Awake()
    {
        //DontDestroyOnLoad(this.gameObject); 
    }

    // Start is called before the first frame update
    void Start()
    {
        Login();
    }

    // Update is called once per frame

    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnErrorShared);
    }

    void OnLoginSuccess(LoginResult result)
    {
        //messageText.text = "Logged in!";
        Debug.Log("Succesfull Login/Account Created");
    }

    private static void OnErrorShared(PlayFabError error)
    {

        Debug.Log(error.GenerateErrorReport());
    }


    //******************************************************************************************************LEADERBOARD***************************************************************************************************

    //public void SendLeaderboard(int score)
    //{
    //    var request = new UpdatePlayerStatisticsRequest
    //    {
    //        Statistics = new List<StatisticUpdate>
    //        {
    //            new StatisticUpdate
    //            {
    //                StatisticName="Platform Score",
    //                Value=score
    //            }
    //        }
    //    };
    //    PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    //}

    //void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    //{
    //    Debug.Log("Successfull leaderboard sent");
    //}

    //public void SendLeaderboard(int score)
    //{
    //    PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest()
    //    {
    //        FunctionName = "SendPlatformScore",
    //        FunctionParameter = new { scoreSend = score },
    //        GeneratePlayStreamEvent = true,
    //    }, OnCloudUpdateStats, OnErrorShared);

    //}

    //private static void OnCloudUpdateStats(ExecuteCloudScriptResult result)
    //{
    //    Debug.Log(PlayFab.PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer));
    //    JsonObject jsonResult = (JsonObject)result.FunctionResult;
    //    object messageValue;
    //    jsonResult.TryGetValue("messageValue", out messageValue);
    //    Debug.Log((string)messageValue);
    //}

    

    //void GetLeaderboard()
    //{
    //    var request = new GetLeaderboardRequest{
    //        StatisticName = "Platform Score",
    //        StartPosition = 0,
    //        MaxResultsCount= 10
    //    };
    //    PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnErrorShared);
    //}

    //void OnLeaderboardGet(GetLeaderboardResult result)
    //{
    //    foreach (var item in result.Leaderboard)
    //    {
    //        Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
    //    }
    //}

    //********************************************************LOGIN REGISTER*************************************************
    //[Header("UI")]
    //public Text messageText;
    //public TMP_InputField usernameInput;
    //public TMP_InputField emailInput;
    //public TMP_InputField passwordInput;
    //public Button SUBMIT;
    //public void RegisterButton()
    //{
    //    if (passwordInput.text.Length < 6)
    //    {
    //        messageText.text = "Password too short!";
    //        return;
    //    }
    //    var request = new RegisterPlayFabUserRequest
    //    {
    //        Email = emailInput.text,
    //        Password = passwordInput.text,
    //        RequireBothUsernameAndEmail = false

    //    };
    //    PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    //}

    //void OnRegisterSuccess(RegisterPlayFabUserResult result)
    //{
    //    messageText.text = "Registered and Logged in";
    //}
    //void OnError(PlayFabError error)
    //{
    //    messageText.text = error.ErrorMessage;
    //    Debug.Log(error.GenerateErrorReport());
    //}

    //public void LoginButton()
    //{        
    //    var request = new LoginWithEmailAddressRequest{
    //        Email = emailInput.text,
    //        Password = passwordInput.text,        
    //    };
    //    PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    //}

    //public void ResetPasswordButton()
    //{
    //    if (passwordInput.text.Length < 6)
    //    {
    //        messageText.text = "Password too short!";
    //        return;
    //    }
    //    var request = new SendAccountRecoveryEmailRequest
    //    {
    //        Email = emailInput.text,
    //        TitleId = "B6279"
    //    };
    //    PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    //}

    //void OnPasswordReset(SendAccountRecoveryEmailResult result)
    //{
    //    messageText.text = "Password reset mail sent!";
    //}

}

