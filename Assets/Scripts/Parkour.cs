using UnityEngine;
using System.Collections;

public class Parkour : MonoBehaviour {

	private readonly int RIGHT_MIDDLE = 0;
	private readonly int RIGHT_LOW = 1;
	private readonly int LEFT_MIDDLE = 2;
	private readonly int LEFT_LOW = 3;
	private readonly int FRONT_HIGH = 4;
	private readonly int FRONT_X_HIGH = 5;

	private readonly int NO_HASH = 0;




	public GameObject[] rayPoints;
//	RayBox s_RB;

	// Use this for initialization
	void Start () {
		SetIds();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.B)) {
			foreach (GameObject go in rayPoints) {
				go.GetComponent<RayBox>().CastRays();
			}
			CompareRayHits ();
		}
	}
	public void SetIds(){
		rayPoints[RIGHT_MIDDLE].GetComponent<RayBox>().BoxID = RIGHT_MIDDLE;
		rayPoints[RIGHT_LOW].GetComponent<RayBox>().BoxID = RIGHT_LOW;
		rayPoints[LEFT_MIDDLE].GetComponent<RayBox>().BoxID = LEFT_MIDDLE;
		rayPoints[LEFT_LOW].GetComponent<RayBox>().BoxID = LEFT_LOW;
		rayPoints[FRONT_HIGH].GetComponent<RayBox>().BoxID = FRONT_HIGH;
		rayPoints[FRONT_X_HIGH].GetComponent<RayBox>().BoxID = FRONT_X_HIGH;
	}
	public void CompareRayHits(){
		if (CompareRay(RIGHT_MIDDLE, RIGHT_LOW)) {
			Debug.Log ("RightJump");
		}

		if (CompareRay(LEFT_MIDDLE, LEFT_LOW)) {
			Debug.Log ("LeftJump");
		}
			
		if (rayPoints [FRONT_HIGH].GetComponent<RayBox> ().TargetHash != NO_HASH && rayPoints [FRONT_X_HIGH].GetComponent<RayBox> ().TargetHash == NO_HASH) {
			Debug.Log ("FrontClimb");
		}
	}
	private bool CompareRay(int index_a, int index_b){
		return (rayPoints [index_a].GetComponent<RayBox> ().TargetHash == rayPoints [index_b].GetComponent<RayBox> ().TargetHash && rayPoints [index_b].GetComponent<RayBox> ().TargetHash != 0);
	}

}
