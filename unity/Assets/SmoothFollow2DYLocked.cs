using UnityEngine;
using System.Collections;

public class SmoothFollow2DYLocked : MonoBehaviour {

	//Written by Scott Kovacs (in JS) via UnityAnswers.com; Oct 5th 2010
	//2DCameraFollow - Platformer Script


	/*var dampTime : float = 0.3; //offset from the viewport center to fix damping
	private var velocity = Vector3.zero;
	var target : Transform;
	
	function Update() {
		if(target) {
			var point : Vector3 = camera.WorldToViewportPoint(target.position);
			var delta : Vector3 = target.position - camera.ViewportToWorldPoint(Vector3(0.5, 0.5, point.z));
			var destination : Vector3 = transform.position + delta;
			
			// Set this to the Y position you want the camera locked to
			destination.y = 0; 
			
			transform.position = Vector3.SmoothDamp(transform.position, destination, velocity, dampTime);
		}
	}
	*/

	public float dampTime = 0.3f;
	public Transform target;
	public float z;
	Vector3 velocity = Vector3.zero;

	void LateUpdate()
	{

		if (target) 
		{
			Vector3 point = Camera.main.WorldToViewportPoint(target.position);
			Vector3 delta = target.position-camera.ViewportToWorldPoint(new Vector3(0.5f,0.5f,0f));
			Vector3 destination = new Vector3(transform.position.x+delta.x,transform.position.y,z);
			transform.position=Vector3.SmoothDamp(transform.position,destination,ref velocity,dampTime);
		}
	}
}
