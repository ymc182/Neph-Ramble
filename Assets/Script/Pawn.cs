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
}
