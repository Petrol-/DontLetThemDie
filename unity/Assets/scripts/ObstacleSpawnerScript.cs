using UnityEngine;
using System.Collections;

public class ObstacleSpawnerScript : MonoBehaviour {
	public Transform target;
    public GameObject[] obstacles;
    private float fixedDist;
    private float maxRdmDist;
	private float lastValue;

    float count;

    void Start()
    {
		ObstacleSpawnerPrefs prefs = FindObjectOfType<ObstacleSpawnerPrefs> ();
		fixedDist = prefs.fixedDist;
		maxRdmDist = prefs.maxRdmDist;
		prefs = null;
        count = 0;
		lastValue = 0;
        Instantiate(obstacles[Random.Range(0, obstacles.Length - 1)], new Vector3(getRandomFloat(maxRdmDist) + transform.position.x, transform.position.y, 0f), Quaternion.identity);
 		
	}

    void Update()
    {
        float value = Mathf.FloorToInt(target.transform.position.x / fixedDist);
        if (value != count && value > 0)
        {
            count++;
            SpawnObstacle();
        }
    }

    void SpawnObstacle()
    {
        Instantiate(obstacles[Random.Range(0, obstacles.Length - 1)], new Vector3(getRandomFloat(maxRdmDist) +(count+1)*fixedDist, transform.position.y, 0), Quaternion.identity);
		//Debug.Log ("Next Obstacle " + getRandomFloat (maxRdmDist) + (count + 1) * fixedDist);
    }
    float getRandomFloat(float minMaxFloat)
    {
		float val = (Random.Range(-minMaxFloat, minMaxFloat)+lastValue)% minMaxFloat;
		lastValue = val;
		return val;
    } 
	
}
