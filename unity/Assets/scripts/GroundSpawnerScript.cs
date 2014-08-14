using UnityEngine;
using System.Collections;

public class GroundSpawnerScript : MonoBehaviour {
	public Transform target;
	float positionX;
    int count;
    public GameObject ground;
	void Start () {
        
        count = 0;
		//preLoad 3 grounds with an object pooler
		ground.CreatePool (3);
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
		//spawn the ground where needed
		ground.Spawn (new Vector3 (50 * (count + 1f), transform.position.y, 0f), Quaternion.identity);
        //Instantiate(ground, new Vector3(50 * (count+1f), transform.position.y, 0f), Quaternion.identity);
        
    }
}
