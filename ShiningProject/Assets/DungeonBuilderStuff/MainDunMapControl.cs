using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainDunMapControl : MonoBehaviour
{

		public bool dunMakerMapOn = false;
		public static GameObject[,,] mapRooms;
		public static GameObject mapHolder;
		public static GameObject currentDungeonOfflinePrefab;
		public static DunRoomControl[,,] currentDunRoomControlsOfflineInPrefab;
		public static bool hasDirtyData = false;

		
		public static MainDunMapControl singleton;
	
	
		void Awake ()
		{
		
		
				if (singleton == null) {
						DontDestroyOnLoad (gameObject);
						singleton = this;
				} else if (singleton != this) {
						gameObject.SetActive (false);
						Destroy (gameObject);
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


		public static void updateAllRooms ()
		{
				Debug.Log (mapRooms);

				foreach (GameObject aMapRoom in mapRooms) {
						
						if (aMapRoom != null) {
								MapRoomControl theControl = aMapRoom.GetComponent<MapRoomControl> ();
								theControl.updateToShowChanges ();
						}
						
				}
		}

		public static void saveAllEditsToPrefab ()
		{
				Debug.Log (mapRooms);

				foreach (GameObject aMapRoom in mapRooms) {
						MapRoomControl theControl = aMapRoom.GetComponent<MapRoomControl> ();
						saveThisMapRoomToPrefab (theControl);
				}
		}

		public static void saveThisMapRoomToPrefab (MapRoomControl theMapRoomControl)
		{
				DunRoomControl theDunRoomControl = currentDunRoomControlsOfflineInPrefab [theMapRoomControl.myZ, theMapRoomControl.myX, theMapRoomControl.myY];

				theDunRoomControl.myDungeonExits = theMapRoomControl.myDungeonExits;
				theDunRoomControl.myTintColor = theMapRoomControl.myTintColor;
				theDunRoomControl.shouldTintBackground = theMapRoomControl.shouldTintRoom;


		}
		public static void doMakerMapForDunControl (GameObject theDungeonObject)
		{
				currentDungeonOfflinePrefab = theDungeonObject;

				if (theDungeonObject == null) {
						Debug.Log ("null dungeon object in map");
						return;
				}
				
				mapHolder = new GameObject ();
				mapHolder.name = "mapHolder";
				mapHolder.AddComponent<MainDunMapControl> ();



				DunControl theDunControl = theDungeonObject.GetComponent<DunControl> ();
				
				


				List<DunRoomControl> roomControlList = new List<DunRoomControl> ();

				for (int i = 0; i < theDungeonObject.transform.childCount; i++) {
						Transform aChild = theDungeonObject.transform.GetChild (i);
						GameObject anObject = (GameObject)aChild.gameObject;
						DunRoomControl aRoomControl = aChild.GetComponent<DunRoomControl> ();

						if (aRoomControl != null) {
								roomControlList.Add (aRoomControl);
						}
				}

				
				
				DunRoomControl[] tempDunRoomControls = roomControlList.ToArray ();
				

				int numberOfLevels = theDunControl.numberOfLevels;
				int roomsInX = theDunControl.roomsInX;
				int roomsInY = theDunControl.roomsInY;

				Debug.Log ("" + numberOfLevels + " " + roomsInX + " " + roomsInY);

				mapRooms = new GameObject[numberOfLevels, roomsInX, roomsInY];


				currentDunRoomControlsOfflineInPrefab = new DunRoomControl [numberOfLevels, roomsInX, roomsInY];
		
				foreach (DunRoomControl theRoomControl in tempDunRoomControls) {
						currentDunRoomControlsOfflineInPrefab [theRoomControl.myZ, theRoomControl.myX, theRoomControl.myY] = theRoomControl;
				}


				for (int z = 0; z < numberOfLevels; z++) {
						for (int x = 0; x < roomsInX; x++) {
								for (int y = 0; y < roomsInY; y++) {

										DunRoomControl tempRoomControl = currentDunRoomControlsOfflineInPrefab [z, x, y];
										MainNavigationController.DungeonExits[] tempDunExits = tempRoomControl.myDungeonExits;
										
										
										float netRoomWidth = 40f;
										float netRoomHeight = 40f;
					
					
										float xPos = z * (roomsInX * netRoomWidth) + (x * netRoomWidth) + (z * 64);
										float yPos = y * netRoomHeight;

										Vector2 thisPos = new Vector2 (xPos / 100f, yPos / 100f);



										GameObject theMapRoom = MainMakeStuffController.newGameObjectInObject (mapHolder, thisPos);
										MapRoomControl tempMapRoomControl = theMapRoom.AddComponent<MapRoomControl> ();
										tempMapRoomControl.myDungeonExits = tempDunExits;
										SpriteRenderer tempSpriteRenderer = theMapRoom.AddComponent<SpriteRenderer> ();
										tempSpriteRenderer.sprite = MainMakeStuffController.returnWhiteBoxSprite ();

										if (tempRoomControl.shouldTintBackground == true) {
												tempSpriteRenderer.color = tempRoomControl.myTintColor;
										}
										

										if (tempDunExits.Length <= 0) {
												
												Color32 aTempColor = tempSpriteRenderer.color;
												aTempColor.a = 0;
												tempSpriteRenderer.color = aTempColor;
										}

										mapRooms [z, x, y] = theMapRoom;
					
					
										theMapRoom.name = "mapRoom" + "_level" + z + " x" + x + "/y" + y;

										tempMapRoomControl.myZ = z;
										tempMapRoomControl.myY = y;
										tempMapRoomControl.myX = x;
										tempMapRoomControl.myTintColor = tempRoomControl.myTintColor;
										tempMapRoomControl.shouldTintRoom = tempRoomControl.shouldTintBackground;

										tempMapRoomControl.showGraphicsForExits ();
			
					
								}
				
						}
			
				}
				
		}

		


}

public class MapRoomControl: MonoBehaviour
{
		static float mod = 1f;
		static Vector2 exitNPosPercent = new Vector2 (0f * mod, 1.10f * mod);
		static Vector2 exitSPosPercent = new Vector2 (0f * mod, -1.10f * mod);
		static Vector2 exitEPosPercent = new Vector2 (1.10f * mod, 0f * mod);
		static Vector2 exitWPosPercent = new Vector2 (-1.10f * mod, 0f * mod);
		static Vector2 exitCPosPercent = new Vector2 (0f * mod, 0f * mod);

		


		public MainNavigationController.DungeonExits[] myDungeonExits;
		[HideInInspector]
		public int
				myZ, myX, myY;
		public Color32 myTintColor;
		public bool shouldTintRoom;
	
		public void updateToShowChanges ()
		{
				SpriteRenderer myRenderer = this.GetComponent<SpriteRenderer> ();
				myTintColor.a = 255;
				myRenderer.color = myTintColor;
		}

		[HideInInspector]
		public SpriteRenderer
				exitN, exitS, exitW, exitE, exitC;
		private bool exitSpritesAreSet = false;

		public void showGraphicsForExits ()
		{
				if (exitSpritesAreSet == false) {
						exitN = this.setupASpriteForExit (exitNPosPercent);
						exitS = this.setupASpriteForExit (exitSPosPercent);
						exitE = this.setupASpriteForExit (exitEPosPercent);
						exitW = this.setupASpriteForExit (exitWPosPercent);

						exitC = this.setupASpriteForExit (exitCPosPercent);

				}

				exitSpritesAreSet = true;

				exitN.enabled = false;
				exitS.enabled = false;
				exitE.enabled = false;
				exitW.enabled = false;
		
				exitC.enabled = false;

				bool hasDoorN = false, hasDoorS = false, hasDoorE = false, hasDoorW = false, hasStairsUL = false, hasStairsUR = false, hasStairsDL = false, hasStairsDR = false, hasTrapU = false, hasTradD = false;


				foreach (MainNavigationController.DungeonExits theExit in myDungeonExits) {
						

						switch (theExit) {
						case MainNavigationController.DungeonExits.NorthDoor:

								exitN.enabled = true;
								
								Debug.Log ("woot");
								break;
						case MainNavigationController.DungeonExits.SouthDoor:
								exitS.enabled = true;
								break;

						case MainNavigationController.DungeonExits.EastDoor:
								exitE.enabled = true;
								break;

						case MainNavigationController.DungeonExits.WestDoor:
								exitW.enabled = true;
								break;

						case MainNavigationController.DungeonExits.LeftStairsDown:
								exitW.enabled = true;
								break;

						case MainNavigationController.DungeonExits.LeftStairsUp:
								exitW.enabled = true;
								break;
						case MainNavigationController.DungeonExits.RightStairsDown:
								exitE.enabled = true;
								break;
						case MainNavigationController.DungeonExits.RightStairsUp:
								exitE.enabled = true;
								break;
						case MainNavigationController.DungeonExits.TrapdoorHiddenDown:
								exitC.enabled = true;
								break;
						case MainNavigationController.DungeonExits.TrapdoorInCeiling:
								break;
						case MainNavigationController.DungeonExits.TrapdoorVisibleDown:
								exitC.enabled = true;
								break;


						}
				}

		}

		private SpriteRenderer setupASpriteForExit (Vector2 thePosPercent)
		{
				GameObject thisExitObject = MainMakeStuffController.newGameObjectInObject (gameObject);
				SpriteRenderer spriteR = thisExitObject.AddComponent<SpriteRenderer> ();
				spriteR.sprite = MainMakeStuffController.returnWhiteBoxSprite ();
				
				float mapRoomHeight = spriteR.sprite.rect.height / 100f;

				spriteR.transform.localPosition = new Vector2 (mapRoomHeight * thePosPercent.x / 2f, mapRoomHeight * thePosPercent.y / 2f);
				spriteR.sortingOrder = 5;

				thisExitObject.transform.localScale = new Vector3 (.2f, .2f, 1);


				return spriteR;
		}
	
	
}
