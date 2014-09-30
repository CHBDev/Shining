using UnityEngine;
using System.Collections;

public class DungeonChunkController
{

		DungeonRoomRawData[,] myDungeonRoomsRaw;
		public int myXPos, myYPos, myZPos;

		public DungeonRoomRawData startingRoom;


		public void setupRoomsInGridSize (int roomsX, int roomsY)
		{

				myDungeonRoomsRaw = new DungeonRoomRawData[roomsX, roomsY];

				for (int x = 0; x < roomsX; x++) {
						for (int y = 0; y < roomsY; y++) {
								myDungeonRoomsRaw [x, y] = new DungeonRoomRawData (x, y);
								
						}
				}

				//hack set start room
				startingRoom = myDungeonRoomsRaw [1, 1];
		}


		public DungeonChunkController (int myX, int myY, int myZ, int roomsX, int roomsY)
		{
				myXPos = myX;
				myYPos = myY;
				myZPos = myZ;

				setupRoomsInGridSize (roomsX, roomsY);

		}

		public DungeonRoomRawData getRoomAt (int x, int y)
		{
				return myDungeonRoomsRaw [x, y];
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
