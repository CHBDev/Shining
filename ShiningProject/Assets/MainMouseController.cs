using UnityEngine;
using System.Collections;

public class MainMouseController : MonoBehaviour
{
		static float kTimeBeforeRegisteringLongTouch = .6f;
		static float kDistanceBeforeRegisteringMove = 5.0f;

		static float kMaxTimeForMouseClickToHappen = .16f;
		static float kMaxTimeBetweenFirstMouseDownAndSecondMouseDownForDoubleClick = .4f;
	
		public GameObject testCirclePrefab;
	
		GameObject testCircleObject;
	
		RuntimePlatform thePlatform;
		DeviceType theDeviceType;

		//hack
		private CharacterSelectorController theCharacterSelector;

		[HideInInspector]
		public Collider2D[]
				colliderArray;

		private TouchOrMouseStuff mouseObjectScriptTouchedDown, mouseObjectScriptBeingDragged;
	
	 


		//TOUCH CALCS
		
	
		bool thereIsAnActiveTouchOrButtonDown = false;

		//Mouse stuff to match touch behavior
		float mouseTimeSinceLastClickStarted = 0;
		float mouseTimeSinceFirstClickStarted = 0;
		Vector2 mousePositionOnFirstDown;
		
		Vector2 mousePositionOnLastUpdate;

		bool mouseLongClickCurrentlyDown = false;
		bool mouseFirstTapRegistered = false;
		bool mousePointHasStayedCloseToStartingPoint = false;


		// Use this for initialization
		void Start ()
		{
				Input.multiTouchEnabled = false;

				Debug.Log ("" + SystemInfo.deviceModel);
				Debug.Log ("" + SystemInfo.deviceType);
				Debug.Log ("" + SystemInfo.operatingSystem);

				//thePlatform = Application.platform;
				theDeviceType = SystemInfo.deviceType;

				theCharacterSelector = GameObject.Find ("CharacterSelectorHolder").GetComponent<CharacterSelectorController> ();

				colliderArray = new Collider2D[12];

		}
	
		// Update is called once per frame
		void Update ()
		{
				if (theDeviceType == DeviceType.Handheld) {
						if (Input.touchCount > 0) {

								if (thereIsAnActiveTouchOrButtonDown == false) {
										

										Touch aTouch = Input.GetTouch (0);
										thereIsAnActiveTouchOrButtonDown = true;
										touchOrMouseDownBegins (Camera.main.ScreenToWorldPoint (aTouch.position));
										
												

								} else {
										Touch aTouch = Input.GetTouch (0);


										if (aTouch.phase == TouchPhase.Moved) {

												if (Mathf.Abs (aTouch.deltaPosition.x) > kDistanceBeforeRegisteringMove || Mathf.Abs (aTouch.deltaPosition.y) > kDistanceBeforeRegisteringMove) {
														
														touchOrMouseMoved (Camera.main.ScreenToWorldPoint (aTouch.position));
														
												} 
														
												
										} else if (aTouch.phase == TouchPhase.Ended) {
												
												
												//figure out if it's a tap
												if (aTouch.tapCount == 1) {
														
														touchOrMouseEndedAsSingleTap (Camera.main.ScreenToWorldPoint (aTouch.position));
												} else if (aTouch.tapCount == 2) {
														
														touchOrMouseEndedAsDoubleTap (Camera.main.ScreenToWorldPoint (aTouch.position));
												} else {
														touchOrMouseEndedNotAsTap (Camera.main.ScreenToWorldPoint (aTouch.position));
												}

												//figure out if it's a double tap

												//else just pass end
												
												
												thereIsAnActiveTouchOrButtonDown = false;
												

										} else if (aTouch.phase == TouchPhase.Canceled) {
												
												touchOrMouseCancelled (Camera.main.ScreenToWorldPoint (aTouch.position));
												
												thereIsAnActiveTouchOrButtonDown = false;
												
										} else if (aTouch.phase == TouchPhase.Stationary) {
												//figure out if it's a long touch

												touchOrMouseCallsLongTouch (Camera.main.ScreenToWorldPoint (aTouch.position));
												
												
										}
								}
						}

									
						

				

				} else if (theDeviceType == DeviceType.Desktop) {



						if (Input.GetMouseButtonDown (0)) {
								mousePositionOnLastUpdate = Input.mousePosition;

								thereIsAnActiveTouchOrButtonDown = true;
								mouseLongClickCurrentlyDown = false;
								mouseTimeSinceLastClickStarted = 0;

								touchOrMouseDownBegins (Camera.main.ScreenToWorldPoint (Input.mousePosition));

								if (mouseFirstTapRegistered == false) {
										
										mouseTimeSinceFirstClickStarted = 0;
										mousePositionOnFirstDown = Input.mousePosition;
								} else {

										if (mouseTimeSinceFirstClickStarted > kMaxTimeBetweenFirstMouseDownAndSecondMouseDownForDoubleClick) {
												mouseFirstTapRegistered = false;
												mouseTimeSinceFirstClickStarted = 0;

										} else {
												//there is chance next click will make a double click
												
										}


										
								}



						} else if (Input.GetMouseButtonUp (0)) {
								
								if (mouseTimeSinceLastClickStarted < kMaxTimeForMouseClickToHappen) {
										//then we have a click
										if (mouseFirstTapRegistered == true) {
												//then this is a double click
												touchOrMouseEndedAsDoubleTap (Camera.main.ScreenToWorldPoint (Input.mousePosition));

										} else {
												//we have a single click
												touchOrMouseEndedAsSingleTap (Camera.main.ScreenToWorldPoint (Input.mousePosition));
												mouseFirstTapRegistered = true;
										}


								} else {
										//no click
										touchOrMouseEndedNotAsTap (Camera.main.ScreenToWorldPoint (Input.mousePosition));
										mouseFirstTapRegistered = true;
										mouseTimeSinceLastClickStarted = 0;
										mouseTimeSinceFirstClickStarted = 0;
								}

								thereIsAnActiveTouchOrButtonDown = false;
								mouseLongClickCurrentlyDown = false;
								
								

								
								
						} else if (thereIsAnActiveTouchOrButtonDown == true) {

								if (Mathf.Abs (Input.mousePosition.x - mousePositionOnLastUpdate.x) > kDistanceBeforeRegisteringMove 
										|| Mathf.Abs (Input.mousePosition.y - mousePositionOnLastUpdate.y) > kDistanceBeforeRegisteringMove) {
				
										//we have mouse movement
										touchOrMouseMoved (Camera.main.ScreenToWorldPoint (Input.mousePosition));
										mouseFirstTapRegistered = false;
										
								} else {
										//maybe we have a long touch
										if (mouseLongClickCurrentlyDown == false && mouseTimeSinceLastClickStarted > kTimeBeforeRegisteringLongTouch) {

												touchOrMouseCallsLongTouch (Camera.main.ScreenToWorldPoint (Input.mousePosition));
												mouseLongClickCurrentlyDown = true;
												mouseFirstTapRegistered = false;
												

										}
								}
								

						}

						
						//update timers 
						mouseTimeSinceLastClickStarted = mouseTimeSinceLastClickStarted + Time.deltaTime;
			
						if (mouseFirstTapRegistered == true) {
								mouseTimeSinceFirstClickStarted = mouseTimeSinceFirstClickStarted + Time.deltaTime;
						}
				}

				
				
				
		}
	

