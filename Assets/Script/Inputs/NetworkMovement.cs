using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;

public sealed class NetworkMovement : NetworkBehaviour
{
	[SerializeField]
	private Transform myCamera;
	[Header("Camera")]
	[SerializeField]
	private float height = 18f;
	[SerializeField]
	private float far = 6f;
	[Header("Movement")]
	//CAMERA
	//MOVEMENT
	[SerializeField]
	private float speed;
	[SerializeField]
	private float jumpForce;
	[SerializeField]
	private float gravity;

	private Vector3 _velocity;
	private CharacterController _characterController;
	private PlayerInput _inputActions;
	private Animator _animator;
	void Awake()
	{
		_inputActions = new PlayerInput();
	}
	public override void OnStartNetwork()
	{
		base.OnStartNetwork();

		myCamera.transform.parent = null;
		_characterController = GetComponent<CharacterController>();
		_animator = GetComponent<Animator>();

		if (!IsOwner) return;


	}
	public override void OnStartClient()
	{
		base.OnStartClient();
		myCamera.GetComponent<Camera>().enabled = IsOwner;
		myCamera.GetComponent<AudioListener>().enabled = IsOwner;
	}
	void Start()
	{

	}
	void OnEnable()
	{

		_inputActions.Enable();
	}
	void OnDisable()
	{
		_inputActions.Disable();
	}
	public override void OnStopNetwork()
	{
		base.OnStopNetwork();

	}

	void Update()
	{
		if (!IsOwner) return;



		Vector2 moveVector = _inputActions.ActionMap.Move.ReadValue<Vector2>();

		Vector3 moveDirection = new Vector3(moveVector.x, 0f, moveVector.y);

		/* 		if (moveVector.x != 0 || moveVector.y != 0)
				{
					_animator.SetBool("isMoving", true);
				}
				else
				{
					_animator.SetBool("isMoving", false);
				} */


		_characterController.Move(moveDirection * Time.deltaTime * speed);


		if (moveDirection != Vector3.zero)
		{

			gameObject.transform.forward = moveDirection;
		}



		_velocity.y -= gravity * Time.deltaTime;



		_characterController.Move(_velocity * Time.deltaTime);

	}
	void LateUpdate()
	{
		if (!IsOwner) return;

		myCamera.transform.position = Vector3.Lerp(
			myCamera.transform.position, new Vector3(transform.position.x, transform.position.y + height, transform.position.z - far), Time.deltaTime * 10f);

	}

}
