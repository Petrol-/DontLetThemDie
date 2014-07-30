using UnityEngine;
using System.Collections;

public class GroundSpawnerScript : MonoBehaviour {

    float positionX;
    int count;
    public GameObject ground;
	void Start () {
        
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {
        positionX = gameObject.transform.position.x;
        float value = Mathf.FloorToInt(positionX / 100);
        if (value != count && value > 0)
        {
            count++;
            Spawn();
            
        }
	}

    private void Spawn()
    {
        Instantiate(ground, new Vector3(100.0f * (count+1f), 0f, 0f), Quaternion.identity);
        
    }
}
