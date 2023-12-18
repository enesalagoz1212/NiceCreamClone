using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NiceCreamClone.Managers;

namespace NiceCreamClone.Controllers
{
	public enum CustomerState
	{
		Idle,               // Hareketsiz durum
		GoingToIceCreamStand,   // Dondurma tezgahýna gitme durumu
		GoingToTargetPoint      // Hedef noktaya gitme durumu
	}
	public class Customer : MonoBehaviour
	{

		private LevelManager _levelManager;
		private Player _player;
		private NavMeshAgent _navMeshAgent;
		private CustomerState _currentState = CustomerState.Idle;

		private bool _isGoingToIceCreamStand = false;
		public void Initialize(LevelManager levelManager, Player player)
		{
			_levelManager = levelManager;
			_player = player;
		}
		void Start()
		{
			_navMeshAgent = GetComponent<NavMeshAgent>();

		}

		private void Update()
		{
			SetDestination();
		}

		private void SetDestination()
		{
			if (GameManager.Instance.GameState==GameState.Playing)
			{
				if (_currentState == CustomerState.Idle)
				{
					SetDestinationToRandomStand();
					CheckIfAtIceCreamStand();
					_currentState = CustomerState.GoingToIceCreamStand;
				}
				else if (_currentState == CustomerState.GoingToIceCreamStand &&
						 !_navMeshAgent.pathPending && _navMeshAgent.remainingDistance < 0.1f)
				{
					SetDestinationToRandomTargetPoint();
					_currentState = CustomerState.GoingToTargetPoint;
				}
			}
			
		}


		private void SetDestinationToRandomStand()
		{
			Transform randomStand = LevelManager.Instance.GetRandomIceCreamStandPosition();
			_navMeshAgent.SetDestination(randomStand.position);
		}

		private void SetDestinationToRandomTargetPoint()
		{
			Transform randomTargetPoint = LevelManager.Instance.GetRandomTargetPointPosition();
			_navMeshAgent.SetDestination(randomTargetPoint.position);
		}

		private void CheckIfAtIceCreamStand()
		{
			// Eðer müþteri stand noktasýna ulaþmýþsa, kasiyere bilgi gönder
			if (_currentState == CustomerState.GoingToTargetPoint &&
				!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance < 0.1f)
			{
				_player.NotifyCustomerAtIceCreamStand();
			}
		}

	}

}
