using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HermansPlayerController : MonoBehaviour
{

    public float speed = 18;

    public float turnSpeed = 60;

    private Rigidbody rig;


    // Use this for initialization
    void Start()
    {
        rig = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        float rStickX = Input.GetAxis("X360_RStickX");

        Vector3 movement = transform.TransformDirection(new Vector3(hAxis, 0, vAxis) * speed * Time.deltaTime);

        rig.MovePosition(transform.position + movement);

        Quaternion rotation = Quaternion.Euler(new Vector3(0, rStickX, 0) * turnSpeed * Time.deltaTime);

        transform.Rotate(new Vector3(0, rStickX, 0) * turnSpeed * Time.deltaTime);
    }
}
