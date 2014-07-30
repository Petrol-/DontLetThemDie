using UnityEngine;
using System.Collections;

public class JumpScript : MonoBehaviour {
    [Range(0,100)]
    public float jumpVelocity;
    public Rigidbody2D character;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    [Range(0,1)]
    public float width, height;
    public EnumScreenCorners dock;
    DetectionWindow winChar;

        
    void Start()
    {
        winChar = new DetectionWindow(width, height / 2, dock);
        
    }
    void Awake()
    {
        groundCheck = transform.Find("GroundCheck");
    }
    void Update()
    {
        bool grounded = Physics2D.Linecast(transform.position, groundCheck.position, whatIsGround);
        if (Input.touchCount > 0 && grounded)
        {
            foreach(Touch touch in Input.touches){
                if(winChar.isTouchInsideWindow(touch)){
                    Jump(character);
                }
            }
        }
    }

    void Jump(Rigidbody2D c){
        c.velocity = new Vector2(c.velocity.x, jumpVelocity);
}
}
