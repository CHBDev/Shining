using UnityEngine;
using System.Collections;

public class CharacterSelectorController : MonoBehaviour
{

		private GameObject myBase;
		private GameObject myMiddle;
		private GameObject myMiddleUp1;
		private GameObject myMiddleDown1;
		//private GameObject myTargetLowerPiece;
		private GameObject myReticleUpperPiece;

		private Transform myBaseTransform;
		private Transform myMiddleTransform;
		private Transform myMiddleUp1Transform;
		private Transform myMiddleDown1Transform;
		//private Transform myTargetLowerPieceTransform;
		private Transform myReticletUpperPieceTransform;
		
		private Transform myTransform;

		private float screenHeight;
		private float halfScreenHeight;

		public float scaleModifierForTarget = 1.0f;

		public GameObject[] myListOfPieces;

		private float distanceFromStuckTarget;
		private bool shouldMoveTracker;

		private Collider2D[] arrayOfCollider2D;

		private CircleCollider2D theTopCollider;

		private int hitCount;

		private GameObject thingImStuckTo;
		private Vector2 thingImStuckToPosition;
		private float thingImStuckToRadius;
		private Transform thingImStuckToTransform;
		private float thingImStuckToLocalScaleY;

		private GameObject topObject;

		private TouchOrMouseStuff theTouchScript;

		public float fingerOffsetPercentOfScreenHeight = .05f;

		private Vector2 fingerOffsetActual;

		bool stopScaling = false;


		//private CircleCollider2D myReticleCollider;

		// Use this for initialization
		void Start ()
		{

				myTransform = transform;

				screenHeight = Camera.main.orthographicSize * 2.0f * 100.0f;
				halfScreenHeight = (screenHeight / 2.0f);

				myBase = myTransform.FindChild ("CharacterSelectorBase").gameObject;
				myMiddle = myTransform.FindChild ("CharacterSelectorMiddle").gameObject;
				myMiddleDown1 = myTransform.FindChild ("CharacterSelectorMiddleDown1").gameObject;
				myMiddleUp1 = myTransform.FindChild ("CharacterSelectorMiddleUp1").gameObject;
				
				myReticleUpperPiece = myTransform.FindChild ("CharacterSelectorReticle").gameObject;
				//myTargetLowerPiece = myTargetUpperPiece.transform.FindChild ("CharacterSelectorBelowTarget").gameObject;

				myBaseTransform = myBase.transform;
				myMiddleTransform = myMiddle.transform;
				myMiddleDown1Transform = myMiddleDown1.transform;
				myMiddleUp1Transform = myMiddleUp1.transform;
				myReticletUpperPieceTransform = myReticleUpperPiece.transform;

				myListOfPieces = new GameObject[] {
						myBase,
						myMiddle,
						myMiddleDown1,
						myMiddleUp1,
						myReticleUpperPiece
				};

				setHidden (true);

				arrayOfCollider2D = new Collider2D[12];

				fingerOffsetActual = new Vector2 (0, fingerOffsetPercentOfScreenHeight * Camera.main.orthographicSize * 2);

				//myReticleCollider = (CircleCollider2D)myReticleUpperPiece.collider2D; 
				
	
		}
	
		// Update is called once per frame
		void Update ()
		{
			
		}

		public void startTracker (Vector2 loc)
		{
				setHidden (false);

				myBaseTransform.localPosition = loc;
				myMiddleTransform.localPosition = loc;
				myMiddleDown1Transform.localPosition = loc;
				myMiddleUp1Transform.localPosition = loc;
				myReticletUpperPieceTransform.localPosition = loc + fingerOffsetActual;

		}

