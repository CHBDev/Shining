using UnityEngine;
using System.Collections;


public class MainTurnsController : MonoBehaviour
{

		public static MainTurnsController singleton;
		
	
	
		void Awake ()
		{
				if (singleton == null) {
						DontDestroyOnLoad (gameObject);
						singleton = this;
				} else if (singleton != this) {
						Destroy (gameObject);
				}
		}



		private TurnTracker[] theEnemyList, theCharacterList;

		

		// Use this for initialization
		void Start ()
		{
	
				cleanSlateOnNewRoom ();
			


		}

		public void cleanSlateOnNewRoom ()
		{
				theEnemyList = new TurnTracker[16];

				for (int i = 0; i < theEnemyList.Length; i++) {
						theEnemyList [i] = new TurnTracker ();
				}
		
				theCharacterList = new TurnTracker[4];

				for (int i = 0; i < theCharacterList.Length; i++) {
						theCharacterList [i] = new TurnTracker ();
						theCharacterList [i].isCharacter = true;
				}

				
		}


	
		// Update is called once per frame
		void Update ()
		{
	
		}

		private bool isThisTheLastEnemyThatCanMove (int enemyPosition)
		{
				for (int i = enemyPosition; i < theEnemyList.Length; i++) {
						TurnTracker theTracker = theEnemyList [i];
						if (theTracker.canThisThingMakeAMoveThisRound () == true) {
								return false;
						}
								

				}

				return true;

		}

		private bool areAllCharactersFinishedMoving ()
		{


				foreach (TurnTracker theTracker in theCharacterList) {
						if (theTracker.canThisThingMakeAMoveThisRound () == true)
								return false;
				}

		
				return true;

		}

		private void changeTurnsToCharacterSide ()
		{
				//do something to tell characters to increment turn trackers by 1, for incapacitated and charge moves
				tellAllCharactersThatOneTurnHasPassed ();


				foreach (TurnTracker theT in theCharacterList) {
						theT.hasUsedMainTurnThisRound = false;
						theT.hasUsedSecondaryTurnThisRound = false;
				}
		}

		private void changeTurnsToEnemySide ()
		{
				tellAllEnemiesThatOneTurnHasPassed ();

				foreach (TurnTracker theT in theEnemyList) {
						theT.hasUsedMainTurnThisRound = false;
						theT.hasUsedSecondaryTurnThisRound = false;
				}

		}

		private void tellAllCharactersThatOneTurnHasPassed ()
		{
				//hack

		}

		private void tellAllEnemiesThatOneTurnHasPassed ()
		{
				//hack
		}

		private void tellNextEnemyToGo (int lastEnemyPosition)
		{
				for (int i = lastEnemyPosition; i < theEnemyList.Length; i++) {
						TurnTracker theT = theEnemyList [i];
						if (theT.canThisThingMakeAMoveThisRound () == true) {
								//tell the enemy is position i to go
								return;
						}
				}

				changeTurnsToCharacterSide ();
		}

		private void checkAfterEnemyUpdate (int enemyPosition)
		{
				if (isThisTheLastEnemyThatCanMove (enemyPosition) == true) {
						changeTurnsToCharacterSide ();
				} else {
						tellNextEnemyToGo (enemyPosition);
				}
		}

		private void checkAfterCharacterUpdate ()
		{
				if (areAllCharactersFinishedMoving () == true) {
						changeTurnsToEnemySide ();
				}
		}


		public void setEnemyUsedMainTurn (int enemyPosition, bool usedMainTurn)
		{
				theEnemyList [enemyPosition].hasUsedMainTurnThisRound = usedMainTurn;

				checkAfterEnemyUpdate (enemyPosition);

		}

		public void setEnemyIsIncapacitated (int enemyPosition, bool isIncapacitated)
		{
				theEnemyList [enemyPosition].isIncapacitated = isIncapacitated;
				checkAfterEnemyUpdate (enemyPosition);
		}

		public void setEnemyIsEmpty (int enemyPosition, bool isEmpty)
		{
				theEnemyList [enemyPosition].isEmpty = isEmpty;
				checkAfterEnemyUpdate (enemyPosition);
		}

		public void setCharacterHasUsedMainTurnThisRound (int characterPosition, bool hasUsedMainTurn)
		{
				theCharacterList [characterPosition].hasUsedMainTurnThisRound = hasUsedMainTurn;
				checkAfterCharacterUpdate ();

		}

		public void setCharacterHasUsedSecondaryTurnThisRound (int characterPosition, bool hasUsedSecond)
		{
				theCharacterList [characterPosition].hasUsedSecondaryTurnThisRound = hasUsedSecond;
				
		}

		public void setCharacterIsIncapacitated (int characterPosition, bool isIncapacitated)
		{
				theCharacterList [characterPosition].isIncapacitated = isIncapacitated;
				checkAfterCharacterUpdate ();
		}

		public void setCharacterIsEmpty (int characterPosition, bool isEmpty)
		{
				theCharacterList [characterPosition].isEmpty = isEmpty;
				checkAfterCharacterUpdate ();
		}

}

public class TurnTracker
{
		public bool isCharacter = false;
		public bool hasUsedMainTurnThisRound = false;
		public bool hasUsedSecondaryTurnThisRound = false;
		public bool isEmpty = true;
		public bool isIncapacitated = false;

		public bool canThisThingMakeAMoveThisRound ()
		{
				if (isEmpty == true)
						return false;

				if (hasUsedMainTurnThisRound == true)
						return false;

				if (isIncapacitated == true)
						return false;


				return true;
		}





}
