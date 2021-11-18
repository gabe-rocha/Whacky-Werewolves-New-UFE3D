using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class LoginScreenController : MonoBehaviour {

#region Public Fields

#endregion


#region Private Serializable Fields
[SerializeField] private TMP_InputField inputUsernameLoginScreen, inputPasswordLoginScreen;
[SerializeField] private TMP_InputField inputUsernameRegisterScreen, inputPasswordRegisterScreen, inputRepeatPasswordRegisterScreen;
[SerializeField] private GameObject registerWindow, prefabWarningWindow, goLoginScreen;
[SerializeField] private Button registerDoneButton, loginButton;
[SerializeField] private Transform loginCanvas;
[SerializeField] private TextMeshProUGUI textLoginStatus;
#endregion


#region Private Fields
// private Firebase.Auth.FirebaseAuth auth;

private Canvas mainCanvas;
#endregion


#region MonoBehaviour CallBacks
    void Awake(){
    }

    void Start(){
        UFE.isShowingLoginOrRegisterScreen = true;

        var canvas = GameObject.Find("Canvas");
        if(canvas != null){
            mainCanvas = canvas.GetComponent<Canvas>();
        }
        
    }

    void Update(){
        CheckInputFieldsLoginScreen();
        CheckInputFieldsRegisterScreen();

        CheckLoggedOut();
    }

    private void CheckLoggedOut()
    {
        if(!DBManager.Instance.IsLoggedIn){
            goLoginScreen.SetActive(true);
        }
    }
    #endregion


    #region Private Methods
    private void CheckInputFieldsLoginScreen(){
        var username = inputUsernameLoginScreen.text;
        var password = inputPasswordLoginScreen.text;

        if(username.Length < 4 || password == ""){
            loginButton.interactable = false;
        }else{
            loginButton.interactable = true;
        }
    }

    private void CheckInputFieldsRegisterScreen(){
        var username = inputUsernameRegisterScreen.text;
        var password = inputPasswordRegisterScreen.text;
        var repeatPassword = inputRepeatPasswordRegisterScreen.text;

        if(username.Length < 4 || password == "" || repeatPassword == ""){
            registerDoneButton.interactable = false;
        }else{
            registerDoneButton.interactable = true;
        }
    }
#endregion


#region Public Methods

    public void OnButtonLoginPressed(){

        var email = inputUsernameLoginScreen.text;
        var password = inputPasswordLoginScreen.text;

        StartCoroutine(LoginUser());
        
    }

    public void OnButtonRegisterPressed(){
        registerWindow.SetActive(true);
    }

    public void OnButtonGoogleSignInPressed(){
        //TODO
        //UFE.isShowingLoginOrRegisterScreen = false;
    }

    private IEnumerator LoginUser(){
        WWWForm form = new WWWForm();
        form.AddField("username", inputUsernameLoginScreen.text);
        form.AddField("password", inputPasswordLoginScreen.text);

        WWW www = new WWW("http://ec2-18-220-17-137.us-east-2.compute.amazonaws.com/Login.php", form);
        yield return www;  

        if(www.text[0] == '0'){
            DBManager.Instance.username = inputUsernameLoginScreen.text;
            DBManager.Instance.wins = int.Parse(www.text.Split('\t')[1]);
            DBManager.Instance.losses = int.Parse(www.text.Split('\t')[2]);
            DBManager.Instance.score = int.Parse(www.text.Split('\t')[3]);
            DBManager.Instance.isVIP = int.Parse(www.text.Split('\t')[4]) == 1;

            DBManager.Instance.Print();

            // var warningWindow = Instantiate(prefabWarningWindow, mainCanvas.transform);
            // warningWindow.GetComponent<WarningWindow>().SetMessage("Welcome!", $"Welcome back {DBManager.Instance.username}!");
            
            UFE.isShowingLoginOrRegisterScreen = false;
            goLoginScreen.SetActive(false);

        }else{
            var warningWindow = Instantiate(prefabWarningWindow, loginCanvas);
            warningWindow.GetComponent<WarningWindow>().SetMessage("Error", www.text);
        }
    }

    

    public void OnButtonRegisterDonePressed(){

        var email = inputUsernameRegisterScreen.text;
        var password = inputPasswordRegisterScreen.text;
        var repeatPassword = inputRepeatPasswordRegisterScreen.text;

        if(password.Equals(repeatPassword)){
            //register user
            StartCoroutine(RegisterNewUserCor());
        }else{
            // inputPasswordRegisterScreen.set
            var warningWindow = Instantiate(prefabWarningWindow, loginCanvas);
            warningWindow.GetComponent<WarningWindow>().SetMessage("Error", "Passwords don't match");
        }
    }

    private IEnumerator RegisterNewUserCor(){

        WWWForm form = new WWWForm();
        form.AddField("username", inputUsernameRegisterScreen.text);
        form.AddField("password", inputPasswordRegisterScreen.text);

        WWW www = new WWW("http://ec2-18-220-17-137.us-east-2.compute.amazonaws.com/Register.php", form);
        
        yield return www;        

        if (www.text.Contains("0")){
            Debug.Log("User Registered Successfully");
            var warningWindow = Instantiate(prefabWarningWindow, loginCanvas);
            warningWindow.GetComponent<WarningWindow>().SetMessage("Success", "User Created Succesfully");
            registerWindow.SetActive(false);
        }else{
            Debug.Log($"Error creating user: {www.text}");
            var warningWindow = Instantiate(prefabWarningWindow, loginCanvas);
            warningWindow.GetComponent<WarningWindow>().SetMessage("Error", www.text);
        }
    }

    public void OnButtonExitPressed(){
#if !UNITY_EDITOR
        Application.Quit();
#endif
    }

#endregion
}