using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player_ID : NetworkBehaviour
{
    [SyncVar]
    public string playerUniqueIdenity;
    private NetworkInstanceId playerNetID;
    private Transform myTransform;

    public override void OnStartLocalPlayer()
    {
        GetNetIdenity();
    }

    // Use this for initialization
    void Start ()
    {
        myTransform = transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(myTransform !=null)
        {
            if (myTransform.name == "Warrior(Clone)" || myTransform.name == "Warrior")
            {
                SetIdenity();
            }
        }
	}

    [Client]
    void GetNetIdenity()
    {
        playerNetID = GetComponent<NetworkIdentity>().netId;
        CmdTellServerMyIdenity(MakeUniqueIdenity());
    }

   void SetIdenity()
    {
        if(isLocalPlayer)
        {
            myTransform.name = playerUniqueIdenity;
        }
        else
        {
            myTransform.name = MakeUniqueIdenity();
        }
    }


    string MakeUniqueIdenity()
    {
        string uniqueName = "Player " + playerNetID.ToString();
        return uniqueName;
    }

    [Command]
    void CmdTellServerMyIdenity(string name)
    {
        playerUniqueIdenity = name;
    }
}
