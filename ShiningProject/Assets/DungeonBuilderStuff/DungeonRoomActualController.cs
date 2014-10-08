using UnityEngine;
using System.Collections;

public class DungeonRoomActualController : MonoBehaviour
{

		public DungeonRoomHolderController myDungeonRoomHolderController;
		public GameObject myDungeonRoomHolderObject;

		public DungeonRoomArtController myDungeonRoomArtController;
		public GameObject myDungeonRoomArtObject;

		public int myXPos;
		public int myYPos;
		public int myZPos;
		public bool isWall = true;
	
		public enum DungeonRoomExits
		{
				North,
				South,
				East,
				West,
				StairsUp,
				StairsDown,
				LadderUp,
				LadderDown,
				TrapdoorUp_VisualOnly,
				TrapdoorDown
		}
	
		public enum RoomDifficultyMod
		{
				DEFAULT,
				EASIEST,
				EASIER,
				NORMAL,
				HARDER,
				HARDEST}
		;
	
		

		public EnemyPrefabBucketController.EnemyArtType
				EnemyRow1Slot01;

		public EnemyPrefabBucketController.EnemyArtType
				EnemyRow1Slot02;

		public EnemyPrefabBucketController.EnemyArtType
				EnemyRow1Slot03;

		public EnemyPrefabBucketController.EnemyArtType
				EnemyRow1Slot04;

		public EnemyPrefabBucketController.EnemyArtType
				EnemyRow1Slot05;

		public EnemyPrefabBucketController.EnemyArtType
				EnemyRow2Slot01;

		public EnemyPrefabBucketController.EnemyArtType
				EnemyRow2Slot02;

		public EnemyPrefabBucketController.EnemyArtType
				EnemyRow2Slot03;

		public EnemyPrefabBucketController.EnemyArtType
				EnemyRow2Slot04;

		public EnemyPrefabBucketController.EnemyArtType
				EnemyRow2Slot05;

		public EnemyPrefabBucketController.EnemyArtType
				EnemyRow3Slot01;

		public EnemyPrefabBucketController.EnemyArtType
				EnemyRow3Slot02;

		public EnemyPrefabBucketController.EnemyArtType
				EnemyRow3Slot03;

		public EnemyPrefabBucketController.EnemyArtType
				EnemyRow3Slot04;

		public EnemyPrefabBucketController.EnemyArtType
				EnemyRow3Slot05;


		


		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}



}
