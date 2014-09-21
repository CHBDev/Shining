using UnityEngine;
using System.Collections;

public class MainPhaseController : MonoBehaviour
{
	
		[HideInInspector]
		enum GamePhase
		{
				LOADING,
				MENU,
				GAMEPLAY}
		;

		GamePhase currentGamePhase;

		MainMouseController theMainMouse;



		// Use this for initialization
		void Start ()
		{
				theMainMouse = GameObject.Find ("MainMouse").GetComponent<MainMouseController> ();
				//hack
				currentGamePhase = GamePhase.GAMEPLAY;
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (currentGamePhase == GamePhase.LOADING) {
						theMainMouse.inputEnabled = false;
				} else {
						theMainMouse.inputEnabled = true;
				}
		}
}