using UnityEngine;
using System.Collections;

public class FollowX : MonoBehaviour {

	public Transform target;
	public float z;
	public bool useOffset;
	private float offset;


	void Start ()
	{
		if (useOffset) 
		{
			offset = transform.position.x;
			return;
		}
		offset = 0.0f;
	}
	void Update () {
	
		transform.position = new Vector3 (target.position.x+offset, transform.position.y, z);
	}
}
