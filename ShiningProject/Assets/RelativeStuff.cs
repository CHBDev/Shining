using UnityEngine;
using System.Collections;

public class RelativeStuff : MonoBehaviour
{

		
		

		// Use this for initialization
		void Start ()
		{
				
		}


		// Update is called once per frame
		void Update ()
		{
	
		}

		public static GameObject instantiatePrefabInObjectAndMakeRelative (GameObject aChild, GameObject aParent, Vector2 aPos)
		{

			

				//Debug.Log (myTransform.localScale);

				GameObject tempObj = (GameObject)Instantiate (aChild);
				Transform childTransform = tempObj.transform;
				Transform parentTransform = aParent.transform;

				childTransform.parent = parentTransform;

				childTransform.localScale = new Vector3 (1, 1, 1);

				//childTransform.localPosition = new Vector3 (aPos.x * myTransform.localScale.x, aPos.y * myTransform.localScale.y, 0);
				childTransform.localPosition = new Vector3 (aPos.x, aPos.y, 0);


				return tempObj;


		}
	

		public static GameObject newGameObjectInObjectAndMakeRelative (GameObject aParent, Vector2 aPos)
		{
		
				
		

				GameObject tempObj = new GameObject ();
				Transform childTransform = tempObj.transform;
				Transform parentTransform = aParent.transform;
		
				childTransform.parent = parentTransform;
		
				childTransform.localScale = new Vector3 (1, 1, 1);
				
				
				childTransform.localPosition = new Vector3 (aPos.x, aPos.y, 0);
		
		
				return tempObj;
		
		
		}

		public static Vector3 returnScaleForNewPercentAdjusted (Vector3 currentScale, float newPercent)
		{
				return new Vector3 (currentScale.x * newPercent, currentScale.y * newPercent, currentScale.z);
		}



		public static GameObject instantiatePrefabInObjectAndMakeRelative (GameObject aChild, GameObject aParent)
		{

				return RelativeStuff.instantiatePrefabInObjectAndMakeRelative (aChild, aParent, new Vector2 (0, 0));

		}
}
