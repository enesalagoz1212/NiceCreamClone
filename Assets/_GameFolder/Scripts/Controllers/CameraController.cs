using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NiceCreamClone.Controllers
{
	public class CameraController : MonoBehaviour
	{
		public void Initialize()
		{

		}

		public void MoveCamera(float deltaY)
		{
			Vector3 cameraPosition = transform.position;
			float moveSpeed = 0.2f;
			float maxDistance = 2f;
			float minDistance = -7f; 
			cameraPosition.z = Mathf.Clamp(cameraPosition.z + deltaY * moveSpeed * Time.deltaTime, minDistance, maxDistance);
			transform.position = cameraPosition;
		}
	}
}
