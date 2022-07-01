using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;
using FishNet.Object.Synchronizing;

public class NetworkPlayer : NetworkBehaviour
{
	public GameObject PawnPrefab;
	[SyncVar]
	public string username;
	[SyncVar]
	public bool isReady;
	[SyncVar]
	public Pawn controlledPawn;

	private GameObject _connectBtn;


	public override void OnStartServer()
	{
		base.OnStartServer();
		GameManager.Instance.players.Add(this);
	}
	public override void OnStopServer()
	{
		base.OnStopServer();
		GameManager.Instance.players.Remove(this);
	}

	void Update()
	{
		if (!IsOwner) return;

	}

	public void StartGame()
	{

	}
	public override void OnStartClient()
	{
		base.OnStartClient();
		if (!IsOwner) return;
		username = GameObject.FindObjectOfType<NearWalletHandler>().walletAddress;
		if (username == "")
		{
			username = "Guest";
		}
		ServerSpawnPawn(username);
		_connectBtn = GameObject.Find("ClientConnectBtn");
		_connectBtn.SetActive(false);
	}
	public override void OnStopClient()
	{
		base.OnStopClient();
		if (!IsOwner) return;
		if (_connectBtn != null)
		{
			_connectBtn.SetActive(true);
		}

	}
	public void EndGame()
	{
		if (controlledPawn != null && controlledPawn.IsSpawned)
		{
			controlledPawn.Despawn();
		}
	}
	[ServerRpc]
	public void Teleport(Vector3 position)
	{
		Debug.Log("[SERVER] Teleporting ");
		ObsTeleport(controlledPawn, position);
	}
	[ObserversRpc(BufferLast = true)]
	private void ObsTeleport(Pawn pawn, Vector3 position)
	{
		pawn.Teleport(position);
	}
	[ServerRpc]
	private void ServerSetIsReady(bool value)
	{
		isReady = value;
	}
	[ServerRpc]
	private void ServerSpawnPawn(string name)
	{
		if (controlledPawn == null)
		{
			GameObject pawnInstance = Instantiate(PawnPrefab, transform.position, Quaternion.identity);
			Spawn(pawnInstance, Owner);
			controlledPawn = pawnInstance.GetComponent<Pawn>();

			ObsSetName(controlledPawn, name);
		}
	}
	[ObserversRpc(BufferLast = true)]
	private void ObsSetName(Pawn pawn, string name)
	{
		pawn.setName(name);
	}
}
