using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using NiceCreamClone.Controllers;

namespace NiceCreamClone.Managers
{
	public class InputManager : MonoBehaviour
	{
		public static InputManager Instance { get; private set; }

		private CameraController _cameraController;
		public bool isInputEnabled { get; private set; } = true;
		private bool _isFirstDraging;
		private bool _isDragging;
		private Vector3 _firstTouchPosition;
		private Vector3 _lastTouchPosition;
		private void Awake()
		{
			if (Instance != null && Instance != this)
			{
				Destroy(this);
			}
			else
			{
				Instance = this;
			}
		}

		public void Initialize(CameraController cameraController)
		{
			_cameraController = cameraController;
		}

		public void OnScreenTouch(PointerEventData eventData)
		{
			if (!isInputEnabled)
			{
				return;
			}
			if (!_isDragging)
			{
				_isDragging = true;
				_firstTouchPosition = Input.mousePosition;
				_isFirstDraging = true;
			}
		}

		public void OnScreenDrag(PointerEventData eventData)
		{
			if (!isInputEnabled)
			{
				return;
			}

			if (GameManager.Instance.GameState != GameState.Playing)
			{
				return;
			}

			_lastTouchPosition = Input.mousePosition;

			float deltaY = _lastTouchPosition.y - _firstTouchPosition.y;

			_cameraController.MoveCamera(deltaY);
		}

		public void OnScreenUp(PointerEventData eventData)
		{
			_isDragging = false;
		}

	}
}


