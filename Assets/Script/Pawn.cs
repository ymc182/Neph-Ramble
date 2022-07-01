using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using TMPro;
public sealed class Pawn : NetworkBehaviour
{

	[SyncVar]
	public NetworkPlayer controllingPlayer;
	[SyncVar]
	public float health;

	public void setName(string name)
	{
		GetComponentInChildren<TextMeshProUGUI>().SetText(name);
	}
	public void setPlayer(NetworkPlayer player)
	{
		controllingPlayer = player;
	}
	public void ServerTeleport(Vector3 target)
	{
		Owner.FirstObject.GetComponent<NetworkPlayer>().Teleport(target);
	}
	void Update()
	{

	}
	public void Teleport(Vector3 target)
	{
		Debug.Log("[CLIENT] Teleporting to " + target);
		CharacterController cc = GetComponent<CharacterController>();
		cc.enabled = false;
		gameObject.transform.position = target;
		cc.enabled = true;
		Debug.Log(gameObject.name + "[CLIENT] New loc " + gameObject.transform.position);
	}
}
