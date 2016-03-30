using UnityEngine;
using System.Collections;

public class BasicMovement : MonoBehaviour {
	Rigidbody rb;
	public float speed = 2;
	public float jumpVel = 10;
	public bool m_IsGrounded;
	public bool jumped = true;
	public float jumpedCooldown = 1f;
	public GameObject groundRay;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			rb.velocity = transform.forward * speed;
		}
		if (Input.GetKey (KeyCode.A)) {
			var vl = transform.right;
			vl.y = 0.0f;
			vl.z = 0.0f;
			vl.Normalize();
			vl *= -Input.GetAxis("Horizontal") * speed;
			vl.y = rb.velocity.y;
			vl.z = rb.velocity.z;
			rb.velocity = vl;
		}
		if (Input.GetKey (KeyCode.S)) {
			var vb = transform.forward;
			vb.y = 0.0f;
			vb.x = 0.0f;
			vb.Normalize();
			vb *= -Input.GetAxis("Vertical") * speed;
			vb.y = rb.velocity.y;
			vb.x = rb.velocity.x;
			rb.velocity = vb;
		}
		if (Input.GetKey (KeyCode.D)) {
			var vr = transform.right;
			vr.y = 0.0f;
			vr.z = 0.0f;
			vr.Normalize();
			vr *= Input.GetAxis("Horizontal") * speed;
			vr.y = rb.velocity.y;
			vr.z = rb.velocity.z;
			rb.velocity = vr;
		}

		if (Input.GetKey (KeyCode.LeftShift) && !Input.GetKey(KeyCode.S) && m_IsGrounded){
			speed = 4;
		}
		if (Input.GetKeyUp (KeyCode.LeftShift) || Input.GetKeyDown (KeyCode.S) && m_IsGrounded) {
			speed = 2;
		}
		if (Input.GetKeyDown (KeyCode.Space) && m_IsGrounded) {
			Debug.Log ("Hopp");
			rb.velocity = new Vector3 (rb.velocity.x, jumpVel, rb.velocity.z);
			m_IsGrounded = false;
			jumped = true;
		}
		if (!m_IsGrounded) {
			CheckGrounded ();
		}
		if (jumped) {
			JumpCd ();
		}
	
	}
	public void CheckGrounded(){
		RaycastHit hit;
		float rayRadius = 1f;
		Vector3 dwn = transform.TransformDirection (Vector3.down);

		/*DEBUG*/
		//Debug.DrawRay (groundRay.transform.position, dwn, Color.green, 10f);

		if (Physics.SphereCast (transform.position, rayRadius, dwn, out hit)) {
			Debug.Log (hit.distance);
			if (hit.distance <= 0.4f && !jumped) {
				m_IsGrounded = true;
			}
		}
	}
	public void JumpCd(){
		if (jumpedCooldown > 0) {
			jumpedCooldown -= Time.deltaTime;
		} else if (jumpedCooldown <= 0) {
			jumped = false;
			jumpedCooldown = 1f;
		}
	}
}
