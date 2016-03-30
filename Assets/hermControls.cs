using UnityEngine;
using System.Collections;

public class hermControls : MonoBehaviour 
{
	public Animator anim;
	public float speed = 10.0F; 
	public float rotationSpeed = 100.0F; 
	public testThrowBall testTB;

	void Start ()
	{
		anim = GetComponent<Animator>();
//		testTB.GetComponent<testThrowBall>();
	}

	void Update () 
	{ 
		float translation = Input.GetAxis("Vertical") * speed; 
		float rotation = Input.GetAxis("Horizontal") * rotationSpeed; 
		translation *= Time.deltaTime;
		rotation *= Time.deltaTime; 
		transform.Translate(0, 0, translation); 
		transform.Rotate(0, rotation, 0);

		if(Input.GetButtonDown("Jump"))
		{
			anim.SetTrigger("isJumping");
		}


		if (Input.GetButtonDown("Throw"))
		{
			anim.SetTrigger("isThrowing");
//			testTB.ThrowBall();


		}


		if (translation != 0)
		{
			anim.SetBool("isJogging", true);
			anim.SetBool("isIdle", false);
		}
		else
		{
			anim.SetBool("isJogging", false);
			anim.SetBool("isIdle", true);
		}

	}
}
