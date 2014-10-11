using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(DunMakerControl))]
public class DunMakerCustomEdit : Editor
{
		public override void OnInspectorGUI ()
		{
				DrawDefaultInspector ();
		
				DunMakerControl myScript = (DunMakerControl)target;
				
				if (GUILayout.Button ("Load Import Slot")) {
						myScript.loadImportSlotIntoEditSlot ();
				}
				if (GUILayout.Button ("Export to Prefab")) {
						myScript.exportEditSlotToPrefab ();
				}
				if (GUILayout.Button ("New Dungeon")) {
						myScript.newObjectInEditSlot ();
				}
				
				
		}
}
