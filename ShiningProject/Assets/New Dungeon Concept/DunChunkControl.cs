using UnityEngine;
using System.Collections;

public class DunChunkControl : MonoBehaviour
{

		public enum ChunkType
		{
				chunkBlackedOut,
				chunkNormal,
				chunkStart,
				chunkBoss,
				chunkMiniboss,
				chunkOptional,
				chunkSpecial,

		}

		public int[] myPathOrderNumbers;

		bool hasNorthExit, hasSouthExit, hasWestExit, hasEastExit, hasStairsUp, hasStairsDown;

		public ChunkType myChunkType;

		public int myLevel, myXPos, myYPos;

		public Vector2 myNorthExitXY, mySouthExitXY, myEastExitXY, myWestExitXY, myStairsUpXY, myStairsDownXY;

		public bool hasBonusRoom;
		public Vector2 bonusRoomXY;

		public void resetClean ()
		{
				hasNorthExit = false;
				hasSouthExit = false;
				hasEastExit = false;
				hasWestExit = false;
				hasStairsUp = false;
				hasStairsDown = false;

				myChunkType = ChunkType.chunkBlackedOut;

				myLevel = 0;
				myXPos = 0;
				myYPos = 0;

				hasBonusRoom = false;
				bonusRoomXY = new Vector2 (0, 0);

				myPathOrderNumbers = new int[]{-1};
		}

		// Use this for initialization
		void Start ()
		{
				resetClean ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}




}
