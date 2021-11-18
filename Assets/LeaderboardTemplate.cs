using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeaderboardTemplate : MonoBehaviour {

#region Public Fields

#endregion


#region Private Serializable Fields
[SerializeField] private TextMeshProUGUI textRank, textPlayer, textWins, textLosses, textScore;
[SerializeField] private Image bgImage;
#endregion


#region Private Fields

#endregion


#region MonoBehaviour CallBacks

#endregion


#region Private Methods

#endregion


#region Public Methods
    public void Setup(string rank, string player, string wins, string losses, string score, Color color){

        if(player == DBManager.Instance.username){
            textRank.text = rank;
            textRank.color = Color.red;
            textPlayer.text = player;
            textPlayer.color = Color.red;
            textWins.text = wins;
            textWins.color = Color.red;
            textLosses.text = losses;
            textLosses.color = Color.red;
            textScore.text = score;
            textScore.color = Color.red;
            bgImage.color = color;
        }
        else{
            textRank.text = rank;        
            textPlayer.text = player;
            textWins.text = wins;
            textLosses.text = losses;
            textScore.text = score;
            bgImage.color = color;
        }
    }
#endregion
}