using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomArtController : MonoBehaviour
{


		public Sprite myBackGround;
		public bool shouldTintBackground;
		public Color32 myTintColor;


		[HideInInspector]
		public GameObject
				myEnemyHolderPrefab;
		
		[HideInInspector]
		public int
				myRow1NumberOfSlots;

		public float myRow1Scale;
		public float myRow1YOffset;
		public float myRow1XOffset;
		public float myRow1PercentOfWidth;

		[HideInInspector]
		public int
				myRow2NumberOfSlots;

		public float myRow2Scale;
		public float myRow2YOffset;
		public float myRow2XOffset;
		public float myRow2PercentOfWidth;

		[HideInInspector]
		public int
				myRow3NumberOfSlots;

		public float myRow3Scale;
		public float myRow3YOffset;
		public float myRow3XOffset;
		public float myRow3PercentOfWidth;

		
	
		
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

		
		[HideInInspector]
		public GameObject
				myRow1;

		[HideInInspector]
		public GameObject
				myRow2;

		[HideInInspector]
		public GameObject
				myRow3;

		private List<GameObject> myRow1SpawnPoints;
		private List<GameObject> myRow2SpawnPoints;
		private List<GameObject> myRow3SpawnPoints;
	
		[HideInInspector]
		public List<GameObject>
				myRowObjects;



		// Use this for initialization
		void Start ()
		{

				this.setupEnemiesFromRoomDataOnRoomHolder ();

				myRow1NumberOfSlots = 0;
				if (EnemyRow1Slot01 != null) {
						myRow1NumberOfSlots++;
				}
				if (EnemyRow1Slot02 != null) {
						myRow1NumberOfSlots++;
				}
				if (EnemyRow1Slot03 != null) {
						myRow1NumberOfSlots++;
				}
				if (EnemyRow1Slot04 != null) {
						myRow1NumberOfSlots++;
				}
				if (EnemyRow1Slot05 != null) {
						myRow1NumberOfSlots++;
				}


				myRow2NumberOfSlots = 0;
				if (EnemyRow2Slot01 != null) {
						myRow2NumberOfSlots++;
				}
				if (EnemyRow2Slot02 != null) {
						myRow2NumberOfSlots++;
				}
				if (EnemyRow2Slot03 != null) {
						myRow2NumberOfSlots++;
				}
				if (EnemyRow2Slot04 != null) {
						myRow2NumberOfSlots++;
				}
				if (EnemyRow2Slot05 != null) {
						myRow2NumberOfSlots++;
				}


				myRow3NumberOfSlots = 0;
				if (EnemyRow3Slot01 != null) {
						myRow3NumberOfSlots++;
				}
				if (EnemyRow3Slot02 != null) {
						myRow3NumberOfSlots++;
				}
				if (EnemyRow3Slot03 != null) {
						myRow3NumberOfSlots++;
				}
				if (EnemyRow3Slot04 != null) {
						myRow3NumberOfSlots++;
				}
				if (EnemyRow3Slot05 != null) {
						myRow3NumberOfSlots++;
				}



				this.setupRows ();
				



		}

		private void setupEnemiesFromRoomDataOnRoomHolder ()
		{
				
				GameObject theData = GameObject.FindWithTag ("MainData");
				;

				MainDataController theDataController = theData.GetComponent<MainDataController> ();


				myEnemyHolderPrefab = theDataController.theEnemyHolderPrefab;



				///
				GameObject theRoomDataPrefab = (GameObject)transform.GetComponentInParent<RoomHolderController> ().myRoomDataPrefab;

				RoomDataController theRoomDataController = theRoomDataPrefab.GetComponent<RoomDataController> ();

				

				EnemyRow1Slot01 = theRoomDataController.EnemyRow1Slot01;
		

				EnemyRow1Slot02 = theRoomDataController.EnemyRow1Slot02;
		

				EnemyRow1Slot03 = theRoomDataController.EnemyRow1Slot03;
		

				EnemyRow1Slot04 = theRoomDataController.EnemyRow1Slot04;
		

				EnemyRow1Slot05 = theRoomDataController.EnemyRow1Slot05;
		

				EnemyRow2Slot01 = theRoomDataController.EnemyRow2Slot01;
		

				EnemyRow2Slot02 = theRoomDataController.EnemyRow2Slot02;
		

				EnemyRow2Slot03 = theRoomDataController.EnemyRow2Slot03;
		

				EnemyRow2Slot04 = theRoomDataController.EnemyRow2Slot04;
		

				EnemyRow2Slot05 = theRoomDataController.EnemyRow2Slot05;
		

				EnemyRow3Slot01 = theRoomDataController.EnemyRow3Slot01;
		

				EnemyRow3Slot02 = theRoomDataController.EnemyRow3Slot02;
		

				EnemyRow3Slot03 = theRoomDataController.EnemyRow3Slot03;
		

				EnemyRow3Slot04 = theRoomDataController.EnemyRow3Slot04;
		

				EnemyRow3Slot05 = theRoomDataController.EnemyRow3Slot05;



		}

		private void setupRows ()
		{
				myRow1SpawnPoints = new List<GameObject> ();
				myRow2SpawnPoints = new List<GameObject> ();
				myRow3SpawnPoints = new List<GameObject> ();
		
				
				myRowObjects = new List<GameObject> ();
		
		
				myRow1 = RelativeStuff.newGameObjectInObjectAndMakeRelative (gameObject, new Vector2 (myRow1XOffset, myRow1YOffset));
				myRow1.name = "EnemyRow1";

				myRow2 = RelativeStuff.newGameObjectInObjectAndMakeRelative (gameObject, new Vector2 (myRow2XOffset, myRow2YOffset));
				myRow2.name = "EnemyRow2";

				myRow3 = RelativeStuff.newGameObjectInObjectAndMakeRelative (gameObject, new Vector2 (myRow3XOffset, myRow3YOffset));
				myRow3.name = "EnemyRow3";

				Transform row1Transform = myRow1.transform;
		
				Transform row2Transform = myRow2.transform;
		
				Transform row3Transform = myRow3.transform;


				row1Transform.localScale = RelativeStuff.returnScaleForNewPercentAdjusted (row1Transform.localScale, myRow1Scale);
				row2Transform.localScale = RelativeStuff.returnScaleForNewPercentAdjusted (row2Transform.localScale, myRow2Scale);
				row3Transform.localScale = RelativeStuff.returnScaleForNewPercentAdjusted (row3Transform.localScale, myRow3Scale);

		
				float myWidth = Screen.width / 100.0f;
				Debug.Log ("my width " + myWidth);

				
				int counter = 0;

				List<int> row1DepthRandomizer = new List<int> ();
				for (int i = 0; i < myRow1NumberOfSlots; i++) {
						row1DepthRandomizer.Add (i + 1);

						

				}

				List<int> row2DepthRandomizer = new List<int> ();
				for (int i = myRow1NumberOfSlots; i < myRow1NumberOfSlots + myRow2NumberOfSlots; i++) {
						row2DepthRandomizer.Add (i + 1);
			
						

				}

				List<int> row3DepthRandomizer = new List<int> ();
				for (int i = myRow2NumberOfSlots + myRow1NumberOfSlots; i < myRow1NumberOfSlots + myRow2NumberOfSlots + myRow3NumberOfSlots; i++) {
						row3DepthRandomizer.Add (i + 1);
			
						

				}
		
				for (int i = 0; i < 5; i++) {
			
						counter++;
			
						
						float aChunkWidth = (myWidth * myRow1PercentOfWidth) / 5.0f;
						float insetFromEdgeWidth = (myWidth - (myWidth * myRow1PercentOfWidth)) / 2.0f;
						float thisPosition = insetFromEdgeWidth + (.5f * aChunkWidth) + (i * aChunkWidth);
			
						Vector3 thePos = new Vector2 (thisPosition - myWidth / 2, row1Transform.localPosition.y);

						GameObject tempObject = RelativeStuff.instantiatePrefabInObjectAndMakeRelative (myEnemyHolderPrefab, myRow1, thePos);
						

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
								
								GameObject thisEnemy = tempObject.GetComponent<EnemyHolderController> ().setupMyEnemy (thePrefab);
				
							
					
								int thisNumber = (row1DepthRandomizer.Count - 1) - Random.Range (0, row1DepthRandomizer.Count - 1);

								thisEnemy.GetComponent<EnemyArtController> ().setupLayersForRow (1, row1DepthRandomizer [thisNumber]);

								row1DepthRandomizer.RemoveAt (thisNumber);
						}

			
				}
				
				for (int i = 0; i < 5; i++) {
			
						counter++;
			
			
						float aChunkWidth = (myWidth * myRow2PercentOfWidth) / 5.0f;
						float insetFromEdgeWidth = (myWidth - (myWidth * myRow2PercentOfWidth)) / 2.0f;
						float thisPosition = insetFromEdgeWidth + (.5f * aChunkWidth) + (i * aChunkWidth);
			
						Vector3 thePos = new Vector3 (thisPosition - myWidth / 2, row2Transform.position.y, 0);
			
						GameObject tempObject = RelativeStuff.instantiatePrefabInObjectAndMakeRelative (myEnemyHolderPrefab, myRow2, thePos);
			
			
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

								GameObject thisEnemy = tempObject.GetComponent<EnemyHolderController> ().setupMyEnemy (thePrefab);

							

								int thisNumber = (row2DepthRandomizer.Count - 1) - Random.Range (0, row2DepthRandomizer.Count - 1);
						
								thisEnemy.GetComponent<EnemyArtController> ().setupLayersForRow (2, row2DepthRandomizer [thisNumber]);

								row2DepthRandomizer.RemoveAt (thisNumber);
								
						}
			
				}
		
				for (int i = 0; i < 5; i++) {
						counter++;
			
			
						float aChunkWidth = (myWidth * myRow3PercentOfWidth) / 5.0f;
						float insetFromEdgeWidth = (myWidth - (myWidth * myRow3PercentOfWidth)) / 2.0f;
						float thisPosition = insetFromEdgeWidth + (.5f * aChunkWidth) + (i * aChunkWidth);
			
						Vector3 thePos = new Vector3 (thisPosition - myWidth / 2, row3Transform.position.y, 0);
			
						GameObject tempObject = RelativeStuff.instantiatePrefabInObjectAndMakeRelative (myEnemyHolderPrefab, myRow3, thePos);
			
			
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

								GameObject thisEnemy = tempObject.GetComponent<EnemyHolderController> ().setupMyEnemy (thePrefab);

							

								int thisNumber = (row3DepthRandomizer.Count - 1) - Random.Range (0, row3DepthRandomizer.Count - 1);

								thisEnemy.GetComponent<EnemyArtController> ().setupLayersForRow (3, row3DepthRandomizer [thisNumber]);

								row3DepthRandomizer.RemoveAt (thisNumber);
						}

			
				}
		

				
				myRowObjects.Add (myRow1);
				myRowObjects.Add (myRow2);
				myRowObjects.Add (myRow3);


				changeMainBackGroundSprite ();


		}


	


		public void changeMainBackGroundSprite ()
		{
				GameObject mainBackground = GameObject.Find ("MainBackground");

				SpriteRenderer theRenderer = mainBackground.GetComponent<SpriteRenderer> ();
				theRenderer.sprite = myBackGround;

				if (shouldTintBackground) {
						theRenderer.color = myTintColor;
				}




		}


	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
