using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoginScreenController : MonoBehaviour {

#region Public Fields

#endregion


#region Private Serializable Fields
[SerializeField] private TMP_InputField inputUsernameLoginScreen, inputPasswordLoginScreen;
[SerializeField] private TMP_InputField inputUsernameRegisterScreen, inputPasswordRegisterScreen, inputRepeatPasswordRegisterScreen;
[SerializeField] private GameObject registerWindow;
[SerializeField] private GameObject prefabWarningWindow;
[SerializeField] private Transform loginCanvas;
[SerializeField] private TextMeshProUGUI textLoginStatus;
#endregion


#region Private Fields
// private Firebase.Auth.FirebaseAuth auth;
#endregion


#region MonoBehaviour CallBacks
    void Awake(){

    }

    void Start(){
    }

    void Update(){

    }
#endregion


#region Private Methods
    
#endregion


#region Public Methods

    public void OnButtonLoginPressed(){

        var email = inputUsernameLoginScreen.text;
        var password = inputPasswordLoginScreen.text;


        // textLoginStatus.text = "Not Logged In";

        WWW www = new WWW("");
        var gabe = 1;

        
    }

    public void OnButtonRegisterPressed(){
        registerWindow.SetActive(true);
    }

    public void OnButtonGoogleSignInPressed(){

    }

    public void OnButtonRegisterDonePressed(){

        var email = inputUsernameRegisterScreen.text;
        var password = inputPasswordRegisterScreen.text;
        var repeatPassword = inputRepeatPasswordRegisterScreen.text;

        if(password.Equals(repeatPassword)){
            //register user


        }else{
            // inputPasswordRegisterScreen.set
            var warningWindow = Instantiate(prefabWarningWindow, loginCanvas);
            warningWindow.GetComponent<WarningWindow>().SetMessage("Warning", "Passwords don't match");
        }

    }

#endregion
}