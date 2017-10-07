using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CreateGrid))]
public class CreateGridEditor : Editor {

	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI ();
		CreateGrid at = (CreateGrid)target;

		if (GUILayout.Button("Generate Level")) {
			at.BuildGrid ();
		}

	}
}
