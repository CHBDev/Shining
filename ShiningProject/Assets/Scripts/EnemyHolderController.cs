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

		
		private Vector2
				myEnemyPositionOffsetToAttack;

		private Vector2 myBasePosition;
		private Vector2 myBaseScale;
		

		

		[HideInInspector]
		public int
				myEnemyLevel;

		public bool shouldDoHealthBar = false;

		private CircleCollider2D myCollider;

		private Transform myTransform;


		void Awake ()
		{
				//GameObject theData = GameObject.FindWithTag ("MainData");
		
				//MainDataController theDataController = theData.GetComponent<MainDataController> ();
		
		
				

		}

		// Use this for initialization
		void Start ()
		{
				//Debug.Log ("start enemy holder");
				myCollider = gameObject.GetComponent<CircleCollider2D> ();

				EnemyArtController anEnemyArtController = myEnemyImHoldingObject.GetComponent<EnemyArtController> ();
				myCollider.center = new Vector2 (anEnemyArtController.myOverallXOffsetFromShadow, anEnemyArtController.myOverallYOffsetFromShadow + anEnemyArtController.myHitBoxYOffsetFromCenter);
				myCollider.radius = myCollider.radius * anEnemyArtController.myHitBoxRadiusScaleMultiplier;

				myTransform = transform;

				myEnemyPositionOffsetToAttack = myCollider.center;

				myBaseScale = myTransform.localScale;
				myBasePosition = myTransform.localPosition;



		}

		public GameObject setupMyEnemy (GameObject theEnemyPrefab)
		{
				//Debug.Log ("setup my enemy");
				myEnemyImHoldingPrefab = theEnemyPrefab;
				myEnemyImHoldingObject = MainMakeStuffController.instantiatePrefabInObject (myEnemyImHoldingPrefab, gameObject);

				EnemyArtController anEnemyArtController = myEnemyImHoldingObject.GetComponent<EnemyArtController> ();
				;

				Transform myEnemyTransform = myEnemyImHoldingObject.transform;
		
				

				float adjustX = anEnemyArtController.myOverallXOffsetFromShadow;
				float adjustY = anEnemyArtController.myOverallYOffsetFromShadow;

				myEnemyTransform.localPosition = new Vector3 (adjustX, adjustY, 0);

				Transform myHead = myEnemyTransform.FindChild ("myHead");
				myHead.localPosition = new Vector3 (myHead.localPosition.x + anEnemyArtController.myHeadXOffsetVal, myHead.localPosition.y + anEnemyArtController.myHeadYOffsetVal, 0);

				Transform myBody;
				Transform myLeft;
				Transform myRight;
				Transform myFeet;

				if (anEnemyArtController.hasBody) {
						myBody = myEnemyTransform.FindChild ("myBody");
						myBody.localPosition = new Vector3 (myBody.localPosition.x + anEnemyArtController.myBodyXOffsetVal, myBody.localPosition.y + anEnemyArtController.myBodyYOffsetVal, 0);
				}

				if (anEnemyArtController.hasLeft) {
						myLeft = myEnemyTransform.FindChild ("myLeft");
						myLeft.localPosition = new Vector3 (myLeft.localPosition.x + anEnemyArtController.myLeftPartXOffsetVal, myLeft.localPosition.y + anEnemyArtController.myLeftPartYOffsetVal, 0);
				}

				if (anEnemyArtController.hasRight) {
						myRight = myEnemyTransform.FindChild ("myRight");
						myRight.localPosition = new Vector3 (myRight.localPosition.x + anEnemyArtController.myRightPartXOffsetVal, myRight.localPosition.y + anEnemyArtController.myRightPartYOffsetVal, 0);
				}

				if (anEnemyArtController.hasFeet) {
						myFeet = myEnemyTransform.FindChild ("myFeet");
						myFeet.localPosition = new Vector3 (myFeet.localPosition.x + anEnemyArtController.myFeetXOffsetVal, myFeet.localPosition.y + anEnemyArtController.myFeetYOffsetVal, 0);
				}

				Transform myShadow = myEnemyTransform.FindChild ("myShadow");
				myShadow.localPosition = new Vector3 (-adjustX + anEnemyArtController.myShadowXOffsetVal, -adjustY + anEnemyArtController.myShadowYOffsetVal, 0);
				myShadow.localScale = new Vector3 (anEnemyArtController.myShadowScaleX, anEnemyArtController.myShadowScaleY, 1);

				
				
				


				return myEnemyImHoldingObject;
				

		}

		public Vector2 returnAttackPosition ()
		{
				Vector2 scaleChangedOffset = new Vector2 (myEnemyPositionOffsetToAttack.x * myTransform.localScale.x, myEnemyPositionOffsetToAttack.y * myTransform.localScale.y);

				return (Vector2)myTransform.localPosition + scaleChangedOffset;
		}

		public Vector2 returnStartingPosition ()
		{
				return myBasePosition;
		}

		public Vector2 returnStartingScale ()
		{
				return myBaseScale;
		}

	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
