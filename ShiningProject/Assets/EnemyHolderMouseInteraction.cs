using UnityEngine;
using System.Collections;

public class EnemyHolderMouseInteraction : TouchOrMouseStuff
{

		// Use this for initialization
		void Start ()
		{
				canBeTouchedOrMoused = false;
				isAnEnemy = true;
				isACharacter = false;

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
		
		
		}
	
		public override void touchOrMouseMoved (Vector2 loc)
		{
		
				if (canBeTouchedOrMoused == false) {
						return;
				}
		
		}
	
		public override void touchOrMouseEndedNotAsTap (Vector2 loc)
		{
		
				if (canBeTouchedOrMoused == false) {
						return;
				}
		
		
		}
	
		public override void touchOrMouseEndedAsSingleTap (Vector2 loc)
		{
				if (canBeTouchedOrMoused == false) {
						return;
				}
		
		}
	
		public override void touchOrMouseEndedAsDoubleTap (Vector2 loc)
		{
		
				if (canBeTouchedOrMoused == false) {
						return;
				}
		}
	
		public override void touchOrMouseCancelled (Vector2 loc)
		{
				if (canBeTouchedOrMoused == false) {
						return;
				}
		}
	
		public override void touchOrMouseCallsLongTouch (Vector2 loc)
		{
		
				if (canBeTouchedOrMoused == false) {
						return;
				}
		
		
		}

}
