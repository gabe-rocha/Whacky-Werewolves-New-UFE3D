using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UFE3D;

public class GabesFixForMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject werewolfMainMenu;

    private bool stanceSet = false;

    private void Start()
    {
    }
    private void Update()
    {
        if(UFE.currentScreen != null){
            // Debug.Log($"{UFE.currentScreen.name}  /  {UFE.GetMainMenuScreen().name}");
            
            if(UFE.currentScreen.name.Contains(UFE.GetMainMenuScreen().name)){
                werewolfMainMenu.SetActive(true);

                var fov = UFE.config.cameraOptions.initialFieldOfView;
                Camera.main.fieldOfView = fov;
                Camera.main.transform.position = Vector3.zero;
                Camera.main.transform.rotation = Quaternion.identity;

                //main menu is loaded, let's check and kill stuff we don't want to see
                var battleGUI = GameObject.Find("5. BattleGUI(Clone)");
                if(battleGUI != null){
                    Destroy(battleGUI.gameObject);
                    var game = GameObject.Find("Game");
                    if(game != null){
                        Destroy(game.gameObject);
                    }

                    // var ufe = GameObject.Find("UFE Manager");
                    // if(ufe != null){
                    //     Destroy(ufe.gameObject);
                    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    // }
                }
            }
            else{
                werewolfMainMenu.SetActive(false);
            }
        }
        
        else{
            return;

            var game = GameObject.Find("Game");
            if(game != null && stanceSet == false){
                //we are playing
                var stanceNum = PlayerPrefs.GetInt("currentCombatStance", 1);
                if(UFE.isConnected){
		            int pNum = UFE.GetLocalPlayer();
                    if(pNum == 1){
                        switch(stanceNum){
                        case 1:
                                UFE.GetPlayer1ControlsScript().MoveSet.ChangeMoveStances(CombatStances.Stance1);
                        break;
                        case 2:
                                UFE.GetPlayer1ControlsScript().MoveSet.ChangeMoveStances(CombatStances.Stance2);
                        break;
                        case 3:
                                UFE.GetPlayer1ControlsScript().MoveSet.ChangeMoveStances(CombatStances.Stance3);
                        break;
                        case 4:
                                UFE.GetPlayer1ControlsScript().MoveSet.ChangeMoveStances(CombatStances.Stance4);
                        break;
                    }
                    }else{
                        switch(stanceNum){
                        case 1:
                                UFE.GetPlayer2ControlsScript().MoveSet.ChangeMoveStances(CombatStances.Stance1);
                        break;
                        case 2:
                                UFE.GetPlayer2ControlsScript().MoveSet.ChangeMoveStances(CombatStances.Stance2);
                        break;
                        case 3:
                                UFE.GetPlayer2ControlsScript().MoveSet.ChangeMoveStances(CombatStances.Stance3);
                        break;
                        case 4:
                                UFE.GetPlayer2ControlsScript().MoveSet.ChangeMoveStances(CombatStances.Stance4);
                        break;
                    }
                    }
                }
                else{
                    switch(stanceNum){
                        case 1:
                                UFE.GetPlayer1ControlsScript().MoveSet.ChangeMoveStances(CombatStances.Stance1);
                        break;
                        case 2:
                                UFE.GetPlayer1ControlsScript().MoveSet.ChangeMoveStances(CombatStances.Stance2);
                        break;
                        case 3:
                                UFE.GetPlayer1ControlsScript().MoveSet.ChangeMoveStances(CombatStances.Stance3);
                        break;
                        case 4:
                                UFE.GetPlayer1ControlsScript().MoveSet.ChangeMoveStances(CombatStances.Stance4);
                        break;
                    }
                }

                stanceSet = true;
            }
        }
    }
}
