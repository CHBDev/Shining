using UnityEngine;
using System.Collections;

public class CharacterHolderMouseInteraction : TouchOrMouseStuff
{

		private CharacterSelectorController theSelectorController;
		private GameObject theSelector;

		private CircleCollider2D myCharacterCollider;

		private Vector2 myCharacterColliderLoc;

		private CharacterHolderController myCharacterHolderController;

		// Use this for initialization
		void Start ()
		{
				canBeTouchedOrMoused = true;

				theSelector = GameObject.Find ("CharacterSelectorHolder");
				theSelectorController = theSelector.GetComponent<CharacterSelectorController> ();

				myCharacterCollider = gameObject.GetComponent<CircleCollider2D> ();

				myCharacterColliderLoc = (Vector2)transform.localPosition + myCharacterCollider.center;

				myTargetType = TargetType.CHARACTER;

				myCharacterHolderController = GetComponent<CharacterHolderController> ();


		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public override void touchOrMouseDownBegins (Vector2 loc)
		{
				if (canBeTouchedOrMoused == false) {
						return;
				}

				

				theSelectorController.startTracker (myCharacterColliderLoc);
		
		}
	
		public override void touchOrMouseMoved (Vector2 loc)
		{
		
				if (canBeTouchedOrMoused == false) {
						return;
				}

				theSelectorController.moveTracker (loc);
		
		}
	
		public override void touchOrMouseEndedNotAsTap (Vector2 loc)
		{

				


				if (canBeTouchedOrMoused == false) {
						return;
				}

				GameObject aTarget = theSelectorController.doIHaveATarget ();

				if (aTarget != null) {
						myCharacterHolderController.touchEndedWithTarget (aTarget);
				}

				theSelectorController.stopTracker ();
		
		
		}
	
		public override void touchOrMouseEndedAsSingleTap (Vector2 loc)
		{
				

				if (canBeTouchedOrMoused == false) {
						return;
				}

				theSelectorController.stopTracker ();
		
		}
	
		public override void touchOrMouseEndedAsDoubleTap (Vector2 loc)
		{
				
				if (canBeTouchedOrMoused == false) {
						return;
				}
				theSelectorController.stopTracker ();
		}
	
		public override void touchOrMouseCancelled (Vector2 loc)
		{
				
				if (canBeTouchedOrMoused == false) {
						return;
				}
				theSelectorController.stopTracker ();
		}
	
		public override void touchOrMouseCallsLongTouch (Vector2 loc)
		{
				
				if (canBeTouchedOrMoused == false) {
						return;
				}
		
		
		}
	

}
