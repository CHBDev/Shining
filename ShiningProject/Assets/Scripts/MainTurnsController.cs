using UnityEngine;
using System.Collections;


public class MainTurnsController : MonoBehaviour
{

		public static MainTurnsController singleton;
		
	
	
		void Awake ()
		{
				if (singleton == null) {
						
						singleton = this;
						cleanSlateOnNewRoom ();
				} else if (singleton != this) {
						gameObject.SetActive (false);
						Destroy (gameObject);
				}
		}



		private TurnTracker[] theEnemyTurnTrackers, theCharacterTurnTrackers;

		public EnemyHolderController[] enemyHolderControllerArray;
		public CharacterHolderController[] characterHolderControllerArray;

		private bool allEnemiesAreDead;
		

		// Use this for initialization
		void Start ()
		{
				
		}

		public void cleanSlateOnNewRoom ()
		{
				Debug.Log ("clean slate new room");
				theEnemyTurnTrackers = new TurnTracker[16];
				enemyHolderControllerArray = new EnemyHolderController[16];

				for (int i = 0; i < theEnemyTurnTrackers.Length; i++) {
						theEnemyTurnTrackers [i] = new TurnTracker ();
				}
		
				theCharacterTurnTrackers = new TurnTracker[4];
				characterHolderControllerArray = new CharacterHolderController[4];

				for (int i = 0; i < theCharacterTurnTrackers.Length; i++) {
						theCharacterTurnTrackers [i] = new TurnTracker ();
						
				}

				allEnemiesAreDead = false;

				
		}


	
		// Update is called once per frame
		void Update ()
		{
	
		}

		private bool areAllEnemiesFinishedMoving (int enemyPosition)
		{
				for (int i = enemyPosition; i < theEnemyTurnTrackers.Length; i++) {
						TurnTracker theTracker = theEnemyTurnTrackers [i];
						if (theTracker.canThisThingMakeAMoveThisRound () == true) {
								return false;
						}
								

				}

				return true;

		}

		private bool areAllCharactersFinishedMoving ()
		{


				foreach (TurnTracker theTracker in theCharacterTurnTrackers) {
						//Debug.Log ("check a tracker");
						if (theTracker.canThisThingMakeAMoveThisRound () == true) {
								
								return false;
						}
				}

		
				return true;

		}

		private void changeTurnsToCharacterSide ()
		{
				if (allEnemiesAreDead == true) {
						return;
				}

				Debug.Log ("CHARACTER TURNS BEGIN");

				foreach (TurnTracker theT in theCharacterTurnTrackers) {
						theT.hasUsedMainTurnThisRound = false;
						theT.hasUsedSecondaryTurnThisRound = false;
				}
				
				//hack
				//do stuff for characters, for now, just enable them to be clicked
				
				foreach (CharacterHolderController theController in characterHolderControllerArray) {
						if (theController == null) {
								continue;
						}
						theController.myTurnThisRoundIsAvailable = true;
				}



		}

		private void changeTurnsToEnemySide ()
		{



				foreach (TurnTracker theT in theEnemyTurnTrackers) {
						theT.hasUsedMainTurnThisRound = false;
						theT.hasUsedSecondaryTurnThisRound = false;
				}

				Debug.Log ("ENEMY TURNS BEGIN");

				//update all turns counters on enemies by 1

				tellNextEnemyToGoPassLastEnemy (-1);
				

		}

		

		private void tellNextEnemyToGoPassLastEnemy (int lastEnemyPosition)
		{
				for (int i = lastEnemyPosition + 1; i < theEnemyTurnTrackers.Length; i++) {
						

						TurnTracker theT = theEnemyTurnTrackers [i];
						if (theT.canThisThingMakeAMoveThisRound () == true) {
								//tell the enemy is position i to go

								enemyHolderControllerArray [i].tellEnemyToStartTurn ();			

								return;
						}
				}

				changeTurnsToCharacterSide ();
		}

		private void checkAfterEnemyUpdate (int enemyPosition)
		{
				if (areAllEnemiesFinishedMoving (enemyPosition) == true) {
						changeTurnsToCharacterSide ();
				} else {
						tellNextEnemyToGoPassLastEnemy (enemyPosition);
				}
		}

		private void checkAfterCharacterUpdate ()
		{
				if (areAllCharactersFinishedMoving () == true) {
						changeTurnsToEnemySide ();
				}
		}

