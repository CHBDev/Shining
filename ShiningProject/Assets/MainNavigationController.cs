using UnityEngine;
using System.Collections;

public class MainNavigationController : MonoBehaviour
{

		public enum RoomType
		{
				Dungeon,
				Hub,
				Map,
				Training,
				MainMenu,
				Stable,

		}

		

		
		public RoomType currentRoomType;
		public MainHubData.HubNumber currentHubNumber;
		public GameObject currentRoomHolder;
		public RoomHolderController currentRoomHolderController;

		public enum MovementDirections
		{
				North,
				South,
				East,
				West,
				Up,
				Down,
				Reset,
				Teleport,
				Exit,
		
		}

		public static MainNavigationController singleton;
	
	
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


		public void thisDungeonRoomIsComplete ()
		{
				//determine if dungeon is complete, else, what moves are available
				//tell UI to put up available moves
				//maybe there's no choice, like if you do something odd, forces you down, etc

				//check on some stuff
				MainUIController.singleton.putUpMovementOptions (currentRoomHolderController.getMovementDirectionsFromRoom ());
		
		
		
		}
	
		public void moveInDirection (MovementDirections theDir)
		{

				switch (currentRoomType) {
				case RoomType.Dungeon:
						{
								RoomDataController nextRoom = MainDungeonData.singleton.getNextRoomInDirection (theDir);
						}
						break;
				}
				

		}
	
		public void enterNewDungeon ()
		{
				currentRoomType = RoomType.Dungeon;
				//not wired up
				currentRoomHolder = MainHubData.singleton.returnRoomForNewDungeon ();

				Application.LoadLevel ("FirstPersonScene1");
				Debug.Log ("try to call singleton");
				//GameContentsHolderController.singleton.setupRoom ();


		}
	
		public void enterNewHub ()
		{
		
		}
	
		public void enterNewTrainingGame ()
		{
		
		}
	
		public void thisTrainingGameIsComplete ()
		{
		
		}
	
		public void enterMapScreen ()
		{
		
		}
		public void mainMenuCallsPlayButton ()
		{
				//hack
				//first we'd check for saved info, where they are, load a hub scene
				currentHubNumber = MainHubData.HubNumber.House1;
				Application.LoadLevel ("HubTempScene");

		}




}
