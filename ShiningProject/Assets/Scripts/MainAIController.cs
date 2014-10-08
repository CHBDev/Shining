using UnityEngine;
using System.Collections;

public class MainAIController : MonoBehaviour
{

		public static MainAIController singleton;



		public void setupFieldsOnThisEnemyForNextAction (EnemyHolderController theEnemy)
		{

				bool shouldAttackPlayer;
				MainStatsController.AbilitiesEnum thisAbility;

				if (Random.Range (0, 100) > 50) {
						shouldAttackPlayer = true;
						thisAbility = MainStatsController.AbilitiesEnum.AttackRangedSingleBig;

				} else {
						shouldAttackPlayer = false;
						thisAbility = MainStatsController.AbilitiesEnum.HealSingleBig;
				}



				GameObject theTarget;
				if (shouldAttackPlayer == true) {
						theTarget = MainTurnsController.singleton.characterHolderControllerArray [Random.Range (1, 3)].gameObject;

				} else {
						theTarget = MainTurnsController.singleton.enemyHolderControllerArray [1].gameObject;
				}

				theEnemy.myTarget = theTarget;
				theEnemy.myTargetTransform = theTarget.transform;
				theEnemy.myTargetTouchOrMouseStuff = theTarget.GetComponent<TouchOrMouseStuff> ();
				theEnemy.myNextTargetIsACharacter = shouldAttackPlayer;
				theEnemy.myNextAbilityToDo = thisAbility;
		}

		//maybe there's a "movement" among slots thing, not sure. Maybe all just automatically shift forward if open.
	
	
		void Awake ()
		{
				if (singleton == null) {
						
						singleton = this;

				} else if (singleton != this) {
						gameObject.SetActive (false);
						Destroy (gameObject);

				}
		}


		
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}


}


