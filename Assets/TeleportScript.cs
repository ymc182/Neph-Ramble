using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
	public Transform teleportTarget;


	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<Pawn>().IsOwner)
		{
			other.GetComponent<Pawn>().Teleport(teleportTarget.position);
		}
	}
}
