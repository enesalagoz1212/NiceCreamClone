using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NiceCreamClone.Managers;

namespace NiceCreamClone.Canvases
{
    public class GameCanvas : MonoBehaviour
    {

		public GameObject standPrefab2;
		public Image iceCreamStandPanel;
		public Image startImage;
		public Image iceCreamImage;
		public Button openButton;
		public Button standStartButton;
		public Button saleButton;
        public void Initialize()
		{
			openButton.onClick.AddListener(OnOpenButtonClick);
			standStartButton.onClick.AddListener(OnStandButtonClick);
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
			startImage.gameObject.SetActive(true);

			GameManager.Instance.PlayGame();
		}

		private void OnStandButtonClick()
		{
			Debug.Log("StandButton");
			startImage.gameObject.SetActive(false);
			SpawnIceCreamStand();
			iceCreamImage.gameObject.SetActive(true);
		}

		private void SpawnIceCreamStand()
		{
			var SpawnStand = Instantiate(standPrefab2, new Vector3(-1.5f, 1.1f, -4.5f), Quaternion.identity);
		}
	}

}
