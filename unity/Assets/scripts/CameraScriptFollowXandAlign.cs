using UnityEngine;
using System.Collections;

public class CameraScriptFollowXandAlign : MonoBehaviour {


	public GameObject targetToFollow;
	public float z;
	public float offsetToBorder;
	private float offset;
	private Vector3 velocity;
	public float dampTime;
	void Start ()
	{
		CalcOffset ();
	}

	// Update is called once per frame
	void LateUpdate() {
		Vector3 destination = new Vector3 ((targetToFollow.transform.position.x-offset),transform.position.y,z);
		transform.position=Vector3.SmoothDamp(transform.position,destination,ref velocity,dampTime);
	}


	float CalcOffset()
	{
		float camLeftBound = Camera.main.ViewportToWorldPoint (new Vector3 (0.0f, 0.0f, 0.0f)).x;
		offset = camLeftBound - targetToFollow.transform.position.x - offsetToBorder;
//		Debug.LogWarning (offset);
		return offset;
		}
}
