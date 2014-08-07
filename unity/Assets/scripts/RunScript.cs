using UnityEngine;
using System.Collections;

public class RunScript : MonoBehaviour {

    public Rigidbody2D character;
	private float speed;
	public bool canRun;

	void Start(){
		canRun = false;
		}
	void Awake()
	{
		RunControllerPrefs prefs = GameObject.FindObjectOfType<RunControllerPrefs> ();
		speed = prefs.runSpeed;
		prefs = null;
	}


    void Update()
    {
		if(canRun)
     		character.velocity = new Vector2(speed, character.velocity.y);

		if (Input.GetKeyDown (KeyCode.Escape)) { 
			//Application.Quit();
				}
    }
}
