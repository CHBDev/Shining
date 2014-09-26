using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour
{

		float totalTimeToTransition;


		// Use this for initialization
		void Start ()
		{
				totalTimeToTransition = 3.0f;



		}
	
		// Update is called once per frame
		void Update ()
		{
	
				totalTimeToTransition -= Time.deltaTime;

				Debug.Log ("totalTime " + totalTimeToTransition);


				if (totalTimeToTransition <= 0) {
						
						Application.LoadLevel ("FirstPersonScene1");

				}

		}
}
