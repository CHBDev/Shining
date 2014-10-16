using UnityEngine;
using System.Collections;
using UnityEditor;

public class DunMakerControl : MonoBehaviour
{

		public static DunMakerControl singleton;

		public DunRoomControl[,,] currentRooms;
		

		void Awake ()
		{


				if (singleton == null) {
						DontDestroyOnLoad (gameObject);
						singleton = this;
				} else if (singleton != this) {
						Destroy (gameObject);
				}

		}

		

		
		
		public int numberOfLevels, roomsInX, roomsInY;
		
		public GameObject editSlotForDungeonActualObject;
		public GameObject importSlotForDungeonExportObject;

		public Sprite theTempSprite;


		public string topFolderLoc;
		public string dungeonName;
		public string dungeonVersion;


		public float cameraWidth;
		public float cameraHeight;

		public float roomWidthBuffer;
		public float roomHeightBuffer;

		public float roomHeightMod4by3;

		void Reset ()
		{
				
		}
	

		// Use this for initialization
		void Start ()
		{
				cameraWidth = MainCameraController.singleton.returnCameraOrthoScreenWidth () * 100f;
				cameraHeight = MainCameraController.singleton.returnCameraOrthoScreenHeight () * 100f;
				
				roomHeightMod4by3 = (4.0f / 3.0f) * (cameraWidth * (9.0f / 16.0f));

		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}


		public void makerDestroy (GameObject theThing)
		{
				if (theThing == null)
						return;

				if (Application.isEditor == true) {
						DestroyImmediate (theThing);
				} else {
						Destroy (theThing);
				}
		}


		public void newObjectInEditSlot ()
		{


				makerDestroy (editSlotForDungeonActualObject);
				
				editSlotForDungeonActualObject = null;
				setupNewDungeon ();

		}

		public void loadImportSlotIntoEditSlot ()
		{
				if (importSlotForDungeonExportObject == null)
						return;

				makerDestroy (editSlotForDungeonActualObject);

				editSlotForDungeonActualObject = (GameObject)Instantiate (importSlotForDungeonExportObject);

				DunControl dunControl = editSlotForDungeonActualObject.GetComponent<DunControl> ();	

				dunControl.theRooms = new DunRoomControl[dunControl.numberOfLevels, dunControl.roomsInX, dunControl.roomsInY];

			
				currentRooms = new DunRoomControl[dunControl.numberOfLevels, dunControl.roomsInX, dunControl.roomsInY];

				foreach (DunRoomControl roomControl in editSlotForDungeonActualObject.GetComponentsInChildren<DunRoomControl>()) {

						dunControl.theRooms [roomControl.myZ, roomControl.myX, roomControl.myY] = roomControl;
						currentRooms [roomControl.myZ, roomControl.myX, roomControl.myY] = roomControl;

						roomControl.buildDungeonRoomForMaker ();

				}


				

		}
	

		public void exportEditSlotToPrefab ()
		{

			
				
				
				foreach (DunRoomControl theRoomControl in currentRooms) {
						theRoomControl.tearDownRoomForExport ();
				}


				Invoke ("makePrefabOfEditSlot", 2.0f);

		}


		private void makePrefabOfEditSlot ()
		{

				string saveFileLoc = "Assets/DungeonBuilderStuff/testoutput/" + "Dungeon_" + dungeonName + dungeonVersion + ".prefab";

				GameObject thePrefab = PrefabUtility.CreatePrefab (saveFileLoc, editSlotForDungeonActualObject, ReplacePrefabOptions.ReplaceNameBased);



		}

		private void setupNewDungeon ()
		{



				GameObject theDungeon = new GameObject ();
				theDungeon.name = "Dungeon_" + dungeonName + dungeonVersion;
				DunControl theController = theDungeon.AddComponent<DunControl> ();
				
				theController.numberOfLevels = numberOfLevels;
				theController.roomsInX = roomsInX;
				theController.roomsInY = roomsInY;


				editSlotForDungeonActualObject = theDungeon;
				
				setupMakerRooms (theController);
		
			
		}

		private void setupMakerRooms (DunControl theController)
		{

				GameObject theDungeon = theController.gameObject;

				this.currentRooms = new DunRoomControl[numberOfLevels, roomsInX, roomsInY];

				for (int z = 0; z < numberOfLevels; z++) {
						for (int x = 0; x < roomsInX; x++) {
								for (int y = 0; y < roomsInY; y++) {
					
										Vector2 thisPos = determineActualScreenPosForRoom (z, x, y);
					
					
					
										GameObject theRoom = MainMakeStuffController.newGameObjectInObject (theDungeon, thisPos);

										
										theRoom.name = "" + dungeonName + dungeonVersion + "Room" + "_Z" + z + "X" + x + "Y" + y;
										DunRoomControl theRoomController = theRoom.AddComponent<DunRoomControl> ();

										this.currentRooms [z, x, y] = theRoomController;

										
					
										
										theRoomController.setMyPosition (z, x, y);
					
										theRoomController.myDunRoomBGControl = theRoom.AddComponent<DunRoomBGControl> ();
										theRoomController.myDunRoomEncounterControl = theRoom.AddComponent<DunRoomEncounterControl> ();
										theRoomController.myDunRoomSetDecControl = theRoom.AddComponent<DunRoomSetDecControl> ();

									

					
										theRoomController.buildDungeonRoomForMaker ();
					
					
								}
				
						}
			
				}
		}
	
		private Vector2 determineActualScreenPosForRoom (int z, int x, int y)
		{

				
				
				
				float netRoomWidth = cameraWidth + roomWidthBuffer;
				float netRoomHeight = roomHeightMod4by3 + roomHeightBuffer;
				

				float xPos = z * (roomsInX * netRoomWidth) + (x * netRoomWidth);
				float yPos = y * netRoomHeight;

				

				return new Vector2 (xPos / 100f, yPos / 100f);

		}
}
