using UnityEngine;
using System.Collections;

public class EndWhenCollideWithObstacle : MonoBehaviour {

	private GameController controler;

	void Awake(){
		controler = FindObjectOfType<GameController> ();
		}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Obstacle")
						controler.StopGame ();
		}
}
