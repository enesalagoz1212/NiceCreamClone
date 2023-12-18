using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NiceCreamClone.Managers;

namespace NiceCreamClone.Controllers
{
	public class PlayerController : MonoBehaviour
	{

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
			
		}

		
	}
}

