using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;

public class AdditionalMovement : MonoBehaviour {
	public GameObject ParentFPC;
	[SerializeField]
	private bool m_IsCrouching;
	public bool m_IsRefillingStamina = false;
	public float CrouchSpeed = 3;
	public float NormalSpeed;
	public float RunningSpeed;
	public Transform tr;
	public float OnAndOff = 1;

	// Use this for initialization
	void Start () {
		NormalSpeed = ParentFPC.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_WalkSpeed;
		RunningSpeed = ParentFPC.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_RunSpeed;
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		InputtingKeys();
		//A test of Stamina in the game
		/*  if (OnAndOff > 0.02f)
        {
            InputtingKeys();
        }
        else if (OnAndOff < 0.01f)
        {
            ParentFPC.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_RunSpeed = 5f;
            m_IsRefillingStamina = true;
        }
        if (m_IsRefillingStamina == true)
        {
            Mathf.Lerp(OnAndOff, 1, 2 * Time.deltaTime);
            if(OnAndOff > 9.99f)
            {
                m_IsRefillingStamina = false;
            }
        }*/

	}

	void InputtingKeys()
	{
		if (CrossPlatformInputManager.GetButton("Crouch"))
		{ // press C to crouch
			//    vScale = 0.5f;
			ParentFPC.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_WalkSpeed = 3f;
			ParentFPC.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_RunSpeed = 6f;
			ParentFPC.transform.localScale = new Vector3(1, Mathf.Lerp(0.79f, 1, 5 * Time.deltaTime),1);
			OnAndOff -= 0.01f;
		}
		else
		{
			ParentFPC.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_WalkSpeed = NormalSpeed;
			ParentFPC.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_RunSpeed = RunningSpeed;
			ParentFPC.transform.localScale = new Vector3(1, Mathf.Lerp(1, 0.79f, 5 * Time.deltaTime), 1);
		}
	}

	/*  void DuckLerp()
    {
        switch (OnAndOff)
        {
            case 0:
                text.text = "Add Ships";
                break;
            case 1:
                text.text = "Player Selecting";
                break;
        }
    }*/
}
