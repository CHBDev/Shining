using UnityEngine;
using System.Collections;
using System;

public class AchievementsController: MonoBehaviour
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
public class AchievementsSerializableObject
{
	

		public AchievementsSerializableObject (AchievementsController theController)
		{
				if (theController == null) {
						return;
				}
		}

}
