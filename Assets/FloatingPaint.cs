using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPaint : MonoBehaviour
{
	public float amplitude = 0.5f;
	public float frequency = 1f;
	Vector3 posOffset = new Vector3();
	Vector3 tempPos = new Vector3();
	// Update is called once per frame
	void Start()
	{
		posOffset = transform.position;
	}
	void Update()
	{
		tempPos = posOffset;
		tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

		transform.position = tempPos;
	}
}
