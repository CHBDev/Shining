using UnityEngine;
using System.Collections;

public class DungeonActualController
{

		DungeonCreatorController myDungeonCreatorController;

		DungeonChunkController[, ,] theActualDungeonChunks;

		DungeonChunkController startingChunk;

		// Use this for initialization
		void Start ()
		{
				
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void createCubeGridOfChunks (int xWide, int yTall, int zDeep, int roomsInX, int roomsInY)
		{

				theActualDungeonChunks = new DungeonChunkController[xWide, yTall, zDeep];

				for (int x = 0; x < xWide; x++) {
						for (int y = 0; y < yTall; y++) {
								for (int z = 0; z < zDeep; z++) {

										theActualDungeonChunks [x, y, z] = new DungeonChunkController (x, y, z, roomsInX, roomsInY);
										
								}
								
						}
			
				}

				//hack set starting chunk
				startingChunk = theActualDungeonChunks [1, 1, 1];
		}



		public void generateDungeonForHub (MainHubData.HubNumber theHub)
		{
				if (myDungeonCreatorController == null) {
						myDungeonCreatorController = new DungeonCreatorController ();
				}

				myDungeonCreatorController.setupDungeonForHub (theHub, this);
				

		}

		public DungeonRoomRawData getRoomAt (int chunkX, int chunkY, int chunkZ, int roomX, int roomY)
		{
				return	theActualDungeonChunks [chunkX, chunkY, chunkZ].getRoomAt (roomX, roomY);
		}

		public GameObject returnStartingRoomInDungeon ()
		{

				DungeonRoomRawData thisRoomRaw = this.getRoomAt (startingChunk.myXPos, startingChunk.myYPos, startingChunk.myZPos, startingChunk.startingRoom.myXPos, startingChunk.startingRoom.myYPos);

				return myDungeonCreatorController.returnActualRoomFromRawData (thisRoomRaw);

		}


}



