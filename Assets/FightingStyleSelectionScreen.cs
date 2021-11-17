using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FightingStyleSelectionScreen : MonoBehaviour {

#region Public Fields

#endregion


#region Private Serializable Fields
    [SerializeField] private Button btnStyle01, btnStyle02, btnStyle03, btnStyle04;
    [SerializeField] private Button firstButtonSelected;
    [SerializeField] private GameObject goWerewolf;
    [SerializeField] private Camera stanceSelectionCamera;
    [SerializeField] private RuntimeAnimatorController animatorStance1, animatorStance2, animatorStance3, animatorStance4;
#endregion


#region Private Fields
private Canvas mainCanvas;
#endregion


#region MonoBehaviour CallBacks
    void Awake(){

    }

    void Start(){
        firstButtonSelected.Select();
        // goWerewolf = Instantiate(werewolfPrefab, stanceSelectionCamera.transform.position + Vector3.forward, Quaternion.identity, stanceSelectionCamera.transform);
        mainCanvas = FindObjectOfType<Canvas>();

        mainCanvas.renderMode = RenderMode.ScreenSpaceCamera;
        mainCanvas.worldCamera = Camera.main;
        
        var stanceNum = PlayerPrefs.GetInt("currentCombatStance", 1);
        var animator = goWerewolf.GetComponent<Animator>();

        switch (stanceNum)
        {
            case 1:
                animator.runtimeAnimatorController = animatorStance1;
                break;
            case 2:
                animator.runtimeAnimatorController = animatorStance2;
                break;
            case 3:
                animator.runtimeAnimatorController = animatorStance3;
                break;
            case 4:
                animator.runtimeAnimatorController = animatorStance4;
                break;
            default:
                animator.runtimeAnimatorController = animatorStance1;
                break;
        }
    }

#endregion


#region Private Methods

#endregion

#region Public Methods
    public void OnButtonStylePressed(int styleNumber){
        switch(styleNumber){
            case 1:
                // if(UFE.isConnected){
		        //     int pNum = UFE.GetLocalPlayer();
                //     if(pNum == 1){
                //         UFE.GetPlayer1ControlsScript().currentCombatStance = CombatStances.Stance1;
                //     }else{
                //         UFE.GetPlayer2ControlsScript().currentCombatStance = CombatStances.Stance1;
                //     }
                // }
                // else{
                //     // UFE.GetPlayer1ControlsScript().currentCombatStance = CombatStances.Stance1;
                    
                //     // foreach (var move in UFE.GetPlayer1().moves)
                //     // {
                //     //     move.combatStance = CombatStances.Stance1;
                //     //     Debug.Log("Set stance");
                //     // }
                //     // UFE.GetPlayer1().moves[0].combatStance = CombatStances.Stance1;

                //     UFE.GetPlayer1ControlsScript().MoveSet.ChangeMoveStances(CombatStances.Stance1);

                // }

                var animator = goWerewolf.GetComponent<Animator>();
                animator.runtimeAnimatorController = animatorStance1;

                PlayerPrefs.SetInt("currentCombatStance", 1);
            break;
            case 2:
                // if(UFE.isConnected){
		        //     int pNum = UFE.GetLocalPlayer();
                //     if(pNum == 1){
                //         UFE.GetPlayer1ControlsScript().currentCombatStance = CombatStances.Stance2;
                //     }else{
                //         UFE.GetPlayer2ControlsScript().currentCombatStance = CombatStances.Stance2;
                //     }
                // }
                // else{
                //     // UFE.GetPlayer1ControlsScript().currentCombatStance = CombatStances.Stance2;
                //     UFE.GetPlayer1ControlsScript().MoveSet.ChangeMoveStances(CombatStances.Stance2);
                // }

                 animator = goWerewolf.GetComponent<Animator>();
                animator.runtimeAnimatorController = animatorStance2;

                PlayerPrefs.SetInt("currentCombatStance", 2);
            break;
            case 3:
                // if(UFE.isConnected){
		        //     int pNum = UFE.GetLocalPlayer();
                //     if(pNum == 1){
                //         UFE.GetPlayer1ControlsScript().currentCombatStance = CombatStances.Stance3;
                //     }else{
                //         UFE.GetPlayer2ControlsScript().currentCombatStance = CombatStances.Stance3;
                //     }
                // }
                // else{
                //     UFE.GetPlayer1ControlsScript().currentCombatStance = CombatStances.Stance3;
                // }

                 animator = goWerewolf.GetComponent<Animator>();
                animator.runtimeAnimatorController = animatorStance3;

                PlayerPrefs.SetInt("currentCombatStance", 3);
            break;
            case 4:
                // if(UFE.isConnected){
		        //     int pNum = UFE.GetLocalPlayer();
                //     if(pNum == 1){
                //         UFE.GetPlayer1ControlsScript().currentCombatStance = CombatStances.Stance4;
                //     }else{
                //         UFE.GetPlayer2ControlsScript().currentCombatStance = CombatStances.Stance4;
                //     }
                // }
                // else{
                //     UFE.GetPlayer1ControlsScript().currentCombatStance = CombatStances.Stance4;
                // }

                 animator = goWerewolf.GetComponent<Animator>();
                animator.runtimeAnimatorController = animatorStance4;

                PlayerPrefs.SetInt("currentCombatStance", 4);
            break;
        }
    }

    public void OnButtonContinuePressed(){
        mainCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        gameObject.SetActive(false);
    }

#endregion
}