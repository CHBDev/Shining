using UnityEngine;
using System.Collections;
using System;

public class SettingsController: MonoBehaviour
{


		


		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		

}


[Serializable]
public class SettingsSerializableObject
{
	

		public SettingsSerializableObject (SettingsController theController)
		{
				if (theController == null) {
						return;
				}
		}


}
