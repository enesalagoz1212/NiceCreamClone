using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NiceCreamClone.Managers;

namespace NiceCreamClone.Canvases
{
    public class GameCanvas : MonoBehaviour
    {
        public Image iceCreamStandPanel;
		public Button openButton;
        public void Initialize()
		{
			openButton.onClick.AddListener(OnOpenButtonClick);
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
			iceCreamStandPanel.gameObject.SetActive(true);
		}

		private void OnOpenButtonClick()
		{
			iceCreamStandPanel.gameObject.SetActive(false);
			GameManager.Instance.PlayGame();
		}

	}

}
