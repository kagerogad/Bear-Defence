using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(AttributeBar))]
public class AttributeBarEditor : Editor {

	public override void OnInspectorGUI ()
	{

		AttributeBar at = (AttributeBar)target;

		EditorGUI.BeginChangeCheck ();
		float xScale = EditorGUILayout.Slider ("X Scale", at.xScale, 0.001f, 0.05f);
		float yScale = EditorGUILayout.Slider ("Y Scale", at.yScale, 0.001f, 0.01f);

		if (EditorGUI.EndChangeCheck()) {
			Undo.RecordObject (target, "Changed Transform Properties");

			at.xScale = xScale;
			at.yScale = yScale;
		}

		at.transform.localScale = new Vector3 (at.xScale, at.yScale, 1f);
	}



}
