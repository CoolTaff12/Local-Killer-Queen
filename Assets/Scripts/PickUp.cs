using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;

public class PickUp : NetworkBehaviour {
	RaycastHit hit;
	public float rayDistance;
	public float rayRadius;
	public GameObject currentBall;
	public CrabandToss crab;
    public float OnAndOff = 1;

    // Use this for initialization
    void Start () {
		crab = gameObject.GetComponent<CrabandToss> ();

    }
	
	// Update is called once per frame
	void Update () {
		if (Physics.SphereCast (transform.position, rayRadius,  transform.forward, out hit, rayDistance)) {
			if(hit.collider.GetComponent<DodgeBallScript>() != null){
				print ("Ball!");
				if(Input.GetKeyDown(KeyCode.E) || CrossPlatformInputManager.GetButtonDown("Fire1"))
                {
					currentBall = hit.collider.gameObject;
					crab.GrabBall.SetActive(true);
					crab.GrabBall.GetComponent<Renderer>().material = currentBall.GetComponent<Renderer>().material;
                    //Changes the balls material to the material the player caught.
                 //   crab.GrabBall.renderer
                    //crab.GrabBall.renderer.material.mainTexture = 
					CmdDestroyOnNetwork(currentBall);
					crab.GotTheBall = true;

				}
			}
		}
    }



	[Command]
	public void CmdDestroyOnNetwork(GameObject go){
		NetworkServer.Destroy (go);
	}

}
