using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour {

	public GameObject[] obstacles;
	public Transform player;
	private float fixedDist;
	private float maxRdmDist;
	private float spawningDist;
	private float lastValue, lastPosition;
	private float count;

	void Start()
	{
		ObstacleSpawnerPrefs prefs = FindObjectOfType<ObstacleSpawnerPrefs> ();
		fixedDist = prefs.fixedDist;
		maxRdmDist = prefs.maxRdmDist;
		spawningDist = prefs.spawningDist;
		prefs = null;
		count = 0;
		lastValue = 0;

		float firstSpawnPos = getRandomFloat (maxRdmDist) + transform.position.x;
		lastPosition = firstSpawnPos;
		Instantiate(obstacles[Random.Range(0, obstacles.Length)], new Vector3(firstSpawnPos, transform.position.y, 0f), Quaternion.identity);
		count++;
	}

	void Update()
	{
		if (lastPosition < (player.position.x + spawningDist)) 
		{
			float nextPos = lastPosition+fixedDist+getRandomFloat(maxRdmDist);
//			Debug.Log("NextPos "+nextPos);
			SpawnObstacle(nextPos);
			lastPosition=nextPos;
		}

	}

	void SpawnObstacle(float positionX)
	{
		Instantiate(obstacles[Random.Range(0, obstacles.Length)], new Vector3(positionX, transform.position.y, 0), Quaternion.identity);
//		Debug.Log ("Next Obstacle " + positionX);
	}
	float getRandomFloat(float minMaxFloat)
	{
		float val = (Random.Range(-minMaxFloat, minMaxFloat)+lastValue)% minMaxFloat;
		lastValue = val;
		return val;
	} 
}
