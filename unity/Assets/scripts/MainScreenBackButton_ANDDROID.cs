using UnityEngine;
using System.Collections;

public class MainScreenBackButton_ANDDROID : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Escape))
		{
			// Insert Code Here (I.E. Load Scene, Etc)
			Application.Quit();
			
			return;
		}
	}
}
