using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using FishNet.Object;
using FishNet.Object.Synchronizing;
public sealed class GameManager : NetworkBehaviour
{
	public static GameManager Instance { get; private set; }
	[SyncObject]
	public readonly SyncList<NetworkPlayer> players = new SyncList<NetworkPlayer>();
	[SyncVar]
	public bool canStartRamble = false;
	private void Awake()
	{
		Instance = this;
	}
	void Update()
	{
		if (!IsServer) return;
		canStartRamble = players.All(p => p.isReady);

	}
	[Server]
	public void StartGame()
	{
		foreach (NetworkPlayer player in players)
		{
			player.StartGame();
		}
	}
	[Server]
	public void EndGame()
	{
		foreach (NetworkPlayer player in players)
		{
			player.EndGame();
		}
	}
}