		private void touchOrMouseDownBegins (Vector2 loc)
		{
				


				mouseObjectScriptTouchedDown = this.findThingThatTouchOrMouseShouldInteractWith (loc);

				if (mouseObjectScriptTouchedDown != null) {
						

						mouseObjectScriptTouchedDown.touchOrMouseDownBegins (loc);

						
				} else {
						
						return;
				}
				


		}

		private void touchOrMouseMoved (Vector2 loc)
		{
				if (mouseObjectScriptTouchedDown == null) {
						return;
				}

				mouseObjectScriptTouchedDown.touchOrMouseMoved (loc);


				
		}

		

		private void touchOrMouseEndedNotAsTap (Vector2 loc)
		{

				if (mouseObjectScriptTouchedDown == null) {
						return;
				}

				mouseObjectScriptTouchedDown.touchOrMouseEndedNotAsTap (loc);


		}

		private void touchOrMouseEndedAsSingleTap (Vector2 loc)
		{
				//Debug.Log ("SINGLE TAP");
				if (mouseObjectScriptTouchedDown == null) {
						return;
				}

				mouseObjectScriptTouchedDown.touchOrMouseEndedAsSingleTap (loc);
				
		}

		private void touchOrMouseEndedAsDoubleTap (Vector2 loc)
		{
				//Debug.Log ("DOUBLE TAP");
				if (mouseObjectScriptTouchedDown == null) {
						return;
				}
				
		}

		private void touchOrMouseCancelled (Vector2 loc)
		{
				if (mouseObjectScriptTouchedDown == null) {
						return;
				}
				mouseObjectScriptTouchedDown.touchOrMouseCancelled (loc);
		}

		private void touchOrMouseCallsLongTouch (Vector2 loc)
		{

				//Debug.Log ("LONG TOUCH START");
				if (mouseObjectScriptTouchedDown == null) {
						return;
				}
				mouseObjectScriptTouchedDown.touchOrMouseCallsLongTouch (loc);
				
				
		}

		private TouchOrMouseStuff findThingThatTouchOrMouseShouldInteractWith (Vector2 loc)
		{
				//get all objects at mouse point

				

				int numHit = Physics2D.OverlapPointNonAlloc (loc, colliderArray);
				//Debug.Log ("num hit " + numHit);


				
				if (numHit > 0) {

						
						foreach (Collider2D aCollider in colliderArray) {

								if (aCollider == null) {
										break;
								}

								GameObject theGameObject = aCollider.gameObject;

								if (theGameObject == null) {

										Debug.Log ("game object on collider is null");
										break;
								}

								TouchOrMouseStuff theScript = theGameObject.GetComponent<TouchOrMouseStuff> ();

								if (theScript != null) {

										if (theScript.canBeTouchedOrMoused == true) {
										
												return theScript;
										
										}
								}



						}
				}

				return null;
		}
	

/*
		function Update(){
			if(platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer){
				if(Input.touchCount > 0) {
					if(Input.GetTouch(0).phase == TouchPhase.Began){
						checkTouch(Input.GetTouch(0).position);
					}
				}
			}else if(platform == RuntimePlatform.WindowsEditor){
				if(Input.GetMouseButtonDown(0)) {
					checkTouch(Input.mousePosition);
				}
			}
		}
		
		function checkTouch(pos){
			var wp : Vector3 = Camera.main.ScreenToWorldPoint(pos);
			var touchPos : Vector2 = new Vector2(wp.x, wp.y);
			var hit = Physics2D.OverlapPoint(touchPos);
			
			if(hit){
				Debug.Log(hit.transform.gameObject.name);
				hit.transform.gameObject.SendMessage('Clicked',0,SendMessageOptions.DontRequireReceiver);
			}
		}

*/

}
