using UnityEngine;
using System.Collections;

public class MainMathControl : MonoBehaviour
{

		public static int returnRandomInt (int floorInclusive, int ceilingInclusive)
		{
				return Random.Range (floorInclusive, ceilingInclusive + 1);
		}

		public static int[] returnArrayOfInts (int floorInclusive, int ceilingInclusive, int totalToReturn)
		{
				int[] arrayOfInts = new int[totalToReturn];
				int remainingToAdd = totalToReturn;

				do {

						bool alreadyFoundThisInt = false;
						int numThisTime = MainMathControl.returnRandomInt (floorInclusive, ceilingInclusive);

						foreach (int numFound in arrayOfInts) {
								if (numFound == numThisTime) {
										alreadyFoundThisInt = true;
										break;
								}
						}

						if (alreadyFoundThisInt == false) {
								arrayOfInts [totalToReturn - remainingToAdd] = numThisTime;
								remainingToAdd--;
						}

				} while(remainingToAdd > 0);

				return arrayOfInts;


		}

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
