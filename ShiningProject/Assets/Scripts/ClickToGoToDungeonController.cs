using UnityEngine;
using System.Collections;

public class ClickToGoToDungeonController : MonoBehaviour
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
				if (GUI.Button (new Rect (0, 0, 200, 50), "TEMP DUNGEON")) {
						MainHubData.singleton.hackEnterDungeonFromHackMenu ();
				}
		}
}
