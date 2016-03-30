using UnityEngine;
using System.Collections;

public class RayBox : MonoBehaviour
{
	private GameObject targetObject;
	private int targetHash;
	private int boxId = 0;


	public GameObject TargetObject{
		get{
			return targetObject;
		}
		set{
			Debug.Log ("Error 666: Can't touch this!\nTarget object can not be assigned a new value!");
		}
	}
	public int TargetHash{
		get{
			return targetHash;
		}
		set{
			Debug.Log ("Error 666: Can't touch this!\nTarget hash can not be assigned a new value!");
		}
	}
	public int BoxID{
		get{
			return boxId;
		}
		set{
			boxId = value;
		}
	}

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	public void CastRays ()
	{
		RaycastHit hit;
		Vector3 fwd = transform.TransformDirection (Vector3.forward);

/*DEBUG*/	Debug.DrawRay (transform.position, fwd, Color.green, 10f);

		if (Physics.Raycast (transform.position, fwd, out hit) && hit.distance <= 1f) {
			targetObject = hit.transform.gameObject;
			targetHash = hit.transform.gameObject.GetHashCode ();
			//Debug.Log ("id: " + boxId + "\nHash " + targetHash);
/*DEBUG*/		//Debug.Log("id: " + boxId + " - " + hit.transform.gameObject.name);
		} else {
			targetHash = 0;
			targetObject = null;
		}

	}
}
