using UnityEngine;
using System.Collections;

public  class ObstacleSpawnerPrefs : MonoBehaviour {

	private static ObstacleSpawnerPrefs _instance;
	public float fixedDist, maxRdmDist,spawningDist;

	public static ObstacleSpawnerPrefs instance
	{
		get
		{
			if(_instance==null)
				_instance=GameObject.FindObjectOfType<ObstacleSpawnerPrefs>();
			return _instance;
		}


	}

}
