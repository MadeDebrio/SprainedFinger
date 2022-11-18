using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.Json;
using Newtonsoft.Json;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;
using SprainedFinger;


public class Leaderboard : MonoBehaviour
{
    public GameObject rowPrefab;
    public Transform rowsParent;
    public static string loggedInPlayfabId;
   

    // Start is called before the first frame update
    void Start()
    {       
        GetLeaderboardAroundPlayer();
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
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            TMP_Text[] texts = newGo.GetComponentsInChildren<TMP_Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();
            Debug.Log(string.Format("PLACE : {0}| ID:{1}| VALUE:{2}",
                item.Position, item.PlayFabId, item.StatValue+1.ToString()));
        }
    }
    public void GetLeaderboardAroundPlayer()
    {
        var request = new GetLeaderboardAroundPlayerRequest
        {
            StatisticName = "Platform Score",
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnLeaderboardAroundPlayerGet, OnErrorShared);
    }

    void OnLeaderboardAroundPlayerGet(GetLeaderboardAroundPlayerResult result)
    {


        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            TMP_Text[] texts = newGo.GetComponentsInChildren<TMP_Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();
            Debug.Log(string.Format("PLACE : {0}| ID:{1}| VALUE:{2}",
                item.Position, item.PlayFabId, item.StatValue + 1.ToString()));

            if (loggedInPlayfabId == item.PlayFabId)
            {                
                SprainedFinger.PhotonConnector.nickName = item.DisplayName;
                texts[0].color = Color.cyan;
                texts[1].color = Color.cyan;
                texts[2].color = Color.cyan;
            }
        }
    }
    
}

