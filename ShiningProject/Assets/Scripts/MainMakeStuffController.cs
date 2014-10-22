using UnityEngine;
using System.Collections;

public class MainMakeStuffController : CHBController
{


		public static MainMakeStuffController singleton;
	
	
		void Awake ()
		{
				if (singleton == null) {
						
						singleton = this;
				} else if (singleton != this) {
						gameObject.SetActive (false);
						Destroy (gameObject);
						return;
				}

				
		}

		[HideInInspector]
		public CharacterPrefabBucketController
				theCharacterPrefabBucketController;
		[HideInInspector]
		public EnemyPrefabBucketController
				theEnemyPrefabBucketController;

		public GameObject theEnemyHolderPrefab, theCharacterHolderPrefab;
		public GameObject theCharacterPrefabBucketPrefab, theEnemyPrefabBucketPrefab;
		
		


		// Use this for initialization
		void Start ()
		{
				theCharacterPrefabBucketController = theCharacterPrefabBucketPrefab.GetComponent<CharacterPrefabBucketController> ();
				theEnemyPrefabBucketController = theEnemyPrefabBucketPrefab.GetComponent<EnemyPrefabBucketController> ();

				Debug.Log ("Character stuff");
				Debug.Log (theCharacterPrefabBucketPrefab);
				Debug.Log (theCharacterPrefabBucketController);
		}


		// Update is called once per frame
		void Update ()
		{
	
		}

		public static Sprite returnWhiteBoxSprite ()
		{
				return Resources.Load<Sprite> ("16by16White");
		}

		public Vector2 returnCharacterHolderControllerDefaultScale ()
		{
				float allEm = theCharacterPrefabBucketController.baseCharacterHolderScale;
				return new Vector3 (allEm, allEm, 1);
		}


		public static GameObject returnEnemyPrefabOfType (EnemyPrefabBucketController.EnemyArtType theType)
		{
				return singleton.theEnemyPrefabBucketController.returnEnemyPrefabForType (theType);
		}

		

		public static GameObject returnCharacterPrefabOfType (CharacterPrefabBucketController.CharacterTypes theType)
		{
				return singleton.theCharacterPrefabBucketController.returnCharacterPrefabForType (theType);
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

		public static GameObject newHiddenDisabledGameObjectInObject (GameObject aParent)
		{
				GameObject theObject = newGameObjectInObject (aParent, new Vector2 (0, 0));
				theObject.hideFlags = HideFlags.HideInHierarchy;
				theObject.SetActive (false);
				return theObject;
		}


		public static void enableGameObject (GameObject theObject)
		{
				theObject.SetActive (true);
				theObject.hideFlags = HideFlags.None;
		}

		public static GameObject instantiatePrefabInObjectUsePrefabPos (GameObject aChild, GameObject aParent)
		{
				return instantiatePrefabInObject (aChild, aParent, aChild.transform.localPosition);
		}

		public static GameObject instantiatePrefabInObject (GameObject aChild, GameObject aParent)
		{

				return instantiatePrefabInObject (aChild, aParent, new Vector2 (0, 0));

		}


}
