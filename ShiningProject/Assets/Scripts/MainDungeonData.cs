using UnityEngine;
using System.Collections;

public class MainDungeonData : MonoBehaviour
{



		public static MainDungeonData singleton;

		public GameObject myDungeonActual;
		public DungeonActualController myDungeonActualController;
	
		void Awake ()
		{
				if (singleton == null) {
						DontDestroyOnLoad (gameObject);
						singleton = this;
				} else if (singleton != this) {
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


		public RoomDataController getNextRoomInDirection (MainNavigationController.MovementDirections theDir)
		{

				//create a room data controller somehow


				return null;

		}

		public GameObject getRoomForHubNumber (MainHubData.HubNumber theHub)
		{
				//hack
				if (myDungeonActual == null) {
						//make a new dungeon, hell if I know what that is
						myDungeonActual = MainMakeStuffController.newGameObjectInObject (gameObject);
						myDungeonActualController = myDungeonActual.AddComponent<DungeonActualController> ();
						myDungeonActualController.generateDungeonForHub (theHub);

				}




				return null;
		}

}
