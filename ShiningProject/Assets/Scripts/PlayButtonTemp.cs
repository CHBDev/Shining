using UnityEngine;
using System.Collections;

public class PlayButtonTemp : MonoBehaviour
{



		// Use this for initialization
		void Start ()
		{
	


		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void OnGUI ()
		{

				if (PlayerStableController.singleton == null)
						return;

				if (PlayerStableController.singleton.listOfCharacters == null)
						return;

				if (PlayerStableController.singleton.listOfCharacters.Count > 0) {
						GUI.Label (new Rect (10, 10, 200, 50), "Character 1, XP: " + PersistedGameDataController.singleton.thePlayerDataController.myPlayerStableController.listOfCharacters [0].myXP);
				} else {
						GUI.Label (new Rect (10, 10, 200, 50), "Character 1, Empty");
				}

				if (PlayerStableController.singleton.listOfCharacters.Count > 1) {
						GUI.Label (new Rect (10, 60, 200, 50), "Character 2, XP: " + PersistedGameDataController.singleton.thePlayerDataController.myPlayerStableController.listOfCharacters [1].myXP);
				} else {
						GUI.Label (new Rect (10, 60, 200, 50), "Character 2, Empty");
				}

				if (PlayerStableController.singleton.listOfCharacters.Count > 2) {
						GUI.Label (new Rect (10, 110, 200, 50), "Character 3, XP: " + PersistedGameDataController.singleton.thePlayerDataController.myPlayerStableController.listOfCharacters [2].myXP);
				} else {
						GUI.Label (new Rect (10, 110, 200, 50), "Character 3, Empty");
				}



				if (GUI.Button (new Rect (Screen.width - 200, 0, 200, 50), "save data")) {
						PersistedGameDataController.singleton.SavePlayerData ();
				}

				if (GUI.Button (new Rect (Screen.width - 200, 75, 200, 50), "load data")) {
						PersistedGameDataController.singleton.LoadPlayerData ();
				}

				if (GUI.Button (new Rect (Screen.width - 200, 150, 200, 50), "delete data")) {
						PersistedGameDataController.singleton.DeletePlayerData ();
						PlayerDataController.singleton.resetAllData ();
				}

				if (GUI.Button (new Rect (Screen.width - 200, 300, 200, 50), "add 3 characters, random xp")) {


						int int1 = Random.Range (1, 4);
						int int2 = Random.Range (1, 4);
						int int3 = Random.Range (1, 4);

						CharacterPrefabHolderController.CharacterTypes enum1 = (CharacterPrefabHolderController.CharacterTypes)int1;
						CharacterPrefabHolderController.CharacterTypes enum2 = (CharacterPrefabHolderController.CharacterTypes)int2;
						CharacterPrefabHolderController.CharacterTypes enum3 = (CharacterPrefabHolderController.CharacterTypes)int3;

						Debug.Log ("int 1: " + int1 + ", enum1: " + enum1);
						Debug.Log ("int 2: " + int2 + ", enum2: " + enum2);
						Debug.Log ("int 3: " + int3 + ", enum3: " + enum3);

						PlayerStableController.singleton.addCharacterToStable (enum1, Random.Range (99, 9999));
						PlayerStableController.singleton.addCharacterToStable (enum2, Random.Range (99, 9999));
						PlayerStableController.singleton.addCharacterToStable (enum3, Random.Range (99, 9999));
				}

				if (GUI.Button (new Rect (Screen.width - 200, 400, 200, 50), "subtract 100 from char 2")) {
						PlayerStableController.singleton.listOfCharacters [1].myXP -= 100;
						
				}

				if (GUI.Button (new Rect (Screen.width / 2, Screen.height - 50, 200, 50), "PLAY")) {
						MainNavigationController.singleton.mainMenuCallsPlayButton ();

						
				}

		}
}
