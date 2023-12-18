using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NiceCreamClone.Controllers;

namespace NiceCreamClone.Managers
{
	public class LevelManager : MonoBehaviour
	{
		public static LevelManager Instance { get; private set; }

		private Customer _customer;

		public GameObject playerPrefab;
		public GameObject customerPrefab;


		public Vector3 playerSpawnPosition;
		public Transform customerTransform;
		public Transform playerTransform;

		public Transform[] iceCreamStandPositions; 
		public Transform[] targetPointPositions;


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
		public void Initialize(Customer customer)
		{
			_customer = customer;

			CreateIceCreamStandPositions();
			CreateTargetPointPositions();
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
			SpawnPlayer();
			StartCoroutine(SpawnCustomersPeriodically());
		}



		private void SpawnPlayer()
		{
			Instantiate(playerPrefab, playerSpawnPosition, Quaternion.identity, playerTransform);
		}

		private void SpawnCustomer()
		{

			Vector3 customSpawnPos = GetRandomSpawnPosition();
			Instantiate(customerPrefab, customSpawnPos, Quaternion.identity, customerTransform);
		}

		private IEnumerator SpawnCustomersPeriodically()
		{
			while (true)
			{
				SpawnCustomer();
				yield return new WaitForSeconds(50f);
			}
		}

		private Vector3 GetRandomSpawnPosition()
		{
			return new Vector3(Random.Range(-20, -10), 1.3f, Random.Range(3, 9));
		}

		private void CreateTargetPointPositions()
		{
			targetPointPositions = new Transform[6];

			for (int i = 0; i < 6; i++)
			{
				Vector3 targetPoint = new Vector3(Random.Range(15, 20), 1.3f, Random.Range(3, 9));

				targetPointPositions[i] = new GameObject("TargetPoint" + (i + 1)).transform;
				targetPointPositions[i].position = targetPoint;
			}
		}

		private void CreateIceCreamStandPositions()
		{
			iceCreamStandPositions = new Transform[1];

			Vector3 stand1 = new Vector3(-1.5f, 1.3f, 1.57f);
			//Vector3 stand2 = new Vector3(0f, 1.3f, 1.57f);
			//Vector3 stand3 = new Vector3(1.5f, 1.3f, 1.57f);

			
			iceCreamStandPositions[0] = new GameObject("Stand1").transform;
			iceCreamStandPositions[0].position = stand1;

			//iceCreamStandPositions[1] = new GameObject("Stand2").transform;
			//iceCreamStandPositions[1].position = stand2;

			//iceCreamStandPositions[2] = new GameObject("Stand3").transform;
			//iceCreamStandPositions[2].position = stand3;
		}

		public Transform GetRandomIceCreamStandPosition()
		{
			int randomIndex = Random.Range(0, iceCreamStandPositions.Length);
			return iceCreamStandPositions[randomIndex];
		}
		public Transform GetRandomTargetPointPosition()
		{
			int randomTargetIndex = Random.Range(0, targetPointPositions.Length);
			return targetPointPositions[randomTargetIndex];
		}

		
	}
}

