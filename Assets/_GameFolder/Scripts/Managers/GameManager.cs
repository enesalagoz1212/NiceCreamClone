using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NiceCreamClone.Managers
{
    public enum GameState
	{

	}
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public GameState GameState { get; set; }

        void Start()
        {

        }

       
        void Update()
        {

        }
    }

}
