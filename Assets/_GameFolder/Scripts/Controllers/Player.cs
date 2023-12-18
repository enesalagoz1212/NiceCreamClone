using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace NiceCreamClone.Controllers
{
	public class Player : MonoBehaviour
	{
		private NavMeshAgent _navMeshAgent;

		public void Initialize()
		{

			_navMeshAgent = GetComponent<NavMeshAgent>();
		}
		void Start()
		{
		}

		void Update()
		{

		}

		public void MoveToIceCreamStandPosition()
		{
			_navMeshAgent.SetDestination(new Vector3(-1.35f, 1.3f, -1.5f));
		}

		public void NotifyCustomerAtIceCreamStand()
		{
			MoveToIceCreamStandPosition();

		}
	}
}

