using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MainDungeonData : MonoBehaviour
{



		public static MainDungeonData singleton;
		
		private GameObject theActiveDungeon;
	
		
		
		
		void Awake ()
		{
				if (singleton == null) {
						
						singleton = this;
						
				} else if (singleton != this) {
						gameObject.SetActive (false);
						Destroy (gameObject);
				}
		}
	

		public void setupNew5by5Dungeon (int numberOfLevels)
		{
			
				
				theActiveDungeon = MainMakeStuffController.newGameObjectInObject (GameAssetsControl.singleton.gameObject);

				DunControl theDunControl = theActiveDungeon.AddComponent<DunControl>;

				theDunControl.numberOfLevels = numberOfLevels;
				theDunControl.chunksInX = 5;
				theDunControl.chunksInY = 5;

				theDunControl.roomsInX = 5 * 3;
				theDunControl.roomsInY = 5 * 3;

				theDunControl.theChunks = new DunChunkControl[numberOfLevels, 5, 5];


				theDunControl.theRooms = new DunRoomControl[theDunControl.numberOfLevels, theDunControl.roomsInX, theDunControl.roomsInY];


				//init rooms
				for (int z = 0; z < theDunControl.theRooms.GetLength(0); z++) {
						for (int x = 0; x < theDunControl.theRooms.GetLength(1); x++) {
								for (int y = 0; y < theDunControl.theRooms.GetLength(2); y++) {

										DunRoomControl thisDunRoomControl = theDunControl.theRooms [z, x, y];
										thisDunRoomControl.myZ = z;
										thisDunRoomControl.myX = x;
										thisDunRoomControl.myY = y;

								}
						}
				}


				
		}

		void setupChunksForDungeon (DunControl theDunControl)
		{
				int numOfLevels = theDunControl.numberOfLevels;
				
				int chunksInX = theDunControl.chunksInX;
				int chunksInY = theDunControl.chunksInY;

				bool levelBuildCompletedSuccess = true;
				

				//do for each level
				for (int levelNum = 0; levelNum < numOfLevels; levelNum++) {

						do {

			
								DunChunkControl[,] thisLevelOfChunks = theDunControl.theChunks [levelNum];
								List<DunChunkControl> listOfAvailableChunks = thisLevelOfChunks.ToList ();

						
								//block out 5
								int[] arrOfInts = MainMathControl.returnArrayOfInts (0, listOfAvailableChunks.Count - 1);
						
								for (int i = 0; i < 5; i++) {
										DunChunkControl thisChunk = listOfAvailableChunks [arrOfInts [i]];
										thisChunk.myChunkType = DunChunkControl.ChunkType.chunkBlackedOut;
										listOfAvailableChunks.Remove (thisChunk);
								}

								//place start
								int startInt = MainMathControl.returnRandomInt (0, listOfAvailableChunks.Count - 1);
								DunChunkControl startChunk = listOfAvailableChunks [startInt];
								startChunk.myChunkType = DunChunkControl.ChunkType.chunkStart;


								//path 1234 with 1count for retraverse

								//block out 1 touching 1234

								//add miniboss in 1234

								//path 5678 2ct for retraverse

								//block 1 off of 5678

								//add miniboss in 5678

								//attach boss off S12345678

								//add optional chunk off of s12345678

								//convert one of 12345678 to special chunk


								/////// PREFAB CHUNKS get decided
								/// 
								/// room controls all get set, and we should be done
								/// 
								/// random spawner will handle all non special rooms at that point

						} while(levelBuildCompletedSuccess == true);
				}
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
