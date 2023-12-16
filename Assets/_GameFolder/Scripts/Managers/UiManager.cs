using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NiceCreamClone.Canvases;

namespace NiceCreamClone.Managers
{
	public class UiManager : MonoBehaviour
	{
		public static UiManager Instance { get; private set; }

		[SerializeField] private InputCanvas inputCanvas;
		[SerializeField] private GameCanvas gameCanvas;
		[SerializeField] private SettingsCanvas settingsCanvas;
		private void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
			}
			else
			{
				Destroy(gameObject);
			}
		}

		public void Initialize(InputManager inputManager)
		{
			inputCanvas.Initialize(inputManager);
			gameCanvas.Initialize();
			settingsCanvas.Initialize();
		}
		void Start()
		{

		}


		void Update()
		{

		}
	}
}

