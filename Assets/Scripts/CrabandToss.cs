using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;
using UnityEngine.Networking;

public class CrabandToss : NetworkBehaviour
{
    public int team;
    public GameObject GrabBall;
    public GameObject TossBall;
    public bool GotTheBall;
   /* private bool m_Grab;
    private bool m_Shoot;*/
    public float speed;
    public GameObject head;

    public GameObject Marker;
	//    private GameObject Cam;
    Ray ray;
    Camera Aim;
    public AudioClip[] audioClips;


    //-----------------Play Audio------------------------
    //This will take the gameobjects AudioSource to switch the audioclips
    public void PlaySound(int clip)
    {
        GetComponent<AudioSource>().clip = audioClips[clip];
        GetComponent<AudioSource>().Play();
    }

    // Use this for initialization
    void Start ()
    {
//       Marker = GameObject.Find("Shoot it,");
//       Cam = GameObject.Find("FirstPersonCharacter");
     //  Aim = Cam;
       GrabBall.SetActive(false);
        if(team == 1)
        {

        }
        else
        {

        }
    }
	
	// Update is called once per frame
	void Update ()
    {
      //  ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (GotTheBall == true)
        {
            ShootBall();
        }
     /*   // the shoot state needs to read here to make sure it is not missed
        if (!m_Grab)
        {
            m_Grab = CrossPlatformInputManager.GetButtonDown("Fire1");
        }
        if (!m_Shoot)
        {
            m_Shoot = CrossPlatformInputManager.GetButtonDown("Fire2");
        }*/

    }


    void ShootBall()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire2"))
        {
            GrabBall.SetActive(false);
            /*Vector3 Distance = new Vector3(transform.position.x, transform.position.y + 0.8f,
                                                                 transform.position.z + 1.4f);
            Quaternion Direction = new Quaternion(transform.rotation.x, transform.rotation.y - 180f,
                                                                    transform.rotation.z);*/
			GameObject SpeedingBall = Instantiate(TossBall, Marker.transform.position, Quaternion.identity) as GameObject;
			CmdSpawnOnServer(SpeedingBall);
            SpeedingBall.GetComponent<Renderer>().material = GrabBall.GetComponent<Renderer>().material;
        //  SpeedingBall.GetComponent<Renderer>().material.SetTexture = 
            Rigidbody rb = SpeedingBall.GetComponent<Rigidbody>();
            rb.AddForce(head.transform.forward * speed);
         //   instantiatedBall.AddForce(instantiatedBall.transform.forward * speed);

            GotTheBall = false;
        }
    }
	[Command]
	public void CmdSpawnOnServer(GameObject go){
		NetworkServer.Spawn(go);
	}

}
