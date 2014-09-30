using UnityEngine;
using System.Collections;

public class EnemyHolderController : MonoBehaviour
{
		
		public GameObject myEnemyActualPrefab;

		[HideInInspector]
		public EnemyActualController
				myEnemyActualController;

		[HideInInspector]
		public GameObject
				myEnemyActualObject;
		
		private Vector2
				myEnemyPositionOffsetToAttack;

		private Vector2 myBasePosition;
		private Vector2 myBaseScale;
		

		

		[HideInInspector]
		public int
				myEnemyLevel;
	
		private CircleCollider2D myCollider;

		private Transform myTransform;

		
		public int
				mySlotID;

		private GameObject myTarget;
		Transform myTargetTransform;
		TouchOrMouseStuff myTargetTouchOrMouseStuff;


		void Awake ()
		{
				
				myCollider = gameObject.GetComponent<CircleCollider2D> ();
				myEnemyActualPrefab.GetComponent<EnemyActualController> ().myEnemyHolderController = this;
		
				myEnemyActualObject = MainMakeStuffController.instantiatePrefabInObject (myEnemyActualPrefab, gameObject);
				myEnemyActualObject.GetComponent<EnemyActualController> ().myEnemyHolderController = this;
		
				myTransform = transform;
		
				myBaseScale = myTransform.localScale;
				myBasePosition = myTransform.localPosition;
		

		
		
		}

		// Use this for initialization
		void Start ()
		{
				
				
				


		}

		public void setupTarget (GameObject theTarget)
		{
				myTarget = theTarget;
				myTargetTransform = theTarget.transform;
				myTargetTouchOrMouseStuff = theTarget.GetComponent<TouchOrMouseStuff> ();
		}

		public void enemyActualCallsThisAfterItFinishesBeingSetup ()
		{
				myEnemyActualController = myEnemyActualObject.GetComponent<EnemyActualController> ();
		
				EnemyArtController myEnemyArtController = myEnemyActualController.myEnemyArtController;
				myCollider.center = new Vector2 (myEnemyArtController.myOverallXOffsetFromShadow, myEnemyArtController.myOverallYOffsetFromShadow + myEnemyArtController.myHitBoxYOffsetFromCenter);
				myCollider.radius = myCollider.radius * myEnemyArtController.myHitBoxRadiusScaleMultiplier;
		
		
				myEnemyPositionOffsetToAttack = myCollider.center;

		}
	
	
	
	

		public Vector2 returnStartingPosition ()
		{
				return myBasePosition;
		}

		public Vector2 returnStartingScale ()
		{
				return myBaseScale;
		}

		public bool tellEnemyToStartTurn ()
		{
				//ask main AI what I should do

				//then tell artcontroller to do it

				//art controller will tell this holder if it needs to move the whole enemy holder to a target
				//Debug.Log (MainTurnsController.singleton.characterHolderControllerArray.Length);
				GameObject theTarget = MainTurnsController.singleton.characterHolderControllerArray [Random.Range (1, 3)].gameObject;

				setupTarget (theTarget);
				myEnemyActualController.tellActualToBeginAttackAnimation ();

				return true;
		}


		public void moveHolderToTargetAsPartOfAttackEnemy (float totalAnimationTime)
		{
		
		
			
		
				CharacterHolderController myTargetHolder = myTarget.GetComponent<CharacterHolderController> ();
		
		
				
				Vector2 myPos = (Vector2)myTransform.localPosition;
				
				Vector2 targetPos = myTargetHolder.returnAttackPosition ();

		
				myBasePosition = myTransform.localPosition;
				myBaseScale = myTransform.localScale;
		
		
				MainMoveStuffController.singleton.doMoveMePositionAndScale (gameObject, myPos, targetPos, totalAnimationTime, myTargetTransform.localScale);
		
				;
		
		
		
		}
	
		public void doMoveBackToHome (float time)
		{
		
				MainMoveStuffController.singleton.doMoveMePositionAndScale (gameObject, myTransform.localPosition, myBasePosition, time, myBaseScale);
		
		}
	
		public void attackIsComplete ()
		{
				MainTurnsController.singleton.tellMainTurnsThatEnemyHasFinishedMainTurn (mySlotID);
		}

	
		// Update is called once per frame
		void Update ()
		{
	
		}
		

		public Vector2 returnAttackPosition ()
		{
				
				Vector2 scaleChangedOffset = new Vector2 (myEnemyPositionOffsetToAttack.x * myTransform.localScale.x, myEnemyPositionOffsetToAttack.y * myTransform.localScale.y);
		
				return (Vector2)myTransform.localPosition + scaleChangedOffset;

				
		}
}

