using UnityEngine;
using System.Collections;

public class DunRoomEncounterControl : MonoBehaviour
{

		GameObject myGameObjectForEnemies;

		public enum DifficultyLevel
		{
				ZERO,
				ONE,
				TWO,
				THREE,
				FOUR,
				FIVE,
				SIX,
				SEVEN,
				EIGHT,
				NINE,

		}


	
		

		public EnemyPrefabBucketController.EnemyArtType
				EnemyRow1Slot01 = EnemyPrefabBucketController.EnemyArtType.Head_Mushroom_Red;

		public EnemyPrefabBucketController.EnemyArtType
				EnemyRow1Slot02 = EnemyPrefabBucketController.EnemyArtType.Head_Mushroom_Red;

		public EnemyPrefabBucketController.EnemyArtType
				EnemyRow1Slot03 = EnemyPrefabBucketController.EnemyArtType.Head_Mushroom_Red;

		public EnemyPrefabBucketController.EnemyArtType
				EnemyRow1Slot04 = EnemyPrefabBucketController.EnemyArtType.Head_Mushroom_Red;

		public EnemyPrefabBucketController.EnemyArtType
				EnemyRow1Slot05 = EnemyPrefabBucketController.EnemyArtType.Head_Mushroom_Red;

		public EnemyPrefabBucketController.EnemyArtType
				EnemyRow2Slot01 = EnemyPrefabBucketController.EnemyArtType.Head_Mushroom_Red;

		public EnemyPrefabBucketController.EnemyArtType
				EnemyRow2Slot02 = EnemyPrefabBucketController.EnemyArtType.Head_Mushroom_Red;

		public EnemyPrefabBucketController.EnemyArtType
				EnemyRow2Slot03 = EnemyPrefabBucketController.EnemyArtType.Head_Mushroom_Red;

		public EnemyPrefabBucketController.EnemyArtType
				EnemyRow2Slot04 = EnemyPrefabBucketController.EnemyArtType.Head_Mushroom_Red;

		public EnemyPrefabBucketController.EnemyArtType
				EnemyRow2Slot05 = EnemyPrefabBucketController.EnemyArtType.Head_Mushroom_Red;

		public EnemyPrefabBucketController.EnemyArtType
				EnemyRow3Slot01 = EnemyPrefabBucketController.EnemyArtType.Head_Mushroom_Red;

		public EnemyPrefabBucketController.EnemyArtType
				EnemyRow3Slot02 = EnemyPrefabBucketController.EnemyArtType.Head_Mushroom_Red;

		public EnemyPrefabBucketController.EnemyArtType
				EnemyRow3Slot03 = EnemyPrefabBucketController.EnemyArtType.Head_Mushroom_Red;

		public EnemyPrefabBucketController.EnemyArtType
				EnemyRow3Slot04 = EnemyPrefabBucketController.EnemyArtType.Head_Mushroom_Red;

		public EnemyPrefabBucketController.EnemyArtType
				EnemyRow3Slot05 = EnemyPrefabBucketController.EnemyArtType.Head_Mushroom_Red;


		


		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void tearDownSelf ()
		{

				if (myGameObjectForEnemies == null)
						return;

				myGameObjectForEnemies.SetActive (false);
				Destroy (myGameObjectForEnemies);
		}

		public void activate (DunRoomControl theDunRoomControl)
		{
				GameObject theRoom = theDunRoomControl.gameObject;

				myGameObjectForEnemies = MainMakeStuffController.newGameObjectInObject (theRoom);
				myGameObjectForEnemies.name = theRoom.name + "_Enemies";

				theDunRoomControl.setupEnemyPrefabs ();
				theDunRoomControl.setupEnemies ();
				theDunRoomControl.setupRows (myGameObjectForEnemies);

		}

		public void loadDataOntoSelfFromSaveData (DunRoomEncounterControl theSaveData)
		{
				this.EnemyRow1Slot01 = theSaveData.EnemyRow1Slot01;
				this.EnemyRow1Slot02 = theSaveData.EnemyRow1Slot02;
				this.EnemyRow1Slot03 = theSaveData.EnemyRow1Slot03;
				this.EnemyRow1Slot04 = theSaveData.EnemyRow1Slot05;
				this.EnemyRow1Slot05 = theSaveData.EnemyRow1Slot05;
		
				this.EnemyRow2Slot01 = theSaveData.EnemyRow2Slot01;
				this.EnemyRow2Slot02 = theSaveData.EnemyRow2Slot02;
				this.EnemyRow2Slot03 = theSaveData.EnemyRow2Slot03;
				this.EnemyRow2Slot04 = theSaveData.EnemyRow2Slot05;
				this.EnemyRow2Slot05 = theSaveData.EnemyRow2Slot05;
		
				this.EnemyRow3Slot01 = theSaveData.EnemyRow3Slot01;
				this.EnemyRow3Slot02 = theSaveData.EnemyRow3Slot02;
				this.EnemyRow3Slot03 = theSaveData.EnemyRow3Slot03;
				this.EnemyRow3Slot04 = theSaveData.EnemyRow3Slot05;
				this.EnemyRow3Slot05 = theSaveData.EnemyRow3Slot05;
		}



}


