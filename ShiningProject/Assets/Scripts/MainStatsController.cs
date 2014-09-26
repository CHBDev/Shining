using UnityEngine;
using System.Collections;

public class MainStatsController : MonoBehaviour
{



		public static MainStatsController singleton;
	
	
		void Awake ()
		{
				if (singleton == null) {
						DontDestroyOnLoad (gameObject);
						singleton = this;
				} else if (singleton != this) {
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

		public void getLevelUpStats (CharacterHolderController theCharacter)
		{
				//do something to get the relevent stats and abilities for a character of type and level
				//what if we are doing special training per character Hmm, this doesnt work.

				//put the "next level up xp" value onto the character itself
				//then it calls this when it levels up

				//sets max HP, sets new abilities, sets attack modifier, etc


		}

		



}
