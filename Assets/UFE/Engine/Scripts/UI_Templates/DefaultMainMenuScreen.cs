using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UFE3D;
using Photon.Pun;
using Photon.Realtime;

public class DefaultMainMenuScreen : MainMenuScreen, IConnectionCallbacks{
	#region public instance fields
	public AudioClip onLoadSound;
	public AudioClip music;
	public AudioClip selectSound;
	public AudioClip cancelSound;
	public AudioClip moveCursorSound;
	public bool stopPreviousSoundEffectsOnLoad = false;
	public float delayBeforePlayingMusic = 0.1f;

	public Button buttonNetwork;
	public Button buttonBluetooth;
	#endregion

	private void OnEnable()
	{
		PhotonNetwork.AddCallbackTarget(this);
	}

	private void OnDisable()
	{
		PhotonNetwork.RemoveCallbackTarget(this);
	}

	#region public override methods
	public override void DoFixedUpdate(
		IDictionary<InputReferences, InputEvents> player1PreviousInputs,
		IDictionary<InputReferences, InputEvents> player1CurrentInputs,
		IDictionary<InputReferences, InputEvents> player2PreviousInputs,
		IDictionary<InputReferences, InputEvents> player2CurrentInputs
	){
		base.DoFixedUpdate(player1PreviousInputs, player1CurrentInputs, player2PreviousInputs, player2CurrentInputs);

		this.DefaultNavigationSystem(
			player1PreviousInputs,
			player1CurrentInputs,
			player2PreviousInputs,
			player2CurrentInputs,
			this.moveCursorSound,
			this.selectSound,
			this.cancelSound
		);
	}

    public void OnConnected()
    {
    }

    public void OnConnectedToMaster()
    {
		if (buttonNetwork != null) {
			buttonNetwork.interactable = true;
			buttonNetwork.transform.Find("Text").gameObject.GetComponent<Text>().text = "Quick Play";
		}
    }

    public void OnCustomAuthenticationFailed(string debugMessage)
    {
		if (buttonNetwork != null) {
			buttonNetwork.interactable = false;
			buttonNetwork.transform.Find("Text").gameObject.GetComponent<Text>().text = "Connecting...";
		}
    }

    public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
    {
    }

    public void OnDisconnected(DisconnectCause cause)
    {
		if (buttonNetwork != null) {
			buttonNetwork.interactable = false;
			buttonNetwork.transform.Find("Text").gameObject.GetComponent<Text>().text = "Connecting...";
		}
    }

    public void OnRegionListReceived(RegionHandler regionHandler)
    {
    }

    public override void OnShow (){
		base.OnShow ();
		this.HighlightOption(this.FindFirstSelectable());

		if (this.music != null){
			UFE.DelayLocalAction(delegate(){UFE.PlayMusic(this.music);}, this.delayBeforePlayingMusic);
		}
		
		if (this.stopPreviousSoundEffectsOnLoad){
			UFE.StopSounds();
		}
		
		if (this.onLoadSound != null){
			UFE.DelayLocalAction(delegate(){UFE.PlaySound(this.onLoadSound);}, this.delayBeforePlayingMusic);
		}

		if (buttonNetwork != null) {
			// buttonNetwork.interactable = UFE.isNetworkAddonInstalled || UFE.isBluetoothAddonInstalled;
			
			if(PhotonNetwork.IsConnectedAndReady){
				if (buttonNetwork != null) {
					buttonNetwork.interactable = true;
					buttonNetwork.transform.Find("Text").gameObject.GetComponent<Text>().text = "Quick Play";
				}
			}else{
				if (buttonNetwork != null) {
					buttonNetwork.interactable = false;
					buttonNetwork.transform.Find("Text").gameObject.GetComponent<Text>().text = "Connecting...";
				}
			}
		}

		if (buttonBluetooth != null){
            buttonBluetooth.interactable = UFE.isBluetoothAddonInstalled;
        }
	}
	#endregion
}
