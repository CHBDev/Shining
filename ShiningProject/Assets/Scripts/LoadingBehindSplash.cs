using UnityEngine;
using System.Collections;

public class LoadingBehindSplash : MonoBehaviour
{

		float countDownToLoadOut = 1.0f;
		bool savedInfoIsDoneLoadingIn = false;
		
		void Awake ()
		{
				
		}

		void Start ()
		{
				PersistedGameDataController.singleton.LoadAll ();
				savedInfoIsDoneLoadingIn = true;
	
			
				

		}



	
		// Update is called once per frame
		void Update ()
		{
			
				
				if (countDownToLoadOut > 0) {
						countDownToLoadOut = countDownToLoadOut - Time.deltaTime;
						return;
				}



				if (savedInfoIsDoneLoadingIn == true) {
						Application.LoadLevel ("MainMenu");

				}

		}
}
