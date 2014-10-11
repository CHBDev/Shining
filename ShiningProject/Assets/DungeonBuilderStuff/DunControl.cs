using UnityEngine;
using System.Collections;

public class DunControl : MonoBehaviour
{


		public GameObject[,,] theRooms;

		

		public int numberOfLevels, roomsInX, roomsInY;

		public int startRoomZ, startRoomY, startRoomX;



		public GameObject returnDungeonRoomSaveDataInDirection (DunRoomControl theController, DunRoomControl.DungeonRoomExits dir)
		{

				int finalZ = theController.myZ;
				int finalX = theController.myX;
				int finalY = theController.myY;

				switch (dir) {
				case DunRoomControl.DungeonRoomExits.North:
						finalY++;
						break;
				case DunRoomControl.DungeonRoomExits.South:
						finalY--;
						break;
				case DunRoomControl.DungeonRoomExits.East:
						finalX--;
						break;
				case DunRoomControl.DungeonRoomExits.West:
						finalX++;
						break;
				case DunRoomControl.DungeonRoomExits.StairsUp:
						finalZ++;
						break;
				case DunRoomControl.DungeonRoomExits.StairsDown:
						finalZ--;
						break;
				case DunRoomControl.DungeonRoomExits.TrapdoorDown:
						finalZ--;
						break;
				case DunRoomControl.DungeonRoomExits.CollapsedTrapdoorDown:
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






















