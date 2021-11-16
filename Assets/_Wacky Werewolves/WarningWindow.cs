using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WarningWindow : MonoBehaviour {

#region Public Fields

#endregion


#region Private Serializable Fields
[SerializeField] private TextMeshProUGUI textTitle, textWarning;
#endregion

#region Public Methods

    public void SetMessage(string title, string message){
        textTitle.text = title;
        textWarning.text = message;
    }

    public void OnButtonOkPressed(){
        Destroy(gameObject, 0.1f);
    }

#endregion
}