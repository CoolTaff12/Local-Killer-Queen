using UnityEngine;
using System.Collections;

public class testThrowBall : MonoBehaviour 
{
	public GameObject ballPrefab;
	public float ballSpeed = 20;
	public Transform spawnPoint;
	public hermControls hermCtrlz;

	// Use this for initialization
	void Start () 
	{
//		hermCtrlz.GetComponent<hermControls>().enabled;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButtonDown("Throw"))
		{
			ThrowBall();
		}


	}

	public void ThrowBall()
	{
		GameObject ballClone = Instantiate(ballPrefab, transform.position, transform.rotation) as GameObject;

		Rigidbody rb = ballClone.GetComponent<Rigidbody>();
		rb.AddForce(ballClone.transform.forward * ballSpeed);

		Destroy(ballClone.gameObject, 3);
	}
}
