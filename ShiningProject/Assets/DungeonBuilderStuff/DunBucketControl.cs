using UnityEngine;
using System.Collections;

public class DunBucketControl : MonoBehaviour
{

		public enum DungeonName
		{
				NoDungeon,
				BigBadDungeon
		}


		public GameObject[] myDungeonPrefabs;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public GameObject returnDungeonPrefabFor (DungeonName theName)
		{
				switch (theName) {
				case DungeonName.BigBadDungeon:
						return myDungeonPrefabs [0];
						break;
				default:
						return myDungeonPrefabs [0];
						break;
				}

		}
}
