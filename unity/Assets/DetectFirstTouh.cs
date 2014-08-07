using UnityEngine;
using System.Collections;

public class DetectFirstTouh : MonoBehaviour {

	private GameController controler;

	void Awake(){

		controler = FindObjectOfType<GameController> ();
		}

	void Update(){
		if (Input.touchCount > 0)
						controler.startTouch = true;
		}
}
