using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental;
using UnityEngine.Networking;//unity web request

public class DataLoader : MonoBehaviour
{
    public string[] player;
    // Ienumerator
    IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://localhost/SprainedFinger/Leaderboard.php");
        yield return www.SendWebRequest();
        string playerData = www.downloadHandler.text;
        print(playerData);
        player = playerData.Split(';');
        print(GetDataValue(player[0], "NICKNAME"));
    }

    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if(value.Contains("|"))
        {
            value = value.Remove(value.IndexOf("|"));
        }
        return value;
    }
    
    
}
