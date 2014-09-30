using UnityEngine;
using System.Collections;

public class RoomDataController : MonoBehaviour
{

		private MainNavigationController.MovementDirections[] myMovementDirections;

		public EnemyPrefabHolderController.EnemyArtType
				EnemyRow1Slot01;

		public EnemyPrefabHolderController.EnemyArtType
				EnemyRow1Slot02;

		public EnemyPrefabHolderController.EnemyArtType
				EnemyRow1Slot03;

		public EnemyPrefabHolderController.EnemyArtType
				EnemyRow1Slot04;

		public EnemyPrefabHolderController.EnemyArtType
				EnemyRow1Slot05;

		public EnemyPrefabHolderController.EnemyArtType
				EnemyRow2Slot01;

		public EnemyPrefabHolderController.EnemyArtType
				EnemyRow2Slot02;

		public EnemyPrefabHolderController.EnemyArtType
				EnemyRow2Slot03;

		public EnemyPrefabHolderController.EnemyArtType
				EnemyRow2Slot04;

		public EnemyPrefabHolderController.EnemyArtType
				EnemyRow2Slot05;

		public EnemyPrefabHolderController.EnemyArtType
				EnemyRow3Slot01;

		public EnemyPrefabHolderController.EnemyArtType
				EnemyRow3Slot02;

		public EnemyPrefabHolderController.EnemyArtType
				EnemyRow3Slot03;

		public EnemyPrefabHolderController.EnemyArtType
				EnemyRow3Slot04;

		public EnemyPrefabHolderController.EnemyArtType
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
