using UnityEngine;
using System.Collections;

public class MainMakeStuffController : MonoBehaviour
{


		public static MainMakeStuffController singleton;
	
	
		void Awake ()
		{
				if (singleton == null) {
						DontDestroyOnLoad (gameObject);
						singleton = this;
				} else if (singleton != this) {
						Destroy (gameObject);
				}
		}

		public CharacterPrefabHolderController theCharacterPrefabHolderController;
		public EnemyPrefabHolderController theEnemyPrefabHolderController;
		

		// Use this for initialization
		void Start ()
		{
				
		}


		// Update is called once per frame
		void Update ()
		{
	
		}


		public static GameObject returnEnemyPrefabOfType (EnemyPrefabHolderController.EnemyArtType theType)
		{
				return singleton.theEnemyPrefabHolderController.returnEnemyPrefabForType (theType);
		}

		public GameObject returnEnemyPrefabOfTypeAlso (EnemyPrefabHolderController.EnemyArtType theType)
		{
				return theEnemyPrefabHolderController.returnEnemyPrefabForType (theType);
		}

		public static GameObject returnCharacterPrefabOfType (CharacterPrefabHolderController.CharacterTypes theType)
		{
				return singleton.theCharacterPrefabHolderController.returnCharacterPrefabForType (theType);
		}
	
		public GameObject returnCharacterPrefabOfTypeAlso (CharacterPrefabHolderController.CharacterTypes theType)
		{
				return theCharacterPrefabHolderController.returnCharacterPrefabForType (theType);
		}




		public static GameObject instantiatePrefabInObject (GameObject aChild, GameObject aParent, Vector2 aPos)
		{

			

				//Debug.Log (myTransform.localScale);

				GameObject tempObj = (GameObject)Instantiate (aChild);
				Transform childTransform = tempObj.transform;
				Transform parentTransform = aParent.transform;

				childTransform.parent = parentTransform;

				childTransform.localScale = new Vector3 (1, 1, 1);

				//childTransform.localPosition = new Vector3 (aPos.x * myTransform.localScale.x, aPos.y * myTransform.localScale.y, 0);
				childTransform.localPosition = new Vector3 (aPos.x, aPos.y, 0);


				return tempObj;


		}
	

		public static GameObject newGameObjectInObject (GameObject aParent, Vector2 aPos)
		{
		
				
		

				GameObject tempObj = new GameObject ();
				Transform childTransform = tempObj.transform;
				Transform parentTransform = aParent.transform;
		
				childTransform.parent = parentTransform;
		
				childTransform.localScale = new Vector3 (1, 1, 1);
				
				
				childTransform.localPosition = new Vector3 (aPos.x, aPos.y, 0);
		
		
				return tempObj;
		
		
		}

		public static GameObject newGameObjectInObject (GameObject aParent)
		{
				return newGameObjectInObject (aParent, new Vector2 (0, 0));
		}

		



		public static GameObject instantiatePrefabInObject (GameObject aChild, GameObject aParent)
		{

				return instantiatePrefabInObject (aChild, aParent, new Vector2 (0, 0));

		}
}
