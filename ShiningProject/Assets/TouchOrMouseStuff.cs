using UnityEngine;
using System.Collections;

public class TouchOrMouseStuff : MonoBehaviour
{



		[HideInInspector]
		public bool
				canBeTouchedOrMoused;

		
		public enum TargetType
		{
				NULL,
				ENEMY,
				CHARACTER,
				OTHER}
		;


		[HideInInspector]
		public TargetType myTargetType;
		


		// Use this for initialization
		void Start ()
		{

		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public virtual void touchOrMouseDownBegins (Vector2 loc)
		{
				


		}
	
		public virtual void touchOrMouseMoved (Vector2 loc)
		{

				
		
		}

		public virtual void touchOrMouseEndedNotAsTap (Vector2 loc)
		{
		
				
		
		
		}
	
		public virtual void touchOrMouseEndedAsSingleTap (Vector2 loc)
		{
				
		
		}
	
		public virtual void touchOrMouseEndedAsDoubleTap (Vector2 loc)
		{

				
		}
	
		public virtual void touchOrMouseCancelled (Vector2 loc)
		{
				
		}
	
		public virtual void touchOrMouseCallsLongTouch (Vector2 loc)
		{
		
		
		}
	
	
	
	
}
