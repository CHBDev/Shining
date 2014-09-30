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
		public CharacterPrefabHolderController.CharacterTypes 
				myCharacterTypeEnum;
	
		Transform myTransform;
		

		CharacterHolderMouseInteraction myCharacterHolderMouseInteraction;

		GameObject myTarget;
		Transform myTargetTransform;
		TouchOrMouseStuff myTargetTouchOrMouseStuff;

		float cameraWidth;
		float cameraHeight;

		private Vector2 myBasePosition;
		private Vector2 myBaseScale;
		private string myBaseLayer;

		public int myPositionID;

		void Awake ()
		{

		}

		// Use this for initialization
		void Start ()
		{

				myCharacterActualObject = MainMakeStuffController.instantiatePrefabInObject (myCharacterActualPrefab, gameObject);

				
				myCharacterActualController = myCharacterActualObject.GetComponent<CharacterActualController> ();
				myCharacterActualController.setMyType (myCharacterTypeEnum);
				myCharacterActualController.myCharacterHolderController = this;


				
				myCharacterHolderMouseInteraction = GetComponent<CharacterHolderMouseInteraction> ();

				myTransform = transform;

			
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




				doSomethingToMyTarget ();

		}

		private void doSomethingToMyTarget ()
		{
				if (myTargetTouchOrMouseStuff.myTargetType == TouchOrMouseStuff.TargetType.ENEMY) {
						
						myTurnThisRoundIsAvailable = false;
						myCharacterActualController.tellActualToBeginAttackAnimation ();


				} else {
						assistCharacter ();
				}
		}
	

		

		public void moveHolderToTargetAsPartOfAttackEnemy (float totalAnimationTime)
		{
				
				
				
				

				
				EnemyHolderController myTargetHolder = myTarget.GetComponent<EnemyHolderController> ();


				
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
				MainTurnsController.singleton.tellMainTurnsThatCharacterHasFinishedMainTurn (myPositionID);
		}
	


		private void assistCharacter ()
		{
				//do stuff
		}

		public Vector2 returnAttackPosition ()
		{
				return  (Vector2)myTransform.localPosition;
		}

		public void setupCharacterUsingArtPrefab (GameObject artPrefab)
		{

		}
	




}

