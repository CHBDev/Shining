using UnityEngine;
using System.Collections;
using UnityEditor;

public class DungeonMakerController : MonoBehaviour
{

		public static DungeonMakerController singleton;
		public GameObject defaultRoomActualPrefab;


		void Awake ()
		{


				if (singleton == null) {
						DontDestroyOnLoad (gameObject);
						singleton = this;
				} else if (singleton != this) {
						Destroy (gameObject);
				}

		}

		

		
		
		public int numberOfLevels, xRooms, yRooms;
		
		public GameObject editSlotForDungeonActualObject;
		public GameObject importSlotForDungeonActualObject;

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

		public void ALL_ROOMS_TO_DEFAULT ()
		{
				if (defaultRoomActualPrefab != null) {
						editSlotForDungeonActualObject.GetComponent<DungeonActualController> ().allDungeonRoomActualsBecomeThisOne (defaultRoomActualPrefab);
						
				}
		}

		/*
		void OnGUI ()
		{
				if (GUI.Button (new Rect (0, 0, 200, 100), "Save Edit Slot into Save")) {
						saveEditToSaveSlot ();
				}

				if (GUI.Button (new Rect (0, 100, 200, 100), "Load Save Slot Into Edit")) {
						loadSaveSlotIntoEditSlot ();
				}
				if (GUI.Button (new Rect (0, 200, 200, 100), "Load Import Into Save Slot")) {
						loadImportSlotIntoSaveSlot ();
				}
		
				if (GUI.Button (new Rect (0, 300, 200, 100), "Export Save Slot to Prefab")) {
						exportSaveSlotToPrefab ();
				}

				if (GUI.Button (new Rect (0, 400, 200, 100), "New in Save Slot")) {
						newObjectInEditSlot ();
				}
						
		}
		*/

		public void newObjectInEditSlot ()
		{


				Destroy (editSlotForDungeonActualObject);
				editSlotForDungeonActualObject = null;
				setupNewDungeon ();

		}

		public void loadImportSlotIntoEditSlot ()
		{
				if (importSlotForDungeonActualObject == null)
						return;

				Destroy (editSlotForDungeonActualObject);
				editSlotForDungeonActualObject = (GameObject)Instantiate (importSlotForDungeonActualObject);
				 

		}
	

		public void exportEditSlotToPrefab ()
		{
				
				string saveFileName = "" + dungeonName + dungeonVersion;
				string saveFileLoc = "Assets/DungeonBuilderStuff/testoutput/" + dungeonName + dungeonVersion + ".prefab";
		
				PrefabUtility.CreatePrefab (saveFileLoc, editSlotForDungeonActualObject, ReplacePrefabOptions.ReplaceNameBased);
		}
	

		private void setupNewDungeon ()
		{

				GameObject theDungeon = new GameObject ();
				theDungeon.name = "" + dungeonName + dungeonVersion + "DungeonActual";
				DungeonActualController theDungeonActualController = theDungeon.AddComponent<DungeonActualController> ();
				editSlotForDungeonActualObject = theDungeon;
				theDungeonActualController.setYourselfUpDungeonSizes (numberOfLevels, xRooms, yRooms);

				
				for (int z = 0; z < numberOfLevels; z++) {
						for (int x = 0; x < xRooms; x++) {
								for (int y = 0; y < yRooms; y++) {

										
										
										Vector2 thisPos = determineActualScreenPosForRoom (z, x, y);
										theDungeonActualController.addDungeonRoomHolderAtLoc (z, x, y, thisPos);

										;
										


								}
				
						}
			
				}
		
			
		}

		private Vector2 determineActualScreenPosForRoom (int z, int x, int y)
		{

				
				
				
				float netRoomWidth = cameraWidth + roomWidthBuffer;
				float netRoomHeight = roomHeightMod4by3 + roomHeightBuffer;
				

				float xPos = z * (xRooms * netRoomWidth) + (x * netRoomWidth);
				float yPos = y * netRoomHeight;

				

				return new Vector2 (xPos / 100f, yPos / 100f);

		}
}
