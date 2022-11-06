using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.Json;
using Newtonsoft.Json;
using PlayFab;
using PlayFab.ClientModels;

public class Leaderboard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private static void OnErrorShared(PlayFabError error)
    {

        Debug.Log(error.GenerateErrorReport());
    }

    public void SendLeaderboard(int score)
    {
        PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest()
        {
            FunctionName = "SendPlatformScore",
            FunctionParameter = new { scoreSend = score },
            GeneratePlayStreamEvent = true,
        }, OnCloudUpdateStats, OnErrorShared);

    }

    private static void OnCloudUpdateStats(ExecuteCloudScriptResult result)
    {
        Debug.Log(PlayFab.PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer));
        JsonObject jsonResult = (JsonObject)result.FunctionResult;
        object messageValue;
        jsonResult.TryGetValue("messageValue", out messageValue);
        Debug.Log((string)messageValue);
    }



    void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Platform Score",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnErrorShared);
    }

    void OnLeaderboardGet(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
        }
    }
}
