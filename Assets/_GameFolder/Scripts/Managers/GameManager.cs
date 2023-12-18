using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NiceCreamClone.Controllers;

namespace NiceCreamClone.Managers
{
	public enum GameState
	{
		Start = 1,                // Oyun baþladý
		Playing = 2,             // oynuyor 
		TheGameClose = 3,       // oyun kapandý
	}
	public class GameManager : MonoBehaviour
	{
		public static GameManager Instance { get; private set; }
		public GameState GameState { get; set; }

		public static Action OnGameStarted;
		public static Action<int> OnGoldScored;
		public static Action<int> OnDiamondScored;

		[SerializeField] private PlayerController playerController;
		[SerializeField] private LevelManager levelManager;
		[SerializeField] private UiManager uiManager;
		[SerializeField] private InputManager inputManager;
		[SerializeField] private CameraController cameraController;
		[SerializeField] private CustomerController customerController;
		[SerializeField] private Customer customer;
		[SerializeField] private Player player;
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

		private void Start()
		{
			GameInitialize();
		}

		private void GameInitialize()
		{
			playerController.Initialize();
			levelManager.Initialize(customer);
			uiManager.Initialize(inputManager);
			inputManager.Initialize(cameraController);
			cameraController.Initialize();
			customerController.Initialize(levelManager);
			customer.Initialize(levelManager,player);
			player.Initialize();

			ChangeState(GameState.Start);
		}

		public void PlayGame()
		{
			ChangeState(GameState.Playing);
		}
		public void ChangeState(GameState gameState)
		{
			GameState = gameState;
			Debug.Log($"Game State:{gameState}");
			switch (GameState)
			{
				case GameState.Start:
					OnGameStarted?.Invoke();
					break;
				case GameState.Playing:
					
					break;
				case GameState.TheGameClose:
					break;

					break;
			}
		}
	}

}
