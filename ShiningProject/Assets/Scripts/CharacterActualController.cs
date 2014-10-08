using UnityEngine;
using System.Collections;

public class CharacterActualController : MonoBehaviour
{

		

		public CharacterDataSet myDataSet;
		[HideInInspector]
		public CharacterHolderController
				myCharacterHolderController;

		[HideInInspector]
		public CharacterArtController
				myCharacterArtController;

		[HideInInspector]
		public GameObject
				myCharacterArtObject;

		[HideInInspector]
		public GameObject
				myCharacterArtPrefab;

		[HideInInspector]
		public Animator
				myCharacterActualAnimator;

		

		// Use this for initialization
		void Start ()
		{

				myCharacterActualAnimator = gameObject.GetComponent<Animator> ();

		}

		public void doAttackMovementToTargetOnHolder (float time)
		{
				myCharacterHolderController.moveHolderToTargetAsPartOfAttackEnemy (time, true);
		}

		public void doReturnMovementBackToHome (float time)
		{
				myCharacterHolderController.doMoveBackToHome (time);
		}

		public void tellActualAttackAnimationReachedTarget ()
		{
				//hack, because the animation should really decide when to do the actual popups, etc, bur for now, just got tehre is fine
				myCharacterHolderController.triggerActualStatsAndStatusUpdatesForCurrentAbility ();
				myCharacterActualAnimator.SetTrigger ("attackReachedEnemy");
		}

		public void tellActualToBeginAttackAnimation ()
		{
				myCharacterActualAnimator.SetTrigger ("attackMoveToEnemy");
		

		}

		public void tellActualAnimationBackHomeFinished ()
		{
				myCharacterActualAnimator.SetTrigger ("attackComplete");
				myCharacterHolderController.attackIsComplete ();
		}

		public void tellActualAttackReachedEnemyAnimationComplete ()
		{
				myCharacterActualAnimator.SetTrigger ("attackMoveBackHome");
		}


		public void setMyType (CharacterPrefabBucketController.CharacterTypes  theType)
		{

				if (myCharacterArtObject != null) {
						Destroy (myCharacterArtObject);
				}
				
				myCharacterArtPrefab = MainMakeStuffController.returnCharacterPrefabOfType (theType);
				myCharacterArtObject = MainMakeStuffController.instantiatePrefabInObject (myCharacterArtPrefab, gameObject);
				myCharacterArtController = myCharacterArtObject.GetComponent<CharacterArtController> ();
						
			
				
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
