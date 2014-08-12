using UnityEngine;
using System.Collections;

/// <summary>
/// Message button fix.
/// Fix a problem in UIMessageButton where the script looses its target if the target is a persistent singleton.
/// Finds the tazget based on its name and update the UIMessageButton's target.
/// </summary>
public class MessageButtonFix : MonoBehaviour {

	public bool enable; //Enable or not
	public string targetName;

	void Awake(){
		//if not enabled, don't update the target
		if (!enable)
						return;
		//Retrieve the UIMessageButton attached to this GameObject
		UIButtonMessage	button = GetComponent<UIButtonMessage> ();
		//Debug.LogWarning ("LeaderBoardButton target : "+button.target + "  "+button.functionName);
		//Finf the target based on its name and update the button's target
		button.target = GameObject.Find (targetName);
		}
}
