using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet;
public class ConnectionManager : MonoBehaviour
{
	void Start()
	{
		InstanceFinder.ServerManager.StartConnection();
		InstanceFinder.ClientManager.StartConnection();
	}
}
