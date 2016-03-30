using UnityEngine;
using UnityStandardAssets.Utility;
using System.Collections;

public class TrampScript : MonoBehaviour
{

    public float manualforce;
    public PlayerTarget playerInfo;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController warriorInfo;
    [SerializeField]
    private LerpControlledBob Force = new LerpControlledBob();
    public Rigidbody rb;
    private float startTime;


    public GameObject Warrior;
    Vector3 Before;
    Vector3 After;
    float NewPosition;

    // Use this for initialization
    void Start ()
    {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Warrior != null)
        {
            NewPosition = Warrior.transform.position.y + manualforce;
            After = new Vector3(Warrior.transform.position.x, NewPosition, Warrior.transform.position.z);
            float fracComplete = (Time.time - startTime) / 1.0f;
            Warrior.transform.position = Vector3.Lerp(Before, After, fracComplete);
            if(Warrior.transform.position.y > manualforce)
            {
                Warrior = null;
                //Warrior.transform.position = Vector3.Lerp(After, Before, (fracComplete / 2));
            }
          //  Warrior = null;
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Before = col.gameObject.transform.position;
            Warrior = col.gameObject;





            /*  = new Vector3(col.gameObject.transform.position.x,
              Mathf.Lerp(col.gameObject.transform.position.y, NewPosition, 50 * Time.deltaTime),
              col.gameObject.transform.position.z);
          manualforce--;*/
            //playerInfo = col.gameObject.GetComponent<PlayerTarget>();
            // warriorInfo = col.gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
            /*    Vector3 velocity = col.gameObject.GetComponent<Rigidbody>().velocity;
                rb = col.gameObject.GetComponent<Rigidbody> ();
                rb.velocity = new Vector3(rb.velocity.x, manualforce, rb.velocity.z);*/
            //   rb.AddForce(col.gameObject.transform.up * manualforce);         
        }
    }
}
