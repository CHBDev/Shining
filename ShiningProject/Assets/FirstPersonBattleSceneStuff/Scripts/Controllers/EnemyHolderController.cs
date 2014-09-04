using UnityEngine;
using System.Collections;

public class EnemyHolderController : MonoBehaviour
{

		[HideInInspector]
		public GameObject
				myEnemyImHoldingPrefab;
	
		[HideInInspector]
		public GameObject
				myEnemyImHoldingObject;

		[HideInInspector]
		public GameObject
				myHPBarPrefab;

		[HideInInspector]
		public GameObject
				myHPBarObject;
		
		[HideInInspector]
		public int
				myEnemyLevel;



		void Awake ()
		{
				GameObject theData = GameObject.FindWithTag ("MainData");
		
				MainDataController theDataController = theData.GetComponent<MainDataController> ();
		
		
				myHPBarPrefab = theDataController.theUIHPBarPrefab;

		}

		// Use this for initialization
		void Start ()
		{
				
			

		}

		public GameObject setupMyEnemy (GameObject theEnemyPrefab)
		{
				myEnemyImHoldingPrefab = theEnemyPrefab;
				myEnemyImHoldingObject = RelativeStuff.instantiatePrefabInObjectAndMakeRelative (myEnemyImHoldingPrefab, gameObject);

				EnemyArtController anEnemyArtController = myEnemyImHoldingObject.GetComponent<EnemyArtController> ();
				;

				myHPBarObject = RelativeStuff.instantiatePrefabInObjectAndMakeRelative (myHPBarPrefab, myEnemyImHoldingObject);
				myHPBarObject.name = "myHPBar";


				Transform myEnemyTransform = myEnemyImHoldingObject.transform;

				Transform mySelf = myEnemyTransform.FindChild ("mySelf");
				Transform myShadow = myEnemyTransform.FindChild ("myShadow");
				Transform myHPBar = myEnemyTransform.FindChild ("myHPBar");

				float adjustY = anEnemyArtController.myBodyOffsetYValue;
				float adjustX = anEnemyArtController.myBodyOffsetXValue;


				myEnemyTransform.localPosition = new Vector3 (adjustX, adjustY, 0);
				myShadow.localPosition = new Vector3 (-adjustX + anEnemyArtController.myShadowOffsetXValue, -adjustY + anEnemyArtController.myShadowOffsetYValue, 0);
				myHPBar.localPosition = new Vector3 (-adjustX + anEnemyArtController.myHPBarOffsetXValue, -adjustY + anEnemyArtController.myHPBarOffsetYValue, 0);
		


				myShadow.localScale = new Vector3 (anEnemyArtController.myShadowScaleSizeX, anEnemyArtController.myShadowScaleSizeY, 1);

				return myEnemyImHoldingObject;

		}

	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
