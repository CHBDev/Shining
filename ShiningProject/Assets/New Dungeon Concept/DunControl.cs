using UnityEngine;
using System.Collections;

public class DunControl : MonoBehaviour
{


		public DunRoomControl[,,] theRooms;
		public DunChunkControl[,,] theChunks;

		[HideInInspector]
		public int
				roomsInX, roomsInY;

		public int numberOfLevels, chunksInX, chunksInY;

		public int startRoomZ, startRoomY, startRoomX;



		public DunRoomControl returnDungeonRoomSaveDataInDirection (DunRoomControl theController, MainNavigationController.DungeonExits dir)
		{

				int finalZ = theController.myZ;
				int finalX = theController.myX;
				int finalY = theController.myY;

				switch (dir) {
				case MainNavigationController.DungeonExits.NorthDoor:
						finalY++;
						break;
				case MainNavigationController.DungeonExits.SouthDoor:
						finalY--;
						break;
				case MainNavigationController.DungeonExits.WestDoor:
						finalX--;
						break;
				case MainNavigationController.DungeonExits.EastDoor:
						finalX++;
						break;
				case MainNavigationController.DungeonExits.LeftStairsUp:
						finalZ++;
						break;
				case MainNavigationController.DungeonExits.RightStairsUp:
						finalZ++;
						break;
				case MainNavigationController.DungeonExits.LeftStairsDown:
						finalZ--;
						break;
				case MainNavigationController.DungeonExits.RightStairsDown:
						finalZ--;
						break;
				case MainNavigationController.DungeonExits.TrapdoorVisibleDown:
						finalZ--;
						break;
				case MainNavigationController.DungeonExits.TrapdoorHiddenDown:
						finalZ--;
						break;
				default:
						Debug.Log ("NOT IMPLEMENTED DIRECTION");
						break;

				}

				return theRooms [finalZ, finalX, finalY];

				
		}

		
		public void loadDataOntoSelfFromSaveData (DunControl theSaveData)
		{
				numberOfLevels = theSaveData.numberOfLevels;
				roomsInX = theSaveData.roomsInX;
				roomsInY = theSaveData.roomsInY;

				startRoomZ = theSaveData.startRoomZ;
				startRoomX = theSaveData.startRoomX;
				startRoomY = theSaveData.startRoomY;

				

				
		}


		


		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}






















