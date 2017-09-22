using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelCreator))]
public class LevelCreatorEditor : Editor {

	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI ();
		LevelCreator at = (LevelCreator)target;

		if (GUILayout.Button("Generate Level")) {
			at.GenerateLevel ();
		}
			
	}
}
