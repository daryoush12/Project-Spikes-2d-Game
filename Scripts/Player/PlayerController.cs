using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

// To do: Abilities.

namespace Spikes
{
    public class PlayerController : MonoBehaviour
    {
        //All Variables classified into sections:
        // Movement:
        [SerializeField]
        private float maxSpeed = 10f;
        bool facingRight = true;
        // Ability Oriented Variables:
        bool UsingAbility;
        float AbilityDuration;
        float RollingForce = 30F;
        //float AbilityFormMass = 12f;
        //GroundCheck:
        public bool grounded;
        public Transform groundCheck;
        private bool usingAbility;
        //[SerializeField]private float groundRadius = 0.3f;
        public LayerMask GroundScan;
        //Jumping
        public float JumpForce = 4700f;
        bool doublejump;
        Collision2D ColCheck;
       

        //Components:
        Rigidbody2D rigid2D;
        Animator anim;

        // Use this for initialization
        void Start()
        {
			rigid2D = GetComponent<Rigidbody2D>();
			anim = GetComponent<Animator>();
        }
        // Update is called once per frame
        void FixedUpdate()
        {
            CheckInputControl();
        }
        // Method for flipping whole world. Less work for artists:
        void Flip()
        {

            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;

        }
        void CheckInputControl()
        {

            float move = Input.GetAxis("Horizontal");
            anim.SetFloat("speed", Mathf.Abs(move));
            rigid2D.velocity = new Vector2(move * maxSpeed, rigid2D.velocity.y);
            //Checking where player is currently moving. If player moves. whole view is then flipped. (Less Animations)
            if (move > 0 && !facingRight)
            {
               Flip();
            }

            else if (move < 0 && facingRight)
            {
                Flip();
            }

			if (Input.GetButtonDown("Jump2D"))
			{
				float jumpFrc = 0f;
				if(grounded) {
					jumpFrc = JumpForce;
					Debug.Log("first jump");
				} else if (!grounded && !doublejump) {
					jumpFrc = JumpForce * 1.5f;
					doublejump = true;
					Debug.Log("Second Jump");
				}
				anim.SetBool ("Ground", grounded);
				anim.SetFloat ("VSpeed", rigid2D.velocity.y);
				rigid2D.AddForce(new Vector2(0, jumpFrc));
			}

			if (Input.GetButtonUp ("Ability_B") && !UsingAbility && grounded) {
				UsingAbility = true;
				anim.SetFloat ("SpikeRollSpeed", Mathf.Abs (RollingForce));
				rigid2D.velocity = new Vector2 (RollingForce, rigid2D.velocity.y);
			}
			//ABILITY NUMBER 3: GroundSlam
			if(Input.GetKey(KeyCode.S)) {
                UsingAbility = true;
				//Calculate slam force by adding 2x multiplier into jumpforce:
				float SlamForce = -JumpForce * 2;
				//Make sure both down arrow or s is being pressed while player is not grounded. 
				//It's critical that ground check works. Otherwise groundslam ability will not work
				if(!grounded){
					Debug.Log ("Groundslam!");
                    rigid2D.AddForce(new Vector2(0, SlamForce),ForceMode2D.Force);
                    //20.1.2017 Ability works as intended. No effects added yet.
                    //Effects:
                    if(grounded && usingAbility)
                    {
//Instantiate the effect on the slam area and enable a big collision box.  3 times size of a player.
                    }
				}
			}


        }

        //Jumping Control and Input Check:
        void OnCollisionStay2D(Collision2D coll)
        {
			if (coll.collider.tag == "Ground") {
				grounded = true;
				doublejump = false;
			}
        }

		void OnCollisionExit2D(Collision2D coll){
			if (coll.collider.tag == "Ground") {
                ColCheck = coll; 
				grounded = false;
			}
		}

        
       /* void AbilityInput()
        {
            if(Input.GetButtonUp("abilty_b") && !UsingAbility && grounded)
            
            anim.SetFloat("SpikeRollSpeed", Mathf.Abs(RollingForce));
            rigid2D.velocity = new Vector2(RollingForce, rigid2D.velocity.y);
            //Checking where player is currently moving. If player moves. whole view is then flipped. (Less Animations)
            if (RollingForce > 0 && !facingRight)
            {

                Flip();

            }

            else if (RollingForce < 0 && facingRight)
            {
                Flip();
            }

        }*/
        // Public Call Methods:
    }
}