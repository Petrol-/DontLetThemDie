using UnityEngine;
using System.Collections;

public class DestroyerScript : MonoBehaviour {

	public string tagToDestroy;
	void OnTriggerEnter2D(Collider2D obj)
    {
		if (obj.tag == tagToDestroy)
		//  Destroy(obj.gameObject);
			//Recycle the object inside the object pooler
		obj.Recycle ();
    }
}
