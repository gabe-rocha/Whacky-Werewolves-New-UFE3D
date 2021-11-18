using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LeaderboardController : MonoBehaviour {

#region Public Fields

#endregion


#region Private Serializable Fields
[SerializeField] private GameObject prefabTemplate;
[SerializeField] private Transform content;
[SerializeField] private GameObject goLeaderboard;
#endregion

#region Private Fields
#endregion

#region MonoBehaviour CallBacks
private void Awake()
{
    goLeaderboard.SetActive(false);
}
#endregion

#region Private Methods
    private IEnumerator FetchLeaderboard()
    {
        WWW www = new WWW("http://ec2-18-220-17-137.us-east-2.compute.amazonaws.com/Leaderboard.php");
        yield return www;  

        if(www.text[0] == '0'){
            FillTable(www.text);
        }
    }

    private void FillTable(string _results){
        var results = _results.Substring(2);
        var loopSafety = 0;
        var rank = 1;
        while(results.Length > 0 && loopSafety < 5 * 60){
            var row = results.Split(',')[0];
            string rest = "";
            if(results.Contains(",")){
                rest = results.Substring(row.Length + 1);
            }
            else{
                rest = results.Substring(row.Length);   
            }
            results = rest;

            var goTemplate = Instantiate(prefabTemplate, content);
            goTemplate.SetActive(true);
            var template = goTemplate.GetComponent<LeaderboardTemplate>();

            string player = row.Split('\t')[0];
            string wins = row.Split('\t')[1];
            string losses = row.Split('\t')[2];
            string score = row.Split('\t')[3];
            Color color = rank % 2 == 0 ? Color.gray : new Color(82f/255f,82f/255f,82f/255f,255f/255f);
            
            template.Setup(rank.ToString(), player, wins, losses, score, color);

            loopSafety++;
            rank++;
        }
    }

#endregion


#region Public Methods

public void ShowLeaderboard(){
    goLeaderboard.SetActive(true);
    StartCoroutine(FetchLeaderboard());
}

public void HideLeaderboard(){
    foreach(Transform child in content){
        if(child.name != "Template")
            Destroy(child.gameObject);
    }

    goLeaderboard.SetActive(false);
}

#endregion
}