using UnityEngine;
using System.Collections;

public class JumpScript : MonoBehaviour {

    public Rigidbody2D character;
    public LayerMask whatIsGround;
    public LayerMask detectionLayer;
    public Transform groundCheck;

	//Run speed so the jump does not disturb the x speed
	private float runSpeed;

    void Awake()
    {
        groundCheck = transform.Find("GroundCheck");
		RunControllerPrefs prefs = GameObject.FindObjectOfType<RunControllerPrefs> ();
		runSpeed = prefs.runSpeed;
		prefs = null;
    }
    
  public  void Jump(float jumpVelocity)
    {
		character.velocity = new Vector2(runSpeed, jumpVelocity);
    }

  public bool isGrounded()
  {

      return (Physics2D.Linecast(transform.position, groundCheck.position, whatIsGround));
  }

  public bool isBeingTouched(Touch touch)
  {
      Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));
      return Physics2D.Linecast(touchPos, touchPos,detectionLayer);
      
  }
}
