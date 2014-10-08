using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(DungeonMakerController))]
public class DungeonMakerEditor : Editor
{
		public override void OnInspectorGUI ()
		{
				DrawDefaultInspector ();
		
				DungeonMakerController myScript = (DungeonMakerController)target;
				if (GUILayout.Button ("ALL ROOMS TO DEFAULT")) {
						myScript.ALL_ROOMS_TO_DEFAULT ();
				}
				if (GUILayout.Button ("Load Import Slot")) {
						myScript.loadImportSlotIntoEditSlot ();
				}
				if (GUILayout.Button ("Export to Prefab")) {
						myScript.exportEditSlotToPrefab ();
				}
				if (GUILayout.Button ("New Actual")) {
						myScript.newObjectInEditSlot ();
				}
				
				
		}
}
