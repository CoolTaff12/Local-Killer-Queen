using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;

public class GrabAndToss : NetworkBehaviour
{

	RaycastHit hit;
	public float rayDistance;
	public float rayRadius;
	[SyncVar]
	public float tossForce;
	[SyncVar]
	public bool holdingBall;
	public GameObject fpc;
	public GameObject head;
	[SyncVar]
	public GameObject currentBall;
	[SyncVar]
	public GameObject holdPos;
	public DodgeBallBehaviour ballScript;

	// Use this for initialization
	void Start ()
	{
	}

	// Update is called once per frame
	void Update ()
	{
		Debug.DrawRay (head.transform.position, head.transform.forward, Color.green, rayDistance);
		if (Physics.SphereCast (head.transform.position, rayRadius, head.transform.forward, out hit, rayDistance)) {
			if (hit.collider.GetComponent<DodgeBallBehaviour> () != null) {
				print ("Ball!");
				if (Input.GetKeyDown (KeyCode.E) || CrossPlatformInputManager.GetButtonDown ("Fire1")) {
					if (!hit.collider.GetComponent<DodgeBallBehaviour> ().pickedUp) {
					currentBall = hit.collider.gameObject;
					currentBall.transform.SetParent (gameObject.transform);
					ballScript = hit.collider.gameObject.GetComponent<DodgeBallBehaviour> ();
					ballScript.GetPickedUp ();
					//ballScript.holdingPos = holdPos;
//					ballScript.pickedUp = true;
					holdingBall = true;
					}

				}
			}
		}
		if (CrossPlatformInputManager.GetButtonDown ("Fire2") && holdingBall) {
			holdingBall = false;
//			Rigidbody brb = currentBall.GetComponent<Rigidbody> ();
			currentBall.transform.parent = null;
			ballScript.Shoot ();
//			brb.AddForce(head.transform.forward * tossForce);
			ballScript = null;

		}

	}
}
