using UnityEngine;
using UnityEditor;

namespace Google2u
{
	[CustomEditor(typeof(BT_ANSWER))]
	public class BT_ANSWEREditor : Editor
	{
		public int Index = 0;
		public override void OnInspectorGUI ()
		{
			BT_ANSWER s = target as BT_ANSWER;
			BT_ANSWERRow r = s.Rows[ Index ];

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
			GUILayout.Label( "_AnswerID", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.IntField( r._AnswerID );
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
