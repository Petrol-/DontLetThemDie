using UnityEngine;
using System.Collections;

public class ObstacleSpawnerScript : MonoBehaviour {

    public GameObject[] obstacles;
    public float fixedDist;
    public float MaxRdmDist;

    float count;

    void Start()
    {
        count = 0;
        Instantiate(obstacles[Random.Range(0, obstacles.Length - 1)], new Vector3(Random.Range(-MaxRdmDist, MaxRdmDist) + transform.position.x, 0f, 0f), Quaternion.identity);
    }

    void Update()
    {
        float value = Mathf.FloorToInt(transform.position.x / fixedDist);
        if (value != count && value > 0)
        {
            count++;
            SpawnObstacle();
        }
    }

    void SpawnObstacle()
    {
        Instantiate(obstacles[Random.Range(0, obstacles.Length - 1)], new Vector3(Random.Range(-MaxRdmDist, MaxRdmDist) +(count+1)*fixedDist, 0, 0), Quaternion.identity);

    }
	
}
