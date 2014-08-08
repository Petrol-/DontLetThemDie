using UnityEngine;
using System.Collections;

public class LevelSelector : MonoBehaviour {

	public void Easy(){
		Application.LoadLevel ("Level2Char");
		}
	public void Normal(){
		Application.LoadLevel ("Level3Char");
		}
	public void Hard(){
		Application.LoadLevel ("Level4Char");
		}
	public void Crazy(){
		Application.LoadLevel ("Level5Char");
		}
}
