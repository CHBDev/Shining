using UnityEngine;
using System.Collections;

public class MainPhaseController : MonoBehaviour
{

		public static MainPhaseController singleton;
	
	
		void Awake ()
		{
				if (singleton == null) {
						DontDestroyOnLoad (gameObject);
						singleton = this;
				} else if (singleton != this) {
						Destroy (gameObject);
				}
		}

	
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
				theMainMouse = MainMouseController.singleton;
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