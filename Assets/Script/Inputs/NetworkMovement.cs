using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;

public sealed class NetworkMovement : NetworkBehaviour
{
	//CAMERA
	/* 	public Camera playerCamera;

		public bool cameraEnabled = true;
		public bool initCameraOnSpawn = true;
		public string cameraName = "Main Camera";
		public Vector3 cameraPositionOffset = new Vector3(0, 10, 1);
		public Vector3 cameraRotationOffset = new Vector3(45, 0, 0);
		public float minCameraHeight = 2,
			maxCameraHeight = 15,
			minCameraVertical = 1.5f,
			maxCameraVertical = 14.5f,
			cameraZoomSpeed = 15,
			cameraZoomPower = 15,
			cameraRotateSpeed = 150f;
		private float currentCameraHeight, cameraHeightTarget, currentCameraVertical, cameraVerticalTarget; */
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

		_characterController = GetComponent<CharacterController>();
		_animator = GetComponent<Animator>();

		if (!IsOwner) return;
		/* 	InitCameraValues();
			InitCamera(); */

	}
	void OnEnable()
	{
		/* 		InitCameraValues();
				InitCamera(); */
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
	/* private void InitCamera()
	{
		if (!initCameraOnSpawn && playerCamera != null) return;
		Camera cam = GameObject.Find(cameraName).GetComponent<Camera>();
		if (cam == null)
		{
			cam = Camera.main;
			if (cam == null)
			{
				Debug.LogError("TOPDOWN_CLICK_CONTROLLER: NO CAMERA FOUND! MAKE SURE TO EITHER DRAG AND DROP ONE, OR ENABLE INIT CAMERA AND TYPE A VALID CAMERA NAME OR MAIN CAMERA TAG");
			}
			else
			{
				playerCamera = cam;
			}
		}
		else
		{
			playerCamera = cam;
		}

		if (playerCamera == null) return;
		playerCamera.transform.eulerAngles = cameraRotationOffset;
		InstantCameraUpdate();
	} */
	void Update()
	{
		if (!IsOwner) return;
		/* 	if (playerCamera != null)
				CameraLogic(); */


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
		/* 	if (playerCamera != null)
				HandleCamera(); */
	}
	/* 	#region CAMERA
		private void InitCameraValues()
		{
			currentCameraHeight = cameraPositionOffset.y;
			cameraHeightTarget = currentCameraHeight;
			currentCameraVertical = cameraPositionOffset.z;
			cameraVerticalTarget = currentCameraVertical;
		}


		void InstantCameraUpdate()
		{
			Vector3 targetPos = transform.position - (playerCamera.transform.forward * currentCameraHeight);
			targetPos.z -= currentCameraVertical;
			playerCamera.transform.position = targetPos;
		}

		private void CameraInputs()
		{
			HandleCameraZoom();
		}

		private void HandleCameraZoom()
		{
			if (Input.mouseScrollDelta.y == 0) return;
			float heightDifference = Input.mouseScrollDelta.y < 0f ? cameraZoomPower : -cameraZoomPower;
			cameraHeightTarget = currentCameraHeight + heightDifference;
			cameraVerticalTarget = currentCameraVertical + heightDifference;
			if (cameraHeightTarget > maxCameraHeight) cameraHeightTarget = maxCameraHeight;
			else if (cameraHeightTarget < minCameraHeight) cameraHeightTarget = minCameraHeight;
			if (cameraVerticalTarget > maxCameraVertical) cameraVerticalTarget = maxCameraVertical;
			else if (cameraVerticalTarget < minCameraVertical) cameraVerticalTarget = minCameraVertical;
		}

		private void HandleCamera()
		{

			playerCamera.transform.position = (transform.position + Vector3.up * 0.8f) - (playerCamera.transform.forward * currentCameraHeight);
		}

		private void LerpCameraHeight()
		{
			currentCameraHeight = Mathf.Lerp(currentCameraHeight, cameraHeightTarget, Time.deltaTime * cameraZoomSpeed);
			currentCameraVertical = Mathf.Lerp(currentCameraVertical, cameraVerticalTarget, Time.deltaTime * cameraZoomSpeed);
		}
		private void CameraLogic()
		{
			if (!cameraEnabled) return;
			CameraInputs();
			LerpCameraHeight();
		}
		#endregion */
}
