using UnityEngine;
using System.Collections;

public class EnemyCoroutines: MonoBehaviour
{

		public enum AnimationSpeedSlot
		{
				STOP = 0,
				HALF = 1,
				ONE,
				ONEANDAHALF,
				DOUBLE}
		;


		Animator theAnimator;

		public bool shouldDoBlinkRoutine;
		public float blinkRoutineInterval;
		
		public AnimationSpeedSlot bobSpeedSlotOf5;

		public bool shouldDoFidgetRoutine;
		public float fidgetRoutineInterval;


		// Use this for initialization
		void Start ()
		{
				theAnimator = gameObject.GetComponent<Animator> ();

				if (shouldDoBlinkRoutine) {
						StartCoroutine ("EnemyBlinkRoutine");
				}

				theAnimator.SetInteger ("EnemyBobSpeedInt", (int)bobSpeedSlotOf5);
				theAnimator.SetTrigger ("EnemyShouldChangeBobSpeed");

				

				StartCoroutine ("EnemyOverAllSpeedRandomizer");

				theAnimator.speed = 1.0f + (Random.Range (-250, 250) / 1000.0f);



				

		}

		IEnumerator EnemyBlinkRoutine ()
		{
				float seconds = 0.0f;

				
		
				while (true) {
						for (float timer = 0; timer < 1; timer += Time.deltaTime)
								yield return 0;
			
						seconds = seconds + 1.0f;

						if (seconds >= blinkRoutineInterval + (Random.Range (-7, 7) / 10.0f)) {

								if (Random.Range (0, 2) > 0) {

										theAnimator.SetBool ("EnemyShouldBlink", true);
										seconds = 0.0f;
								}
						} else {
								theAnimator.SetBool ("EnemyShouldBlink", false);
						}

			
				}
		}

		IEnumerator EnemyOverAllSpeedRandomizer ()
		{
				float seconds = 0.0f;
		
		
		
				while (true) {
						for (float timer = 0; timer < 1; timer += Time.deltaTime)
								yield return 0;
			
						seconds = seconds + 1.0f;
			
						if (seconds >= 10.0f + (Random.Range (-11, 11) / 10.0f)) {
				
								if (Random.Range (0, 2) > 0) {

										
										theAnimator.speed = 1.0f + (Random.Range (-250, 250) / 1000.0f);
								
								}

								seconds = 0.0f;
						}
				}
			
			
		}
		
	

		// Update is called once per frame
		void Update ()
		{
	



		}
}
