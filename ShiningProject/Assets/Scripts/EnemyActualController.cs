using UnityEngine;
using System.Collections;

public class EnemyActualController : MonoBehaviour
{
		

		[HideInInspector]
		public GameObject
				myEnemyArtObject
			;

		[HideInInspector]
		public GameObject
				myEnemyArtPrefab;

		[HideInInspector]
		public EnemyArtController
				myEnemyArtController;
	
		[HideInInspector]
		public Animator
				myEnemyActualAnimator;

		[HideInInspector]
		public EnemyHolderController
				myEnemyHolderController;

		[HideInInspector]
		public GameObject
				myEnemyImHoldingObject;

		[HideInInspector]
		public Transform
				myShadowTakenFromArtController;


		void Awake ()
		{
				myEnemyHolderController.myEnemyActualController = this;
		}

		public GameObject setupMyEnemy (GameObject theEnemyPrefab)
		{
		
				
				myEnemyArtPrefab = theEnemyPrefab;


				myEnemyArtObject = MainMakeStuffController.instantiatePrefabInObject (myEnemyArtPrefab, gameObject);
				
				myEnemyArtController = myEnemyArtObject.GetComponent<EnemyArtController> ();
				myEnemyArtController.myEnemyActualController = this;
		
				Transform myEnemyTransform = myEnemyArtObject.transform;
		
		
		
				float adjustX = myEnemyArtController.myOverallXOffsetFromShadow;
				float adjustY = myEnemyArtController.myOverallYOffsetFromShadow;
		
				myEnemyTransform.localPosition = new Vector3 (adjustX, adjustY, 0);
		
				Transform myHead = myEnemyTransform.FindChild ("myHead");
				myHead.localPosition = new Vector3 (myHead.localPosition.x + myEnemyArtController.myHeadXOffsetVal, myHead.localPosition.y + myEnemyArtController.myHeadYOffsetVal, 0);
		
				Transform myBody;
				Transform myLeft;
				Transform myRight;
				Transform myFeet;
		
				if (myEnemyArtController.hasBody) {
						myBody = myEnemyTransform.FindChild ("myBody");
						myBody.localPosition = new Vector3 (myBody.localPosition.x + myEnemyArtController.myBodyXOffsetVal, myBody.localPosition.y + myEnemyArtController.myBodyYOffsetVal, 0);
				}
		
				if (myEnemyArtController.hasLeft) {
						myLeft = myEnemyTransform.FindChild ("myLeft");
						myLeft.localPosition = new Vector3 (myLeft.localPosition.x + myEnemyArtController.myLeftPartXOffsetVal, myLeft.localPosition.y + myEnemyArtController.myLeftPartYOffsetVal, 0);
				}
		
				if (myEnemyArtController.hasRight) {
						myRight = myEnemyTransform.FindChild ("myRight");
						myRight.localPosition = new Vector3 (myRight.localPosition.x + myEnemyArtController.myRightPartXOffsetVal, myRight.localPosition.y + myEnemyArtController.myRightPartYOffsetVal, 0);
				}
		
				if (myEnemyArtController.hasFeet) {
						myFeet = myEnemyTransform.FindChild ("myFeet");
						myFeet.localPosition = new Vector3 (myFeet.localPosition.x + myEnemyArtController.myFeetXOffsetVal, myFeet.localPosition.y + myEnemyArtController.myFeetYOffsetVal, 0);
				}
		
				Transform myShadow = myEnemyTransform.FindChild ("myShadow");
				myShadow.localPosition = new Vector3 (-adjustX + myEnemyArtController.myShadowXOffsetVal, -adjustY + myEnemyArtController.myShadowYOffsetVal, 0);
				myShadow.localScale = new Vector3 (myEnemyArtController.myShadowScaleX, myEnemyArtController.myShadowScaleY, 1);
		
		
		
				myEnemyHolderController.enemyActualCallsThisAfterItFinishesBeingSetup ();
		
		
				return myEnemyArtObject;
		
		
		}

		private void sendEnemyArtBackToBaseLayer ()
		{
				myEnemyArtController.changeSortingLayerTo (null, false, true);
		}

		public void tellEnemyActualToTakeShadowOver (Transform theShadow)
		{
				theShadow.parent = myEnemyHolderController.gameObject.transform;
				
				myShadowTakenFromArtController = theShadow;
		}

		public void doAttackMovementToTargetOnHolder (float time)
		{
				myEnemyArtController.changeSortingLayerTo (null, true, false);
				myEnemyHolderController.moveHolderToTargetAsPartOfAttackEnemy (time, true);
		}
	
		public void doReturnMovementBackToHome (float time)
		{
				Invoke ("sendEnemyArtBackToBaseLayer", time);
				myEnemyHolderController.doMoveBackToHome (time);
		}
	
		public void tellActualAttackAnimationReachedTarget ()
		{
				myEnemyActualAnimator.SetTrigger ("attackReachedCharacter");
		}
	
		public void tellActualToBeginAttackAnimation ()
		{
				myEnemyActualAnimator.SetTrigger ("attackMoveToCharacter");
		
		
		}
	
		public void tellActualAnimationBackHomeFinished ()
		{
				myEnemyActualAnimator.SetTrigger ("attackComplete");
				myEnemyHolderController.attackIsComplete ();
		}
	
		public void tellActualAttackReachedEnemyAnimationComplete ()
		{
				myEnemyActualAnimator.SetTrigger ("attackMoveBackHome");
		}


		// Use this for initialization
		void Start ()
		{
				myEnemyActualAnimator = GetComponent<Animator> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
		
}
