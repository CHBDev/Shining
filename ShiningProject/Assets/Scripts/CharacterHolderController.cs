using UnityEngine;
using System.Collections;

public class CharacterHolderController : MonoBehaviour
{


		private bool myTurnThisRoundIsAvailablePrivate = true;

		public bool myTurnThisRoundIsAvailable {
				get {
						return myTurnThisRoundIsAvailablePrivate;
				}
				set {
						myTurnThisRoundIsAvailablePrivate = value;
						myCharacterHolderMouseInteraction.canBeTouchedOrMoused = value;
				}
		}

		

		[HideInInspector]
		public GameObject
				myCharacterActualObject;
		
		public GameObject myCharacterActualPrefab;
		private CharacterActualController myCharacterActualController;

		[HideInInspector]
		public Vector2
				myLocation;

		[HideInInspector]
		public CharacterPrefabBucketController.CharacterTypes 
				myCharacterTypeEnum;
	
		Transform myTransform;
		

		CharacterHolderMouseInteraction myCharacterHolderMouseInteraction;

		GameObject myTarget;
		Transform myTargetTransform;
		TouchOrMouseStuff myTargetTouchOrMouseStuff;
		TouchOrMouseStuff.TargetType myTargetType;
		EnemyHolderController myTargetEnemyHolderController;
		CharacterHolderController myTargetCharacterHolderController;

		MainStatsController.AbilitiesEnum myCurrentlyAnimatingAbility;

		float cameraWidth;
		float cameraHeight;

		private Vector2 myBasePosition;
		private Vector3 myBaseScale;
		

		public int myPositionID;

		void Awake ()
		{
				myTransform = transform;
				myBaseScale = myTransform.localScale;

		}

		// Use this for initialization
		void Start ()
		{

				myCharacterActualObject = MainMakeStuffController.instantiatePrefabInObject (myCharacterActualPrefab, gameObject);

				
				myCharacterActualController = myCharacterActualObject.GetComponent<CharacterActualController> ();
				myCharacterActualController.setMyType (myCharacterTypeEnum);
				myCharacterActualController.myCharacterHolderController = this;


				
				myCharacterHolderMouseInteraction = GetComponent<CharacterHolderMouseInteraction> ();

				
			
		}

	

		// Update is called once per frame
		void Update ()
		{
	
		}

		public void touchEndedWithTarget (GameObject theTarget)
		{
				myTarget = theTarget;
				myTargetTransform = theTarget.transform;

				TouchOrMouseStuff tempTM = myTarget.GetComponent<TouchOrMouseStuff> ();




				myTargetTouchOrMouseStuff = tempTM;
				myTargetType = tempTM.myTargetType;

				if (myTargetType == TouchOrMouseStuff.TargetType.ENEMY) {
						myTargetEnemyHolderController = myTarget.GetComponent<EnemyHolderController> ();
				} else if (myTargetType == TouchOrMouseStuff.TargetType.CHARACTER) {
						myTargetCharacterHolderController = myTarget.GetComponent<CharacterHolderController> ();
				}

				//this might do a UI ability picker thing first, no clue

				doSomethingToMyTarget ();

		}

		private void doSomethingToMyTarget ()
		{
				if (myTargetTouchOrMouseStuff.myTargetType == TouchOrMouseStuff.TargetType.ENEMY) {
						
						myCurrentlyAnimatingAbility = MainStatsController.AbilitiesEnum.AttackMeleeSingleBig;
						myTurnThisRoundIsAvailable = false;
						myCharacterActualController.tellActualToBeginAttackAnimation ();


				} else {
						//doing something to a character or a thing
				}
		}
	
		public Vector3 returnBaseScale ()
		{
				return myBaseScale;
		}

		public void setPermanentBaseScale (Vector3 theScale)
		{
				myBaseScale = theScale;
				myTransform.localScale = theScale;
		}
		
		public void triggerActualStatsAndStatusUpdatesForCurrentAbility ()
		{
				//hack get stats from somewhere


				MainStatsController.singleton.characterDidThisAbilityToEnemy (this, myCurrentlyAnimatingAbility, myTargetEnemyHolderController);
		}

		public void moveHolderToTargetAsPartOfAttackEnemy (float totalAnimationTime, bool matchTargetScale)
		{
				
				
				
				

				
				EnemyHolderController myTargetHolder = myTarget.GetComponent<EnemyHolderController> ();


				
				Vector2 myPos = (Vector2)myTransform.localPosition;
				

				Vector2 targetPos = myTargetHolder.returnAttackPosition ();

				Vector2 myTargetScale = myTargetHolder.returnStartingScale ();


				myBasePosition = myTransform.localPosition;
				myBaseScale = myTransform.localScale;

				if (matchTargetScale == false) {
						myTargetScale = myBaseScale;
				}

				


				MainMoveStuffController.singleton.doMoveMePositionAndScale (gameObject, myPos, targetPos, totalAnimationTime, myTargetScale);
				
				;



		}

		public void doMoveBackToHome (float time)
		{

				MainMoveStuffController.singleton.doMoveMePositionAndScale (gameObject, myTransform.localPosition, myBasePosition, time, myBaseScale);

		}

		public void attackIsComplete ()
		{
				MainTurnsController.singleton.tellMainTurnsThatCharacterHasFinishedMainTurn (myPositionID);
		}
	


		public Vector2 returnAttackPosition ()
		{
				return  (Vector2)myTransform.localPosition;
		}

		

	




}

