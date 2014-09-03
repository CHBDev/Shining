using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomController : MonoBehaviour
{


		public Sprite myBackGround;
		
		public int myRow1NumberOfSlots;
		public float myRow1Scale;
		public float myRow1YOffset;
		public float myRow1XOffset;
		public float myRow1PercentOfWidth;

		public int myRow2NumberOfSlots;
		public float myRow2Scale;
		public float myRow2YOffset;
		public float myRow2XOffset;
		public float myRow2PercentOfWidth;

		public int myRow3NumberOfSlots;
		public float myRow3Scale;
		public float myRow3YOffset;
		public float myRow3XOffset;
		public float myRow3PercentOfWidth;

		public GameObject myEnemyPrefab;

		



		
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
				

				this.setupRows ();


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

						Debug.Log (row1DepthRandomizer.Count);

				}

				List<int> row2DepthRandomizer = new List<int> ();
				for (int i = myRow1NumberOfSlots; i < myRow1NumberOfSlots + myRow2NumberOfSlots; i++) {
						row2DepthRandomizer.Add (i + 1);
			
						Debug.Log (row2DepthRandomizer.Count);

				}

				List<int> row3DepthRandomizer = new List<int> ();
				for (int i = myRow2NumberOfSlots + myRow1NumberOfSlots; i < myRow1NumberOfSlots + myRow2NumberOfSlots + myRow3NumberOfSlots; i++) {
						row3DepthRandomizer.Add (i + 1);
			
						Debug.Log (row3DepthRandomizer.Count);

				}
		
				for (int i = 0; i < myRow1NumberOfSlots; i++) {
			
						counter++;
			
						
						float aChunkWidth = (myWidth * myRow1PercentOfWidth) / (float)myRow1NumberOfSlots;
						float insetFromEdgeWidth = (myWidth - (myWidth * myRow1PercentOfWidth)) / 2.0f;
						float thisPosition = insetFromEdgeWidth + (.5f * aChunkWidth) + (i * aChunkWidth);
			
						Vector3 thePos = new Vector2 (thisPosition - myWidth / 2, row1Transform.localPosition.y);

						GameObject tempObject = RelativeStuff.newGameObjectInObjectAndMakeRelative (myRow1, thePos);
						

						myRow1SpawnPoints.Add (tempObject);

						tempObject.name = "" + counter;

						GameObject thisEnemy = RelativeStuff.instantiatePrefabInObjectAndMakeRelative (myEnemyPrefab, tempObject);

					
						int thisNumber = (row1DepthRandomizer.Count - 1) - Random.Range (0, row1DepthRandomizer.Count - 1);
						Debug.Log ("this number = " + thisNumber);


						thisEnemy.GetComponent<EnemyArtController> ().setupLayersForRow (1, row1DepthRandomizer [thisNumber]);

						row1DepthRandomizer.RemoveAt (thisNumber);
			

			
				}
				
				for (int i = 0; i < myRow2NumberOfSlots; i++) {
			
						counter++;
			
			
						float aChunkWidth = (myWidth * myRow2PercentOfWidth) / (float)myRow2NumberOfSlots;
						float insetFromEdgeWidth = (myWidth - (myWidth * myRow2PercentOfWidth)) / 2.0f;
						float thisPosition = insetFromEdgeWidth + (.5f * aChunkWidth) + (i * aChunkWidth);
			
						Vector3 thePos = new Vector3 (thisPosition - myWidth / 2, row2Transform.position.y, 0);
			
						GameObject tempObject = RelativeStuff.newGameObjectInObjectAndMakeRelative (myRow2, thePos);
			
			
						myRow2SpawnPoints.Add (tempObject);
						
						tempObject.name = "" + counter;
			
						GameObject thisEnemy = RelativeStuff.instantiatePrefabInObjectAndMakeRelative (myEnemyPrefab, tempObject);


						int thisNumber = (row2DepthRandomizer.Count - 1) - Random.Range (0, row2DepthRandomizer.Count - 1);
						
						thisEnemy.GetComponent<EnemyArtController> ().setupLayersForRow (2, row2DepthRandomizer [thisNumber]);

						row2DepthRandomizer.RemoveAt (thisNumber);
			
				}
		
				for (int i = 0; i < myRow3NumberOfSlots; i++) {
						counter++;
			
			
						float aChunkWidth = (myWidth * myRow3PercentOfWidth) / (float)myRow3NumberOfSlots;
						float insetFromEdgeWidth = (myWidth - (myWidth * myRow3PercentOfWidth)) / 2.0f;
						float thisPosition = insetFromEdgeWidth + (.5f * aChunkWidth) + (i * aChunkWidth);
			
						Vector3 thePos = new Vector3 (thisPosition - myWidth / 2, row3Transform.position.y, 0);
			
						GameObject tempObject = RelativeStuff.newGameObjectInObjectAndMakeRelative (myRow3, thePos);
			
			
						myRow3SpawnPoints.Add (tempObject);
					
						tempObject.name = "" + counter;
			
						GameObject thisEnemy = RelativeStuff.instantiatePrefabInObjectAndMakeRelative (myEnemyPrefab, tempObject);
			

						int thisNumber = (row3DepthRandomizer.Count - 1) - Random.Range (0, row3DepthRandomizer.Count - 1);

						thisEnemy.GetComponent<EnemyArtController> ().setupLayersForRow (3, row3DepthRandomizer [thisNumber]);

						row3DepthRandomizer.RemoveAt (thisNumber);

			
				}
		

				
				myRowObjects.Add (myRow1);
				myRowObjects.Add (myRow2);
				myRowObjects.Add (myRow3);

		}


	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
