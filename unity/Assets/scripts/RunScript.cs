using UnityEngine;
using System.Collections;

public class RunScript : MonoBehaviour {

    public Rigidbody2D characher;
    [Range(0,100)]
    public float speed;


    void FixedUpdate()
    {
        characher.velocity = new Vector2(speed, characher.velocity.y);
    }
}
