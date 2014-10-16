using UnityEngine;
using System.Collections;

public class DunBackdropSwitch : MonoBehaviour
{


		public GameObject doorLeftPrefab, doorRightPrefab, doorBackPrefab, wallBackPrefab;
		public GameObject wallLeftPrefab, wallRightPrefab, ceilingPrefab, floorPrefab, stairsUpLeftPrefab, stairsUpRightPrefab;
		public GameObject stairsDownLeftPrefab, stairsDownRightPrefab, trapDoorPrefab;

		private GameObject doorLeftObject, doorRightObject, doorBackObject, wallBackObject;
		private GameObject wallLeftObject, wallRightObject, ceilingObject, floorObject, stairsUpLeftObject, stairsUpRightObject;
		private GameObject stairsDownLeftObject, stairsDownRightObject, trapDoorObject;

		bool showingDoorLeft, showingDoorRight, showingStairsUpLeft, showingStairsUpRight, showingStairsDownLeft, showingStairsDownRight;
		bool showingDoorBack, showingTrapDoor;

		MainNavigationController.DungeonExits[] myCurrentExits;

		public void setupBaseRoom (DunRoomControl roomControl)
		{
				myCurrentExits = roomControl.myDungeonExits;

				wallLeftObject = MainMakeStuffController.instantiatePrefabInObjectUsePrefabPos (wallLeftPrefab, gameObject);
				wallRightObject = MainMakeStuffController.instantiatePrefabInObjectUsePrefabPos (wallRightPrefab, gameObject);
				ceilingObject = MainMakeStuffController.instantiatePrefabInObjectUsePrefabPos (ceilingPrefab, gameObject);
				floorObject = MainMakeStuffController.instantiatePrefabInObjectUsePrefabPos (floorPrefab, gameObject);
				wallBackObject = MainMakeStuffController.instantiatePrefabInObjectUsePrefabPos (wallBackPrefab, gameObject);
		}

		public void setExitsForBackdrop ()
		{

				if (doorRightObject != null)
						Destroy (doorRightObject);

				if (doorLeftObject != null)
						Destroy (doorLeftObject);

				if (doorBackObject != null)
						Destroy (doorBackObject);

				if (stairsDownLeftObject != null)
						Destroy (stairsDownLeftObject);

				if (stairsUpLeftObject != null)
						Destroy (stairsUpLeftObject);

				if (stairsDownRightObject != null)
						Destroy (stairsDownRightObject);

				if (stairsUpRightObject != null)
						Destroy (stairsUpRightObject);

				if (trapDoorObject != null)
						Destroy (trapDoorObject);

				showingDoorRight = false;
				showingDoorLeft = false;
				showingDoorBack = false;
				showingStairsDownLeft = false;
				showingStairsUpLeft = false;
				showingStairsDownRight = false;
				showingStairsUpRight = false;
				showingTrapDoor = false;


				foreach (MainNavigationController.DungeonExits anExit in myCurrentExits) {
						switch (anExit) {
						case MainNavigationController.DungeonExits.EastDoor:
								
								showingDoorRight = true;
								doorRightObject = MainMakeStuffController.instantiatePrefabInObjectUsePrefabPos (doorRightPrefab, gameObject);
								break;
						case MainNavigationController.DungeonExits.WestDoor:
								
								showingDoorLeft = true;
								doorLeftObject = MainMakeStuffController.instantiatePrefabInObjectUsePrefabPos (doorLeftPrefab, gameObject);
								break;
						case MainNavigationController.DungeonExits.NorthDoor:
								
								showingDoorBack = true;
								doorBackPrefab = MainMakeStuffController.instantiatePrefabInObjectUsePrefabPos (doorBackPrefab, gameObject);
								if (wallBackObject != null) {
										Destroy (wallBackObject);
								}
								break;
						case MainNavigationController.DungeonExits.SouthDoor:
								//not sure what to do here yet, need something to highlight or UI to click
								break;
						case MainNavigationController.DungeonExits.LeftStairsDown:
								
								showingStairsDownLeft = true;
								stairsDownLeftObject = MainMakeStuffController.instantiatePrefabInObjectUsePrefabPos (stairsDownLeftPrefab, gameObject);
								break;
						case MainNavigationController.DungeonExits.LeftStairsUp:
								
								showingStairsUpLeft = true;
								stairsUpLeftObject = MainMakeStuffController.instantiatePrefabInObjectUsePrefabPos (stairsUpLeftPrefab, gameObject);
								break;
						case MainNavigationController.DungeonExits.RightStairsDown:
								
								showingStairsDownRight = true;
								stairsDownRightObject = MainMakeStuffController.instantiatePrefabInObjectUsePrefabPos (stairsDownRightPrefab, gameObject);
								break;
						case MainNavigationController.DungeonExits.RightStairsUp:
								
								showingStairsUpRight = true;
								stairsUpRightObject = MainMakeStuffController.instantiatePrefabInObjectUsePrefabPos (stairsUpRightPrefab, gameObject);
								break;
						case MainNavigationController.DungeonExits.TrapdoorVisibleDown:
								
								showingTrapDoor = true;
								trapDoorObject = MainMakeStuffController.instantiatePrefabInObjectUsePrefabPos (trapDoorPrefab, gameObject);
								break;
						default:
								break;

						}

						if (showingDoorBack == false && wallBackObject == null) {
								wallBackObject = MainMakeStuffController.instantiatePrefabInObjectUsePrefabPos (wallBackPrefab, gameObject);
						}


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
}
