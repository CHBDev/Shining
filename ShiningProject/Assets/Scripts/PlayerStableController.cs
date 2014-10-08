using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerStableController: MonoBehaviour
{


		
		public static PlayerStableController singleton {
				get {
						return PersistedGameDataController.singleton.thePlayerDataController.myPlayerStableController;
				}
		}

		public int nextCharacterID;

		//[HideInInspector]
		public List<CharacterDataSet>
				listOfCharacters;


		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void addCharacterToStable (CharacterPrefabBucketController.CharacterTypes theType, int theXP)
		{
				if (listOfCharacters == null) {
						Debug.Log ("ERROR: 841123990");
						listOfCharacters = new List<CharacterDataSet> ();
				}


				CharacterDataSet theCharacter = CharacterDataSet.returnNewCharacterDataSet (theType, theXP);
				if (theCharacter != null) {
						this.setCharacterID (theCharacter);
						theCharacter.myType = theType;
						theCharacter.myXP = theXP;
						listOfCharacters.Add (theCharacter);
						
						Debug.Log (theCharacter.myType);

				} else {
						Debug.Log ("ERROR: 877488123");

				}

		}

		private void setCharacterID (CharacterDataSet theCharacter)
		{
				theCharacter.myCharacterID = nextCharacterID;
				nextCharacterID++;
		}



		public void setDataFromSerial (PlayerStableSerializableData theObject)
		{
				
				if (theObject == null) {
						resetAllData ();
			
				} else {
						listOfCharacters = new List<CharacterDataSet> ();

						nextCharacterID = theObject.nextCharacterID;
						for (int i = 0; i < theObject.arrayOfCharacters.Length; i++) {
								CharacterDataSerializableObject theSerializedObject = theObject.arrayOfCharacters [i];
								CharacterDataSet theDataSet = new CharacterDataSet ();
								theDataSet.setDataFromSerial (theSerializedObject);
								listOfCharacters.Insert (i, theDataSet);
						}
				}
		}

		public void resetAllData ()
		{
				nextCharacterID = 0;
				listOfCharacters = new List<CharacterDataSet> ();
		}

}

[Serializable]
public class PlayerStableSerializableData
{
		public CharacterDataSerializableObject[] arrayOfCharacters;
		public int nextCharacterID;

		public PlayerStableSerializableData (PlayerStableController theController)
		{
				if (theController == null) {
						arrayOfCharacters = new CharacterDataSerializableObject[0];
						nextCharacterID = 0;
				} else {

						arrayOfCharacters = new CharacterDataSerializableObject[theController.listOfCharacters.Count];

						for (int i = 0; i < arrayOfCharacters.Length; i++) {

								CharacterDataSet theDataSet = theController.listOfCharacters [i];
								CharacterDataSerializableObject theObject = new CharacterDataSerializableObject (theDataSet);
								arrayOfCharacters [i] = theObject;


						}

						nextCharacterID = theController.nextCharacterID;
				}


		}
}


