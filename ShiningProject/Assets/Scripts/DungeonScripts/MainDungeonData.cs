using UnityEngine;
using System.Collections;

public class MainDungeonData : MonoBehaviour
{



		public static MainDungeonData singleton;

		
		
		void Awake ()
		{
				if (singleton == null) {
						DontDestroyOnLoad (gameObject);
						singleton = this;
				} else if (singleton != this) {
						Destroy (gameObject);
				}
		}

		public DungeonActualController myDungeonActualController;

	
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}


		public RoomDataController getNextRoomInDirection (MainNavigationController.MovementDirections theDir)
		{

				//create a room data controller somehow


				return null;

		}

		public void setupDungeon (MainHubData.HubNumber theHub)
		{
				if (myDungeonActualController == null) {
			
						//check for saved dungeon
			
						myDungeonActualController = new DungeonActualController ();
			
						
			
				}
				myDungeonActualController.generateDungeonForHub (theHub);
		}


		public GameObject getFirstRoomInDungeon (MainHubData.HubNumber theHub)
		{
				//hack
				if (myDungeonActualController == null) {
						
						//check for saved dungeon

						setupDungeon (theHub);

				}


				return myDungeonActualController.returnStartingRoomInDungeon ();



				
		}

}
