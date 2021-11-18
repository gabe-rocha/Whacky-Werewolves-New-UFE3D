using System;
using System.Collections;
using UnityEngine;


public class DBManager : MonoBehaviour
{
    public static DBManager Instance;

    public  string username = null;
    public  int wins = 0, losses = 0, score = 0;
    public  bool isVIP = false;

    public  bool IsLoggedIn { get { return username != null; }}


    private void Awake()
    {
        Instance = this;
    }

    public  void LogOut(){
        username = null;
    }

    public  void Print()
    {
        Debug.Log($"username: {username}");
        Debug.Log($"wins: {wins}");
        Debug.Log($"losses: {losses}");
        Debug.Log($"score: {score}");
        Debug.Log($"isVip: {isVIP}");
    }

    public void AddWinToLocalPlayer()
    {
        StartCoroutine(AddWinToLocalPlayerCor());
    }

    private IEnumerator AddWinToLocalPlayerCor(){
        
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        
        wins++;
        form.AddField("wins", wins);
        
        form.AddField("losses", losses);
        
        score = (wins * 20) + (losses * -10);
        form.AddField("score", score);

        WWW www = new WWW("http://ec2-18-220-17-137.us-east-2.compute.amazonaws.com/UpdateLeaderboard.php", form);
        yield return www;

        if(www.text.Contains("0")){
            Debug.Log($"{username} data successfully updated");
        }
        else{
            Debug.Log($"{username} data failed to update");
        }
    }

    public void AddLossToLocalPlayer(){
        StartCoroutine(AddLossToLocalPlayerCor());
    }

    internal IEnumerator AddLossToLocalPlayerCor()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);        
        
        form.AddField("wins", wins);
        
        losses++;
        form.AddField("losses", losses);
        
        score = (wins * 20) + (losses * -10);
        form.AddField("score", score);

        WWW www = new WWW("http://ec2-18-220-17-137.us-east-2.compute.amazonaws.com/UpdateLeaderboard.php", form);
        yield return www;

        if(www.text.Contains("0")){
            Debug.Log($"{username} data successfully updated");
        }
        else{
            Debug.Log($"{username} data failed to update");
        }
    }
}