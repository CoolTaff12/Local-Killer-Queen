using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SpawnOnServer : NetworkBehaviour {
	public GameObject prefabToSpawn;
	public string objectName;

	// Use this for initialization
	void Start () {
//		objectName = gameObject.transform.name;
		if(GameObject.Find(objectName) == null){
			GameObject gots = Instantiate(prefabToSpawn, transform.position, Quaternion.identity) as GameObject;
			CmdSpawnOnServer (gots);
			gots.transform.name = objectName;
			
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	[Command]
	public void CmdSpawnOnServer(GameObject go){
		NetworkServer.Spawn(go);
	}
}
