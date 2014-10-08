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

				Debug.Log ("main nav awake");
				if (singleton == null) {
						Debug.Log ("no main nav singleton");
						
						singleton = this;
				} else if (singleton != this) {
						Debug.Log ("is nav singleton");
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

		public void allEnemiesAreDeadInCurrentRoom ()
		{

				//do we put up a loot screen here? xp and loot? or skip it?
				//maybe a treasure chest drops sometimes.

				//determine if dungeon is complete, else, what moves are available
				//tell UI to put up available moves
				//maybe there's no choice, like if you do something odd, forces you down, etc

				Debug.Log ("ALL ENEMIES ARE DEAD");
				//check on some stuff
				
				//maybe features in the room glow, the trap door or the lever, or the door.
		

		}

		public void moveInDirection (MovementDirections theDir)
		{

				switch (currentRoomType) {
				case RoomType.Dungeon:
						{
								
						}
						break;
				}
				

		}
	
		public void HubCallsDungeon ()
		{
				Debug.Log ("Main Nav says enter new dungeon");
				currentRoomType = RoomType.Dungeon;

				Application.LoadLevel ("DungeonScene");
				
			

		}

		void OnLevelWasLoaded ()
		{
				if (this != singleton) {
						Debug.Log ("MORE THAN !!!!111");
				}

				if (Application.loadedLevelName == "DungeonScene") {
						Debug.Log ("LEVEL LOADED DUNGEON SCENE");
						MainDungeonData.singleton.setupDungeon (currentHubNumber);
				}



				

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
