using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomHolderController : MonoBehaviour
{
	
		
		public GameObject myRoomArtPrefab;
		public GameObject myRoomDataPrefab;
	
		[HideInInspector]
		public GameObject
				myRoomArtObject;

		[HideInInspector]
		public RoomDataController
				myRoomDataController;

		public enum RoomDifficultyMod
		{
				DEFAULT,
				EASIEST,
				EASIER,
				NORMAL,
				HARDER,
				HARDEST}
		;
		
		public MainNavigationController.MovementDirections[] getMovementDirectionsFromRoom ()
		{
				return myRoomDataController.getMovementDirectionsFromRoom ();
		}


		// Use this for initialization
		void Start ()
		{

				
				myRoomArtObject = MainMakeStuffController.instantiatePrefabInObject (myRoomArtPrefab, gameObject);



		}

		



		// Update is called once per frame
		void Update ()
		{
	
		}
}
