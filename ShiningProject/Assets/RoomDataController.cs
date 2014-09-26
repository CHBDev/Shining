using UnityEngine;
using System.Collections;

public class RoomDataController : MonoBehaviour
{

		private MainNavigationController.MovementDirections[] myMovementDirections;

		public GameObject
				EnemyRow1Slot01;

		public GameObject
				EnemyRow1Slot02;

		public GameObject
				EnemyRow1Slot03;

		public GameObject
				EnemyRow1Slot04;

		public GameObject
				EnemyRow1Slot05;

		public GameObject
				EnemyRow2Slot01;

		public GameObject
				EnemyRow2Slot02;

		public GameObject
				EnemyRow2Slot03;

		public GameObject
				EnemyRow2Slot04;

		public GameObject
				EnemyRow2Slot05;

		public GameObject
				EnemyRow3Slot01;

		public GameObject
				EnemyRow3Slot02;

		public GameObject
				EnemyRow3Slot03;

		public GameObject
				EnemyRow3Slot04;

		public GameObject
				EnemyRow3Slot05;


		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void setRoomData (MainNavigationController.MovementDirections[] theDirections)
		{
				myMovementDirections = theDirections;
		}

		public MainNavigationController.MovementDirections[] getMovementDirectionsFromRoom ()
		{
				return myMovementDirections;
		}

}
