﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DunRoomControl : MonoBehaviour
{


		
		public DunRoomEncounterControl myDunRoomEncounterControl;
		public DunRoomBGControl myDunRoomBGControl;
		public DunRoomSetDecControl myDunRoomSetDecControl;
		
		
		public int myZ, myX, myY;

		public bool shouldTintBackground;
		public Color32 myTintColor;


		public MainNavigationController.DungeonExits[] myDungeonExits;

		[HideInInspector]
		public bool
				canAllowRandomSpawns;
		
		[HideInInspector]
		public GameObject
				myEnemyHolderPrefab;
	
		[HideInInspector]
		public int
				myRow1NumberOfSlots;

		[HideInInspector]
		public float
				myRow1Scale = 1f;
		[HideInInspector]
		public float
				myRow1YOffset = -1f;
		
		[HideInInspector]
		public float
				myRow1XOffset = 0f;
		[HideInInspector]
		public float
				myRow1PercentOfWidth = 1f;
	
		[HideInInspector]
		public int
				myRow2NumberOfSlots;
	
		[HideInInspector]
		public float
				myRow2Scale = .72f;
		[HideInInspector]
		public float
				myRow2YOffset = .16f;
		[HideInInspector]
		public float
				myRow2XOffset = 0f;
		[HideInInspector]
		public float
				myRow2PercentOfWidth = 1f;
	
		[HideInInspector]
		public int
				myRow3NumberOfSlots;
	
		[HideInInspector]
		public float
				myRow3Scale = .56f;
		[HideInInspector]
		public float
				myRow3YOffset = .92f;
		[HideInInspector]
		public float
				myRow3XOffset = 0f;
		[HideInInspector]
		public float
				myRow3PercentOfWidth = 1f;
	
	
	
	
		[HideInInspector]
		public GameObject
				EnemyRow1Slot01;
		[HideInInspector]
		public GameObject
				EnemyRow1Slot02;
		[HideInInspector]
		public GameObject
				EnemyRow1Slot03;
		[HideInInspector]
		public GameObject
				EnemyRow1Slot04;
		[HideInInspector]
		public GameObject
				EnemyRow1Slot05;
		[HideInInspector]
		public GameObject
				EnemyRow2Slot01;
		[HideInInspector]
		public GameObject
				EnemyRow2Slot02;
		[HideInInspector]
		public GameObject
				EnemyRow2Slot03;
		[HideInInspector]
		public GameObject
				EnemyRow2Slot04;
		[HideInInspector]
		public GameObject
				EnemyRow2Slot05;
		[HideInInspector]
		public GameObject
				EnemyRow3Slot01;
		[HideInInspector]
		public GameObject
				EnemyRow3Slot02;
		[HideInInspector]
		public GameObject
				EnemyRow3Slot03;
		[HideInInspector]
		public GameObject
				EnemyRow3Slot04;
		[HideInInspector]
		public GameObject
				EnemyRow3Slot05;
	
	
	
	
		private List<GameObject> myRow1SpawnPoints;
		private List<GameObject> myRow2SpawnPoints;
		private List<GameObject> myRow3SpawnPoints;

		[HideInInspector]
		public GameObject
				myRoomObject;

		[HideInInspector]
		public Transform
				myRoomObjectTransform;

	 
		public void tearDownRoomForExport ()
		{
				myDunRoomBGControl.tearDownSelf ();
				myDunRoomEncounterControl.tearDownSelf ();

		}




		public void activateDungeonRoomForRuntime ()
		{
				if (myDungeonExits == null) {
						myDungeonExits = new MainNavigationController.DungeonExits[0];
				}
				myDunRoomEncounterControl.activate (this);

				myDunRoomBGControl.activate (this);
				myDunRoomSetDecControl.activate (this);

				//enemy activate doesn't do anything, as the room goes and does it all right now.

				myTintColor.a = 255;
				if (shouldTintBackground == true) {

						myDunRoomBGControl.tintBGContents (myTintColor);
				}

				myRoomObjectTransform.localPosition = new Vector2 (0f, 0f);

		}


	

		public void setupEnemies ()
		{
				
		
		
		
				myRow1NumberOfSlots = 0;
				if (EnemyRow1Slot01 != null) {
						myRow1NumberOfSlots++;
						MainTurnsController.singleton.activateEnemy (1);
				}
				if (EnemyRow1Slot02 != null) {
						myRow1NumberOfSlots++;
						MainTurnsController.singleton.activateEnemy (2);
				}
				if (EnemyRow1Slot03 != null) {
						myRow1NumberOfSlots++;
						MainTurnsController.singleton.activateEnemy (3);
				}
				if (EnemyRow1Slot04 != null) {
						myRow1NumberOfSlots++;
						MainTurnsController.singleton.activateEnemy (4);
				}
				if (EnemyRow1Slot05 != null) {
						myRow1NumberOfSlots++;
						MainTurnsController.singleton.activateEnemy (5);
				}
		
		
				myRow2NumberOfSlots = 0;
				if (EnemyRow2Slot01 != null) {
						myRow2NumberOfSlots++;
						MainTurnsController.singleton.activateEnemy (6);
				}
				if (EnemyRow2Slot02 != null) {
						myRow2NumberOfSlots++;
						MainTurnsController.singleton.activateEnemy (7);
				}
				if (EnemyRow2Slot03 != null) {
						myRow2NumberOfSlots++;
						MainTurnsController.singleton.activateEnemy (8);
				}
				if (EnemyRow2Slot04 != null) {
						myRow2NumberOfSlots++;
						MainTurnsController.singleton.activateEnemy (9);
				}
				if (EnemyRow2Slot05 != null) {
						myRow2NumberOfSlots++;
						MainTurnsController.singleton.activateEnemy (10);
				}
		
		
				myRow3NumberOfSlots = 0;
				if (EnemyRow3Slot01 != null) {
						myRow3NumberOfSlots++;
						MainTurnsController.singleton.activateEnemy (11);
				}
				if (EnemyRow3Slot02 != null) {
						myRow3NumberOfSlots++;
						MainTurnsController.singleton.activateEnemy (12);
				}
				if (EnemyRow3Slot03 != null) {
						myRow3NumberOfSlots++;
						MainTurnsController.singleton.activateEnemy (13);
				}
				if (EnemyRow3Slot04 != null) {
						myRow3NumberOfSlots++;
						MainTurnsController.singleton.activateEnemy (14);
				}
				if (EnemyRow3Slot05 != null) {
						myRow3NumberOfSlots++;
						MainTurnsController.singleton.activateEnemy (15);
				}
		
		
		
				
		
		}

	
		public void setupEnemyPrefabs ()
		{
		
		
		
				myEnemyHolderPrefab = MainMakeStuffController.singleton.theEnemyHolderPrefab;

		
				EnemyRow1Slot01 = MainMakeStuffController.returnEnemyPrefabOfType (myDunRoomEncounterControl.EnemyRow1Slot01);
		
		
				EnemyRow1Slot02 = MainMakeStuffController.returnEnemyPrefabOfType (myDunRoomEncounterControl.EnemyRow1Slot02);
		
		
				EnemyRow1Slot03 = MainMakeStuffController.returnEnemyPrefabOfType (myDunRoomEncounterControl.EnemyRow1Slot03);
		
		
				EnemyRow1Slot04 = MainMakeStuffController.returnEnemyPrefabOfType (myDunRoomEncounterControl.EnemyRow1Slot04);
		
		
				EnemyRow1Slot05 = MainMakeStuffController.returnEnemyPrefabOfType (myDunRoomEncounterControl.EnemyRow1Slot05);
		
		
				EnemyRow2Slot01 = MainMakeStuffController.returnEnemyPrefabOfType (myDunRoomEncounterControl.EnemyRow2Slot01);
		
		
				EnemyRow2Slot02 = MainMakeStuffController.returnEnemyPrefabOfType (myDunRoomEncounterControl.EnemyRow2Slot02);
		
		
				EnemyRow2Slot03 = MainMakeStuffController.returnEnemyPrefabOfType (myDunRoomEncounterControl.EnemyRow2Slot03);
		
		
				EnemyRow2Slot04 = MainMakeStuffController.returnEnemyPrefabOfType (myDunRoomEncounterControl.EnemyRow2Slot04);
		
		
				EnemyRow2Slot05 = MainMakeStuffController.returnEnemyPrefabOfType (myDunRoomEncounterControl.EnemyRow2Slot05);
		
		
				EnemyRow3Slot01 = MainMakeStuffController.returnEnemyPrefabOfType (myDunRoomEncounterControl.EnemyRow3Slot01);
		
		
				EnemyRow3Slot02 = MainMakeStuffController.returnEnemyPrefabOfType (myDunRoomEncounterControl.EnemyRow3Slot02);
		
		
				EnemyRow3Slot03 = MainMakeStuffController.returnEnemyPrefabOfType (myDunRoomEncounterControl.EnemyRow3Slot03);
		
		
				EnemyRow3Slot04 = MainMakeStuffController.returnEnemyPrefabOfType (myDunRoomEncounterControl.EnemyRow3Slot04);
		
		
				EnemyRow3Slot05 = MainMakeStuffController.returnEnemyPrefabOfType (myDunRoomEncounterControl.EnemyRow3Slot05);
		
		
		
		}
	
		public void setupRows (GameObject encounterObject)
		{
				Camera myCamera = Camera.main;
		
				myRow1SpawnPoints = new List<GameObject> ();
				myRow2SpawnPoints = new List<GameObject> ();
				myRow3SpawnPoints = new List<GameObject> ();
		
				float myWidth = myCamera.orthographicSize * 2 * myCamera.aspect;
				//Debug.Log ("my width " + myWidth);
		
		
				int counter = 0;
		
				List<int> row1DepthRandomizer = new List<int> ();
				for (int i = 1; i <= 5; i++) {
						row1DepthRandomizer.Add (i);
			
			
			
				}
		
				List<int> row2DepthRandomizer = new List<int> ();
				for (int i = 6; i <= 10; i++) {
						row2DepthRandomizer.Add (i);
			
			
			
				}
		
				List<int> row3DepthRandomizer = new List<int> ();
				for (int i = 11; i <= 15; i++) {
						row3DepthRandomizer.Add (i);
			
			
			
				}
		
				for (int i = 0; i < 5; i++) {
			
						counter++;
			
			
						float aChunkWidth = (myWidth * myRow1Scale * myRow1PercentOfWidth) / 5.0f;
						float insetFromEdgeWidth = myWidth / 2 - (2 * aChunkWidth);
						float thisPosition = insetFromEdgeWidth + (i * aChunkWidth);
			
						Vector3 thePos = new Vector2 (thisPosition - myWidth / 2 + myRow1XOffset, myRow1YOffset);
			
						GameObject tempObject = MainMakeStuffController.instantiatePrefabInObject (myEnemyHolderPrefab, encounterObject, thePos);
						EnemyHolderController thisHolder = tempObject.GetComponent<EnemyHolderController> ();
						thisHolder.setPermanantBaseScale (new Vector3 (myRow1Scale, myRow1Scale, 1));
			
			
						myRow1SpawnPoints.Add (tempObject);
			
						tempObject.name = "" + counter;
			
						GameObject thePrefab = null;
			
						if (i == 0 && EnemyRow1Slot01 != null) 
								thePrefab = EnemyRow1Slot01;
						if (i == 1 && EnemyRow1Slot02 != null)
								thePrefab = EnemyRow1Slot02;
						if (i == 2 && EnemyRow1Slot03 != null)
								thePrefab = EnemyRow1Slot03;
						if (i == 3 && EnemyRow1Slot04 != null)
								thePrefab = EnemyRow1Slot04;
						if (i == 4 && EnemyRow1Slot05 != null)
								thePrefab = EnemyRow1Slot05;
			
						if (thePrefab != null) {
				
				
								EnemyActualController thisActual = thisHolder.myEnemyActualController;
								GameObject thisEnemy = thisActual.setupMyEnemy (thePrefab);
				
								//slot ID calc //+0 for row 1, plus 5 for ROW 2, plus 10 for row 3
								int slotID = i + 0 + 1;
								thisHolder.mySlotID = slotID;
				
								int thisNumber = (row1DepthRandomizer.Count - 1) - Random.Range (0, row1DepthRandomizer.Count - 1);
				
								thisEnemy.GetComponent<EnemyArtController> ().setupLayersForRow (1, row1DepthRandomizer [thisNumber]);
				
								row1DepthRandomizer.RemoveAt (thisNumber);
				
								MainTurnsController.singleton.enemyHolderControllerArray [slotID] = thisHolder;
						} else {
								tempObject.SetActive (false);
						}
			
			
				}
		
				for (int i = 0; i < 5; i++) {
			
						counter++;
			
			
						float aChunkWidth = (myWidth * myRow2Scale * myRow2PercentOfWidth) / 5.0f;
						float insetFromEdgeWidth = myWidth / 2 - (2 * aChunkWidth);
						float thisPosition = insetFromEdgeWidth + (i * aChunkWidth);
			
						Vector3 thePos = new Vector2 (thisPosition - myWidth / 2 + myRow2XOffset, myRow2YOffset);
			
						GameObject tempObject = MainMakeStuffController.instantiatePrefabInObject (myEnemyHolderPrefab, encounterObject, thePos);
						EnemyHolderController thisHolder = tempObject.GetComponent<EnemyHolderController> ();
						thisHolder.setPermanantBaseScale (new Vector3 (myRow2Scale, myRow2Scale, 1));
			
			
						myRow2SpawnPoints.Add (tempObject);
			
						tempObject.name = "" + counter;
			
						GameObject thePrefab = null;
			
						if (i == 0 && EnemyRow2Slot01 != null) 
								thePrefab = EnemyRow2Slot01;
						if (i == 1 && EnemyRow2Slot02 != null)
								thePrefab = EnemyRow2Slot02;
						if (i == 2 && EnemyRow2Slot03 != null)
								thePrefab = EnemyRow2Slot03;
						if (i == 3 && EnemyRow2Slot04 != null)
								thePrefab = EnemyRow2Slot04;
						if (i == 4 && EnemyRow2Slot05 != null)
								thePrefab = EnemyRow2Slot05;
			
			
						if (thePrefab != null) {
				
				
								EnemyActualController thisActual = thisHolder.myEnemyActualController;
								GameObject thisEnemy = thisActual.setupMyEnemy (thePrefab);
				
								//slot ID calc //+0 for row 1, plus 5 for ROW 2, plus 10 for row 3
								int slotID = i + 5 + 1;
								thisHolder.mySlotID = slotID;
				
				
				
								int thisNumber = (row2DepthRandomizer.Count - 1) - Random.Range (0, row2DepthRandomizer.Count - 1);
				
								thisEnemy.GetComponent<EnemyArtController> ().setupLayersForRow (2, row2DepthRandomizer [thisNumber]);
				
								row2DepthRandomizer.RemoveAt (thisNumber);
								MainTurnsController.singleton.enemyHolderControllerArray [slotID] = thisHolder;
				
						} else {
								tempObject.SetActive (false);
						}
			
				}
		
				for (int i = 0; i < 5; i++) {
						counter++;
			
			
						float aChunkWidth = (myWidth * myRow3Scale * myRow3PercentOfWidth) / 5.0f;
						float insetFromEdgeWidth = myWidth / 2 - (2 * aChunkWidth);
						float thisPosition = insetFromEdgeWidth + (i * aChunkWidth);
			
						Vector3 thePos = new Vector2 (thisPosition - myWidth / 2 + myRow3XOffset, myRow3YOffset);
			
						GameObject tempObject = MainMakeStuffController.instantiatePrefabInObject (myEnemyHolderPrefab, encounterObject, thePos);
						EnemyHolderController thisHolder = tempObject.GetComponent<EnemyHolderController> ();
						thisHolder.setPermanantBaseScale (new Vector3 (myRow3Scale, myRow3Scale, 1));
			
			
			
						myRow3SpawnPoints.Add (tempObject);
			
						tempObject.name = "" + counter;
			
						GameObject thePrefab = null;
			
						if (i == 0 && EnemyRow3Slot01 != null) 
								thePrefab = EnemyRow3Slot01;
						if (i == 1 && EnemyRow3Slot02 != null)
								thePrefab = EnemyRow3Slot02;
						if (i == 2 && EnemyRow3Slot03 != null)
								thePrefab = EnemyRow3Slot03;
						if (i == 3 && EnemyRow3Slot04 != null)
								thePrefab = EnemyRow3Slot04;
						if (i == 4 && EnemyRow3Slot05 != null)
								thePrefab = EnemyRow3Slot05;
			
			
						if (thePrefab != null) {
				
								EnemyActualController thisActual = thisHolder.myEnemyActualController;
								GameObject thisEnemy = thisActual.setupMyEnemy (thePrefab);
				
								//slot ID calc //+0 for row 1, plus 5 for ROW 2, plus 10 for row 3
								int slotID = i + 10 + 1;
								thisHolder.mySlotID = slotID;
				
				
				
								int thisNumber = (row3DepthRandomizer.Count - 1) - Random.Range (0, row3DepthRandomizer.Count - 1);
				
								thisEnemy.GetComponent<EnemyArtController> ().setupLayersForRow (3, row3DepthRandomizer [thisNumber]);
				
								row3DepthRandomizer.RemoveAt (thisNumber);
				
								MainTurnsController.singleton.enemyHolderControllerArray [slotID] = thisHolder;
						} else {
								tempObject.SetActive (false);
						}
			
			
				}
		

		
		
		}
		
		

		void Awake ()
		{
				

		}


		// Use this for initialization
		void Start ()
		{

			
				

		}



		// Update is called once per frame
		void Update ()
		{
	
		}

		public void loadDataOntoSelfFromSaveData (DunRoomControl theSaveData)
		{
				shouldTintBackground = theSaveData.shouldTintBackground;
				myTintColor = theSaveData.myTintColor;
		}

}