		public void moveTracker (Vector2 loc)
		{
				topObject = null;
				hitCount = 0;

				loc = loc + fingerOffsetActual;
				
				hitCount = Physics2D.OverlapPointNonAlloc (loc, arrayOfCollider2D);


				if (hitCount > 0) {
			
						foreach (Collider2D theCollider in arrayOfCollider2D) {
				
								if (theCollider == null) {
										continue;
								}
				
								topObject = theCollider.gameObject;

								if (topObject == null) {
										continue;
								}

								if (thingImStuckTo == topObject && Vector2.Distance (loc, thingImStuckToPosition) * thingImStuckToLocalScaleY < thingImStuckToRadius * 1.01f) {
										return;
								} else {
										thingImStuckTo = null;
					
								}

								theTouchScript = topObject.GetComponent<TouchOrMouseStuff> ();
				
								if (theTouchScript == null) {
										continue;
								}
				
								if (theTouchScript.myTargetType == TouchOrMouseStuff.TargetType.ENEMY) {
					
										theTopCollider = (CircleCollider2D)theCollider;
										thingImStuckTo = topObject;
										thingImStuckToTransform = topObject.transform;
										thingImStuckToRadius = theTopCollider.radius;
										thingImStuckToLocalScaleY = thingImStuckToTransform.localScale.y;
					
										thingImStuckToPosition = (Vector2)thingImStuckToTransform.localPosition + (theTopCollider.center * thingImStuckToLocalScaleY);
										loc = thingImStuckToPosition;
					
										break;
								} else if (theTouchScript.myTargetType == TouchOrMouseStuff.TargetType.CHARACTER) {
										break;
								}

						}

						
			
				} else {
						thingImStuckTo = null;
				}



				myReticletUpperPieceTransform.localPosition = loc;
				myMiddleTransform.localPosition = Vector3.Lerp (myBaseTransform.localPosition, myReticletUpperPieceTransform.localPosition, .5f);
				myMiddleDown1Transform.localPosition = Vector3.Lerp (myBaseTransform.localPosition, myReticletUpperPieceTransform.localPosition, .25f);
				myMiddleUp1Transform.localPosition = Vector3.Lerp (myBaseTransform.localPosition, myReticletUpperPieceTransform.localPosition, .75f);

				float convertedPositionY = halfScreenHeight - (myReticletUpperPieceTransform.localPosition.y * 100);
				

				if (loc.y > 2.6) {
						stopScaling = true;
				} else {
						stopScaling = false;
				}

				float percentOfScreen = convertedPositionY / screenHeight;

				float finalMod = percentOfScreen + scaleModifierForTarget;
				if (stopScaling == false) {
						myReticletUpperPieceTransform.localScale = new Vector3 (finalMod, finalMod, 1);

				}
				
				convertedPositionY = halfScreenHeight - (myMiddleUp1Transform.localPosition.y * 100);
				percentOfScreen = convertedPositionY / screenHeight;
				finalMod = percentOfScreen + scaleModifierForTarget;
				if (stopScaling == false) {
						myMiddleUp1Transform.localScale = new Vector3 (finalMod, finalMod, 1);
				}
				

				convertedPositionY = halfScreenHeight - (myMiddleTransform.localPosition.y * 100);
				percentOfScreen = convertedPositionY / screenHeight;
				finalMod = percentOfScreen + scaleModifierForTarget;
				if (stopScaling == false) {
						myMiddleTransform.localScale = new Vector3 (finalMod, finalMod, 1);
				}

				convertedPositionY = halfScreenHeight - (myMiddleDown1Transform.localPosition.y * 100);
				percentOfScreen = convertedPositionY / screenHeight;
				finalMod = percentOfScreen + scaleModifierForTarget;
				if (stopScaling == false) {
						myMiddleDown1Transform.localScale = new Vector3 (finalMod, finalMod, 1);
				}

		}

		public void stopTracker ()
		{
				//Debug.Log ("stop tracker");
				thingImStuckTo = null;
				setHidden (true);


		}

		public GameObject doIHaveATarget ()
		{
				return thingImStuckTo;
		}

		public void setHidden (bool hide)
		{
				if (hide == true) {
						foreach (GameObject obj in myListOfPieces) {
				
								obj.SetActive (false);
						}
				} else {
						foreach (GameObject obj in myListOfPieces) {
				
								obj.SetActive (true);
						}
				}
				
		}


}

		
