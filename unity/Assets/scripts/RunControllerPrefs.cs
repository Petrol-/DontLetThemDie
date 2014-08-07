using UnityEngine;
using System.Collections;

public class RunControllerPrefs : MonoBehaviour {

	private static RunControllerPrefs _instance;
	public float runSpeed;
	
	public static RunControllerPrefs instance
	{
		get
		{
			if(_instance==null)
				_instance=GameObject.FindObjectOfType<RunControllerPrefs>();
			return _instance;
		}
	}

}
