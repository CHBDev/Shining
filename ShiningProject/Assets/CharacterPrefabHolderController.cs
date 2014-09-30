using UnityEngine;
using System.Collections;



public class CharacterPrefabHolderController : ScriptableObject
{

		public enum CharacterTypes
		{
				NULL_CHARACTER,
				CONE,
				BRICK,
				TIRE,
		}

		[System.Serializable]
		public class CharacterTypePrefabPair
		{

				public CharacterPrefabHolderController.CharacterTypes characterType;
				public GameObject prefab;


		}

		public CharacterTypePrefabPair[] myCharacterArray;

		public GameObject returnCharacterPrefabForType (CharacterTypes theType)
		{
				foreach (CharacterTypePrefabPair thePair in myCharacterArray) {
						if (thePair.characterType == theType) {
								return thePair.prefab;
						}
				}
		
				
				return null;
		}
	
}
