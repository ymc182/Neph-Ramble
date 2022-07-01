using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet;

public class ConnectionManager : MonoBehaviour
{

	void Start()
	{
		if (SystemInfo.graphicsDeviceName == null)
		{
			InstanceFinder.ServerManager.StartConnection();
		}
	}
	public void onHostClick()
	{
		InstanceFinder.ServerManager.StartConnection();
		InstanceFinder.ClientManager.StartConnection();
	}
	public void onJoinClick()
	{
		InstanceFinder.ClientManager.StartConnection();
	}

}
