using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class DataInserter : MonoBehaviour
{
    string CreateUserURL = "http://localhost/SprainedFinger/InsertUsers.php";
    public TMP_InputField USERNAME;
    public TMP_InputField EMAIL;
    public TMP_InputField PASSWORD;
    public Button SUBMIT;
    // Start is called before the first frame update
    void Start()
    {
        SUBMIT.onClick.AddListener(CreateUser) ;
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateUser()
    {
        StartCoroutine(Upload(USERNAME.text,PASSWORD.text,EMAIL.text));
        Debug.Log("USER HAS BEEN CREATED");
    }

    IEnumerator Upload(string username, string password, string email)
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);
        form.AddField("emailPost", email);

        using (UnityWebRequest www = UnityWebRequest.Post(CreateUserURL, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}
