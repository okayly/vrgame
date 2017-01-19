using UnityEngine;
using UnityEditor;

namespace Google2u
{
	[CustomEditor(typeof(Answer))]
	public class AnswerEditor : Editor
	{
		public int Index = 0;
		public override void OnInspectorGUI ()
		{
			Answer s = target as Answer;
			AnswerRow r = s.Rows[ Index ];

			EditorGUILayout.BeginHorizontal();
			if ( GUILayout.Button("<<") )
			{
				Index = 0;
			}
			if ( GUILayout.Button("<") )
			{
				Index -= 1;
				if ( Index < 0 )
					Index = s.Rows.Count - 1;
			}
			if ( GUILayout.Button(">") )
			{
				Index += 1;
				if ( Index >= s.Rows.Count )
					Index = 0;
			}
			if ( GUILayout.Button(">>") )
			{
				Index = s.Rows.Count - 1;
			}

			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "ID", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.LabelField( s.rowNames[ Index ] );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_Answer", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._Answer );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_Comment", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._Comment );
			}
			EditorGUILayout.EndHorizontal();

		}
	}
}
