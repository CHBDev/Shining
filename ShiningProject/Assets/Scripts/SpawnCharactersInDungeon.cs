using UnityEngine;
using System.Collections;

public class SpawnCharactersInDungeon : MonoBehaviour
{

		

		public Vector2 myCharacter1Loc;
		public Vector2 myCharacter2Loc;
		public Vector2 myCharacter3Loc;

		
		public CharacterPrefabBucketController.CharacterTypes
				myChar1Type;
		
		public CharacterPrefabBucketController.CharacterTypes
				myChar2Type;
		
		public CharacterPrefabBucketController.CharacterTypes
				myChar3Type;

		

		// Use this for initialization
		void Start ()
		{

				
				//hack in the first 3 characters in the stable list
				if (PlayerStableController.singleton.listOfCharacters.Count > 2) {
						Debug.Log ("has saved characters");
						myChar1Type = PlayerStableController.singleton.listOfCharacters [0].myType;
						myChar2Type = PlayerStableController.singleton.listOfCharacters [1].myType;
						myChar3Type = PlayerStableController.singleton.listOfCharacters [2].myType;
				}



				setupCharacter (1, myChar1Type);
				setupCharacter (2, myChar2Type);
				setupCharacter (3, myChar3Type);

				
		}

		void setupCharacter (int slotNum123, CharacterPrefabBucketController.CharacterTypes theType)
		{
				GameObject myCharacterHolderPrefab = MainMakeStuffController.singleton.theCharacterHolderPrefab;

				myCharacterHolderPrefab.GetComponent<CharacterHolderController> ().myCharacterTypeEnum = theType;


				GameObject CharHolderRef;
				Vector2 theLocation;

				switch (slotNum123) {
				case(1):
						theLocation = myCharacter1Loc;
						
						break;
				case(2):

						theLocation = myCharacter2Loc;
						
						break;
				case(3):

						theLocation = myCharacter3Loc;
						
						break;
				default:
						Debug.Log ("ERROR: 88594794");
						return;
				}

				CharHolderRef = MainMakeStuffController.instantiatePrefabInObject (myCharacterHolderPrefab, gameObject, theLocation);


				MainTurnsController.singleton.activateCharacter (slotNum123);


				CharacterHolderController theController = CharHolderRef.GetComponent<CharacterHolderController> ();
				theController.setPermanentBaseScale (MainMakeStuffController.singleton.returnCharacterHolderControllerDefaultScale ());
				
				MainTurnsController.singleton.characterHolderControllerArray [slotNum123] = theController;


				theController.myPositionID = slotNum123;
			


		}

	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
