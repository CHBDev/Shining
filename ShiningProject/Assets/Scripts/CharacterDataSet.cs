using UnityEngine;
using System.Collections;
using System;

public class CharacterDataSet
{

		

		public CharacterPrefabBucketController.CharacterTypes myType;
		public int myXP;
		
		
		public int
				myCharacterID;


		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		static public CharacterDataSet returnNewCharacterDataSet (CharacterPrefabBucketController.CharacterTypes theType, int theXP)
		{
				CharacterDataSet thisCharacter = new CharacterDataSet ();
				thisCharacter.myType = theType;
				thisCharacter.myXP = theXP;

				//do some math for xp

				return thisCharacter;

		}

		

		public void setDataFromSerial (CharacterDataSerializableObject theObject)
		{
				if (theObject == null) {
						
				} else {
						myType = (CharacterPrefabBucketController.CharacterTypes)theObject.myType;
						myXP = theObject.myXP;
						myCharacterID = theObject.myCharacterID;
				}
		}

}

[Serializable]
public class CharacterDataSerializableObject
{
		public int myType;
		public int myXP;
		public int myCharacterID;

		public CharacterDataSerializableObject (CharacterDataSet theData)
		{
				if (theData == null) {
						myType = 0;
						myXP = 0;
						myCharacterID = 0;
				} else {

						myType = (int)theData.myType;
						myXP = theData.myXP;
						myCharacterID = theData.myCharacterID;
				}


		}
}


