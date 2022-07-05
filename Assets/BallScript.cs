using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
	Rigidbody rb;
	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{

	}
	void OnCollisionStay(Collision other)
	{
		if (other.gameObject.tag == "Player")
		{
			Debug.Log("Hit");
			Vector3 direction = (other.transform.position - transform.position).normalized;
			GetComponent<Rigidbody>().AddForce(-direction * 10, ForceMode.Impulse);
		}
	}
}
