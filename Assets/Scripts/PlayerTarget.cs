using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerTarget : NetworkBehaviour {
	public int teamNumber;
	public float health = 1f;
    public int killed = 1;
	public bool killable = true;
	public bool dead = false;
	public Transform[] Bodyparts;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0 && !dead) {
			RemoveChild ();
			dead = true;
		}	
	}
	public void RemoveChild(){
		foreach (Transform bpart in Bodyparts){
//			Destroy (bpart.gameObject);
			Rigidbody rb = bpart.GetComponent<Rigidbody> ();
			bpart.parent = null;
			rb.isKinematic = false;  	
		}
        if(killed == 1)
        {
            Bodyparts[0].gameObject.AddComponent<AudioSource>();
            Bodyparts[0].gameObject.AddComponent<DodgeBallScript>();
            Bodyparts[0].gameObject.GetComponent<DodgeBallScript>().playerInfo = null;
            killed = 0;
        }
    }
}