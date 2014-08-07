using UnityEngine;
using System.Collections;

public class GroundSpawnerScript : MonoBehaviour {
	public Transform target;
	float positionX;
    int count;
    public GameObject ground;
	void Start () {
        
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {
        positionX = target.transform.position.x;
        float value = Mathf.FloorToInt(positionX / 50);
        if (value != count && value > 0)
        {
            count++;
            Spawn();
            
        }
	}

    private void Spawn()
    {
        Instantiate(ground, new Vector3(50 * (count+1f), transform.position.y, 0f), Quaternion.identity);
        
    }
}
