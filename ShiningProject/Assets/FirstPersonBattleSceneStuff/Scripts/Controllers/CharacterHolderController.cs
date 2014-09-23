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

		
		public GameObject myCharacterActualPrefab;

		[HideInInspector]
		public GameObject
				myCharacterActualObject;
		private Animator myCharacterActualAnimator;

		[HideInInspector]
		public Vector2
				myLocation;

		[HideInInspector]
		public CharacterDataSet.CharacterTypes_Enum
				myCharacterTypeEnum;

		GameObject theGameHolder;
		Transform myTransform;
		RelativeStuff LocationScaler;

		CharacterHolderMouseInteraction myCharacterHolderMouseInteraction;

		GameObject myTarget;
		Transform myTargetTransform;
		TouchOrMouseStuff myTargetTouchOrMouseStuff;

		float cameraWidth;
		float cameraHeight;

		private Vector2 myBasePosition;
		private Vector2 myBaseScale;
		private string myBaseLayer;


		// Use this for initialization
		void Start ()
		{

				myCharacterActualObject = RelativeStuff.instantiatePrefabInObjectAndMakeRelative (myCharacterActualPrefab, gameObject);
				
				myCharacterActualObject.GetComponent<CharacterActualController> ().changeMyType (myCharacterTypeEnum);
				myCharacterActualAnimator = myCharacterActualObject.GetComponent<Animator> ();

				myCharacterHolderMouseInteraction = GetComponent<CharacterHolderMouseInteraction> ();

				myTransform = transform;

				//cameraHeight = Camera.main.orthographicSize * 2;
				//cameraWidth = cameraHeight * Camera.main.aspect;

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
						
						attackEnemy ();
						


				} else {
						assistCharacter ();
				}
		}

		private void attackEnemy ()
		{
				myCharacterActualAnimator.SetTrigger ("attackEnemy");

				Debug.Log ("Attack enemy");
				//do stuff
				myTurnThisRoundIsAvailable = false;

				
				EnemyHolderController myTargetHolder = myTarget.GetComponent<EnemyHolderController> ();


				//hack
				Vector2 myPos = (Vector2)myTransform.localPosition;
				//Vector2 myPos = (Vector2)myCharacterActualObject.transform.localPosition;

				Vector2 targetPos = myTargetHolder.returnAttackPosition ();

				/*
				float highestPoint = targetPos.y * 1.5f;

				Vector2 vectorToTarget = myPos + targetPos;
				Debug.Log (vectorToTarget);

				vectorToTarget.Normalize ();
				

				Vector2 lerp25 = Vector2.Lerp (myPos, targetPos, .25f);

				Vector2 lerp50 = Vector2.Lerp (myPos, targetPos, .50f);
				Vector2 lerp75 = Vector2.Lerp (myPos, targetPos, .75f);

				float float25 = lerp25.x;
				float float50 = lerp50.x;
				float float75 = lerp75.x;

				float float25y = lerp25.y;
				float float50y = lerp50.y;
				float float75y = lerp75.y;


				Vector2 firstArc = new Vector2 (float25, float25y);
				Vector2 midArc = new Vector2 (float50, float50y);
				Vector2 lastArc = new Vector2 (float75, float75y);

				Debug.Log (firstArc);
				Debug.Log (midArc);
				Debug.Log (lastArc);
				*/

				doAttackAnimation (gameObject, myPos, targetPos, .5f, myTargetTransform.localScale);
				
				;



		}

		private void assistCharacter ()
		{
				//do stuff
		}

		public void endAttack ()
		{
				myCharacterActualAnimator.SetTrigger ("endAttck");
		}

		private void doAttackAnimation (GameObject aThing, Vector2 StartPos, Vector2 EndPos, float time1, Vector2 endScale)
		{
				AnimationCurve theXPath = AnimationCurve.Linear (0, StartPos.x, time1, EndPos.x);
				AnimationCurve theYPath = AnimationCurve.Linear (0, StartPos.y, time1, EndPos.y);
				
				AnimationCurve theScaleX = AnimationCurve.Linear (0, aThing.transform.localScale.x, time1, endScale.x);
				AnimationCurve theScaleY = AnimationCurve.Linear (0, aThing.transform.localScale.y, time1, endScale.y);



				

				AnimationClip clip = new AnimationClip ();

				clip.SetCurve ("", typeof(Transform), "localPosition.x", theXPath);
				clip.SetCurve ("", typeof(Transform), "localPosition.y", theYPath);
				clip.SetCurve ("", typeof(Transform), "localScale.x", theScaleX);
				clip.SetCurve ("", typeof(Transform), "localScale.y", theScaleY);



		
				if (aThing.GetComponent ("Animation") == null) {
						aThing.AddComponent ("Animation");
				}

				Animation theAnimation = aThing.GetComponent<Animation> ();
			
		
				theAnimation.AddClip (clip, "clip");
				

				
				//theAnimation ["clipX"].blendMode = AnimationBlendMode.Additive;
				//theAnimation ["clipY"].blendMode = AnimationBlendMode.Additive;
				//theAnimation.Play ("clipY");
				//theAnimation.Play ("clipY");
				theAnimation.Play ("clip");
				//TempGO.animation.wrapMode = WrapMode.PingPong;


		}


}

