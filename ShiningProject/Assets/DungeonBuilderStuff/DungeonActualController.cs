using UnityEngine;
using System.Collections;

public class DungeonActualController: ActualController
{

		

		
		public GameObject[,,] dungeonRoomHolderObjects;
		public int startRoomZ, startRoomX, startRoomY;

		[HideInInspector]
		public GameObject
				myDungeonHolder;
		[HideInInspector]
		public DungeonHolderController
				myDungeonHolderController;

		[HideInInspector]
		public GameObject
				currentDungeonRoomHolder;

		public void allDungeonRoomActualsBecomeThisOne (GameObject newActualPrefab)
		{
				if (newActualPrefab.GetComponent<DungeonRoomActualController> () == null) {
						Debug.Log ("NOT A DUNGEON ACTUAL ROOM");
						return;
				}

				foreach (GameObject anOldRoom in dungeonRoomHolderObjects) {
						
						DungeonRoomHolderController theHolderController = anOldRoom.GetComponent<DungeonRoomHolderController> ();
						GameObject theOldActual = theHolderController.myDungeonRoomActualObject;
						DungeonRoomActualController theOldActualController = theOldActual.GetComponent<DungeonRoomActualController> ();
						
						GameObject theNewActual = MainMakeStuffController.instantiatePrefabInObject (newActualPrefab, anOldRoom);
						DungeonRoomActualController theNewActualController = theNewActual.GetComponent<DungeonRoomActualController> ();

						theHolderController.myDungeonRoomActualObject = theNewActual;
						theHolderController.myDungeonRoomActualController = theNewActualController;

						theNewActualController.myDungeonRoomHolderObject = anOldRoom;
						theNewActualController.myDungeonRoomHolderController = theHolderController;


						theNewActual.name = theOldActual.name;
						
						theNewActualController.myZPos = theOldActualController.myZPos;
						theNewActualController.myXPos = theOldActualController.myXPos;
						theNewActualController.myYPos = theOldActualController.myYPos;

						DungeonRoomArtController theNewArtController = theNewActual.GetComponentInChildren<DungeonRoomArtController> ();
						GameObject theNewArt = theNewArtController.gameObject;

						theNewActualController.myDungeonRoomArtObject = theNewArt;
						theNewActualController.myDungeonRoomArtController = theNewArtController;

						theNewArtController.myDungeonRoomActualObject = theNewActual;
						theNewArtController.myDungeonRoomActualController = theNewActualController;

						theNewArt.name = theOldActualController.myDungeonRoomArtObject.name;

						theNewArtController.setYourselfUp ();		

						Destroy (theOldActual);

				}
		}

		public void addDungeonRoomHolderAtLoc (int theZ, int theX, int theY, Vector2 screenPos)
		{
				if (dungeonRoomHolderObjects == null) {
						Debug.Log ("ERROR: 78492989389");
						return;

				}

				//Debug.Log (screenPos);

				GameObject theDungeonRoomHolder = MainMakeStuffController.newGameObjectInObject (gameObject, screenPos);
				theDungeonRoomHolder.name = "dungeonRoomHolder" + theZ + theX + theY;
				DungeonRoomHolderController theDungeonRoomHolderController = theDungeonRoomHolder.AddComponent<DungeonRoomHolderController> ();
				SpriteRenderer theSpriteRenderer = theDungeonRoomHolder.AddComponent<SpriteRenderer> ();
				theSpriteRenderer.sprite = DungeonMakerController.singleton.theTempSprite;


				GameObject theDungeonRoomActual = MainMakeStuffController.newGameObjectInObject (theDungeonRoomHolder);
				DungeonRoomActualController theDungeonRoomActualController = theDungeonRoomActual.AddComponent<DungeonRoomActualController> ();
				theDungeonRoomActual.name = "dungeonRoomActual" + theZ + theX + theY;

				theDungeonRoomHolderController.myDungeonRoomActualObject = theDungeonRoomActual;
				theDungeonRoomHolderController.myDungeonRoomActualController = theDungeonRoomActualController;

				theDungeonRoomActualController.myDungeonRoomHolderController = theDungeonRoomHolderController;
				theDungeonRoomActualController.myDungeonRoomHolderObject = theDungeonRoomHolder;

				theDungeonRoomActualController.myZPos = theZ;
				theDungeonRoomActualController.myXPos = theX;
				theDungeonRoomActualController.myYPos = theY;

				dungeonRoomHolderObjects [theZ, theX, theY] = theDungeonRoomHolder;

				GameObject theDungeonRoomArt = MainMakeStuffController.newGameObjectInObject (theDungeonRoomActual);
				DungeonRoomArtController theDungeonRoomArtController = theDungeonRoomArt.AddComponent<DungeonRoomArtController> ();
				theDungeonRoomArt.name = "dungeonRoomArt" + theZ + theX + theY;

				theDungeonRoomActualController.myDungeonRoomArtObject = theDungeonRoomArt;
				theDungeonRoomActualController.myDungeonRoomArtController = theDungeonRoomArtController;

				theDungeonRoomArtController.myDungeonRoomActualObject = theDungeonRoomActual;
				theDungeonRoomArtController.myDungeonRoomActualController = theDungeonRoomActualController;

				theDungeonRoomArtController.setYourselfUp ();


		}

		public void setYourselfUpDungeonSizes (int z, int x, int y)
		{
				dungeonRoomHolderObjects = new GameObject[z, x, y];
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




}



