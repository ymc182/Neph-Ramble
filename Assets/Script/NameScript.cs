using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameScript : MonoBehaviour
{
	Transform gameObjectTransform;

	void Start()
	{
		gameObjectTransform = transform;
	}
	// Update is called once per frame
	void Update()
	{


		var lookPos = transform.position - new Vector3(gameObjectTransform.position.x, gameObjectTransform.position.x, gameObjectTransform.position.z + 100);


		var rotation = Quaternion.LookRotation(lookPos);
		rotation.x = 60;
		transform.rotation = rotation;
	}
}
