using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NiceCreamClone.Managers;

namespace NiceCreamClone.Controllers
{
	public class PlayerController : MonoBehaviour
	{
		public GameObject playerPrefab;
		public Vector3 playerStartPosition;
		public void Initialize()
		{
			Debug.Log("Player initialized!");
		}

		private void OnEnable()
		{
			GameManager.OnGameStarted += OnGameStart;
		}

		private void OnDisable()
		{

			GameManager.OnGameStarted -= OnGameStart;
		}

		private void OnGameStart()
		{
			CreatePlayer(playerStartPosition);
		}

		private void CreatePlayer(Vector3 startPosition)
		{
			var player = Instantiate(playerPrefab, startPosition, Quaternion.identity);
		}
	}
}

