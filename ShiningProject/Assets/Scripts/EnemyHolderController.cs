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
		private Vector3 myBaseScale;
		

		

		[HideInInspector]
		public int
				myEnemyLevel;
	
		private CircleCollider2D myCollider;

		private Transform myTransform;

		
		public int
				mySlotID;

		public GameObject myTarget;
		public Transform myTargetTransform;
		public TouchOrMouseStuff myTargetTouchOrMouseStuff;

		public MainStatsController.AbilitiesEnum myNextAbilityToDo;

		public bool myNextTargetIsACharacter;


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

		public void setPermanantBaseScale (Vector3 theScale)
		{
				
				myTransform.localScale = theScale;
				myBaseScale = theScale;
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

		public Vector3 returnStartingScale ()
		{
				return myBaseScale;
		}

		public bool tellEnemyToStartTurn ()
		{
				//ask main AI what I should do

				//then tell artcontroller to do it

				//art controller will tell this holder if it needs to move the whole enemy holder to a target
				//Debug.Log (MainTurnsController.singleton.characterHolderControllerArray.Length);
				
				
				MainAIController.singleton.setupFieldsOnThisEnemyForNextAction (this);

				myEnemyActualController.tellActualToBeginAttackAnimation ();

				//store something to do, blarg, i don't know

				return true;
		}


		public void moveHolderToTargetAsPartOfAttackEnemy (float totalAnimationTime, bool matchTargetScale)
		{
		
		
				if (myNextTargetIsACharacter == true) {
						CharacterHolderController myTargetHolder = myTarget.GetComponent<CharacterHolderController> ();
			
			
			
						Vector2 myPos = (Vector2)myTransform.localPosition;
			
						Vector2 targetPos = myTargetHolder.returnAttackPosition ();
			
						Vector2 myTargetScale = myTargetHolder.returnBaseScale ();
			
						myBasePosition = myTransform.localPosition;
			
						if (matchTargetScale == false) {
								myBaseScale = myTransform.localScale;
						}
			
			
			
						MainMoveStuffController.singleton.doMoveMePositionAndScale (gameObject, myPos, targetPos, totalAnimationTime, myTargetScale);

				} else {
						EnemyHolderController myTargetHolder = myTarget.GetComponent<EnemyHolderController> ();
			
			
			
						Vector2 myPos = (Vector2)myTransform.localPosition;
			
						Vector2 targetPos = myTargetHolder.returnAttackPosition ();
			
						Vector2 myTargetScale = myTargetHolder.returnStartingScale ();
			
						myBasePosition = myTransform.localPosition;
			
						if (matchTargetScale == false) {
								myBaseScale = myTransform.localScale;
						}
			
			
			
						MainMoveStuffController.singleton.doMoveMePositionAndScale (gameObject, myPos, targetPos, totalAnimationTime, myTargetScale);

				}
		
			
				
		
		
		
		}
	
		public void doMoveBackToHome (float time)
		{
		
				MainMoveStuffController.singleton.doMoveMePositionAndScale (gameObject, myTransform.localPosition, myBasePosition, time, myBaseScale);
		
		}
	
		public void attackIsComplete ()
		{
				MainTurnsController.singleton.tellMainTurnsThatEnemyHasFinishedMainTurn (mySlotID);
		}

		public void beKilledByCharacterAttack ()
		{
				//hack
				

				myTransform.localScale = new Vector3 (myTransform.localScale.x * .1f, myTransform.localScale.y * .1f, 1);
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