		public void tellMainTurnsThatCharacterHasFinishedMainTurn (int characterPosition)
		{
				setCharacterHasUsedMainTurnThisRound (characterPosition, true);
				checkAfterCharacterUpdate ();
		}

		public void tellMainTurnsThatEnemyHasFinishedMainTurn (int enemySlot)
		{
				setEnemyUsedMainTurn (enemySlot, true);
				checkAfterEnemyUpdate (enemySlot);
		}
	
		public void setEnemyUsedMainTurn (int enemyPosition, bool usedMainTurn)
		{
				theEnemyTurnTrackers [enemyPosition].hasUsedMainTurnThisRound = usedMainTurn;

				

		}

		public void setEnemyIsIncapacitated (int enemyPosition, bool isIncapacitated)
		{
				theEnemyTurnTrackers [enemyPosition].isIncapacitated = isIncapacitated;
				
		}

		public void setEnemyIsEmpty (int enemyPosition, bool isEmpty)
		{
				theEnemyTurnTrackers [enemyPosition].isEmpty = isEmpty;
				
		}

		public void setEnemyIsDead (int enemyPosition, bool isDead)
		{
				theEnemyTurnTrackers [enemyPosition].isDead = isDead;

				bool allEnemiesAreDead = true;

				foreach (TurnTracker theTurnT in theEnemyTurnTrackers) {
						if (theTurnT.isDead == false && theTurnT.isEmpty == false) {
								allEnemiesAreDead = false;
						}
				}

				if (allEnemiesAreDead == true) {
						Debug.Log ("all enemies are dead");
						allEnemiesAreDead = true;
						announceAllEnemiesAreDead ();
				}
		}

		public void setCharacterHasUsedMainTurnThisRound (int characterPosition, bool hasUsedMainTurn)
		{
				
				theCharacterTurnTrackers [characterPosition].hasUsedMainTurnThisRound = hasUsedMainTurn;
				

		}

		public void setCharacterHasUsedSecondaryTurnThisRound (int characterPosition, bool hasUsedSecond)
		{
				theCharacterTurnTrackers [characterPosition].hasUsedSecondaryTurnThisRound = hasUsedSecond;
				
		}

		public void setCharacterIsIncapacitated (int characterPosition, bool isIncapacitated)
		{
				theCharacterTurnTrackers [characterPosition].isIncapacitated = isIncapacitated;
				
		}

		public void setCharacterIsEmpty (int characterPosition, bool isEmpty)
		{
				theCharacterTurnTrackers [characterPosition].isEmpty = isEmpty;
				
		}

		public void setCharacterIsDead (int characterPosition, bool isDead)
		{
				theCharacterTurnTrackers [characterPosition].isDead = isDead;
		}

		public void activateCharacter (int slot)
		{
				theCharacterTurnTrackers [slot].activateAsCharacter ();
		}

		public void activateEnemy (int slot)
		{
				theEnemyTurnTrackers [slot].activateAsEnemy ();
		}

		public void announceAllEnemiesAreDead ()
		{
				MainNavigationController.singleton.allEnemiesAreDeadInCurrentRoom ();
		}

}

public class TurnTracker
{
		public bool isCharacter = false;
		public bool hasUsedMainTurnThisRound = false;
		public bool hasUsedSecondaryTurnThisRound = false;
		public bool isEmpty = true;
		public bool isIncapacitated = false;
		public bool isDead = false;

		public bool canThisThingMakeAMoveThisRound ()
		{

				//Debug.Log ("empty " + isEmpty + "/usedTurn " + hasUsedMainTurnThisRound + "/isIncap " + isIncapacitated);
				if (isEmpty == true) {
						return false;
				}
						

				if (hasUsedMainTurnThisRound == true) {
						return false;
				}

				if (isIncapacitated == true) {
						return false;
				}

				if (isDead == true) {
						return false;
				}


				return true;
		}

		public void activateAsCharacter ()
		{
				
				activate ();
				isCharacter = true;
		}

		public void activateAsEnemy ()
		{
				activate ();
				isCharacter = false;
		}

		private void activate ()
		{
				hasUsedMainTurnThisRound = false;
				hasUsedSecondaryTurnThisRound = false;
				isEmpty = false;
				isIncapacitated = false;
				isDead = false;
		}






}
