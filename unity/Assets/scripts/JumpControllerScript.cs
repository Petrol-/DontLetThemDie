using UnityEngine;
using System.Collections;

public class JumpControllerScript : MonoBehaviour {
   
	[Range(0,20)]
    public float jumpVelocity;
    public JumpScript[] pJump;
	private AudioManager audioManager;
    
	void Awake(){
		audioManager = AudioManager.instance;
		}
    void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                foreach (JumpScript play in pJump)
                {
                    if (play.isBeingTouched(touch) && play.isGrounded())
                    {
                        play.Jump(jumpVelocity);
						audioManager.PlayJumpSound();
                    }
                }
            }
        }
    }
}
