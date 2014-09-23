using UnityEngine;
using System.Collections;

public class SpawnMainCharacters : MonoBehaviour
{

		public GameObject myCharacterHolderPrefab;

		public Vector2 myCharacter1Loc;
		public Vector2 myCharacter2Loc;
		public Vector2 myCharacter3Loc;

		
		public CharacterDataSet.CharacterTypes_Enum
				myChar1Type;
		
		public CharacterDataSet.CharacterTypes_Enum
				myChar2Type;
		
		public CharacterDataSet.CharacterTypes_Enum
				myChar3Type;

		[HideInInspector]
		public GameObject
				myCharacterHolderObject1;
		[HideInInspector]
		public GameObject
				myCharacterHolderObject2;
		[HideInInspector]
		public GameObject
				myCharacterHolderObject3;

		


		// Use this for initialization
		void Start ()
		{
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

		void setupCharacter (int slotNum123, CharacterDataSet.CharacterTypes_Enum theType)
		{
				
				myCharacterHolderPrefab.GetComponent<CharacterHolderController> ().myCharacterTypeEnum = theType;

				switch (slotNum123) {
				case(1):
						
						RelativeStuff.instantiatePrefabInObjectAndMakeRelative (myCharacterHolderPrefab, gameObject, myCharacter1Loc);

						
						
						break;
				case(2):

					
						RelativeStuff.instantiatePrefabInObjectAndMakeRelative (myCharacterHolderPrefab, gameObject, myCharacter2Loc);


						
						break;
				case(3):

						
						RelativeStuff.instantiatePrefabInObjectAndMakeRelative (myCharacterHolderPrefab, gameObject, myCharacter3Loc);

					
						break;
				}

				


			


		}

	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
