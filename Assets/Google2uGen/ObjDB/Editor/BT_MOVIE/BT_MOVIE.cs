using UnityEngine;
using UnityEditor;

namespace Google2u
{
	[CustomEditor(typeof(BT_MOVIE))]
	public class BT_MOVIEEditor : Editor
	{
		public int Index = 0;
		public int _NextIDList_Index = 0;
		public int _AnswerIDList_Index = 0;
		public override void OnInspectorGUI ()
		{
			BT_MOVIE s = target as BT_MOVIE;
			BT_MOVIERow r = s.Rows[ Index ];

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
			GUILayout.Label( "_Dialog", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._Dialog );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_MovieID", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.IntField( r._MovieID );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_SceneID", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.IntField( r._SceneID );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_SceneType", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._SceneType );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			if ( r._NextIDList.Count == 0 )
			{
			    GUILayout.Label( "_NextIDList", GUILayout.Width( 150.0f ) );
			    {
			    	EditorGUILayout.LabelField( "Empty Array" );
			    }
			}
			else
			{
			    GUILayout.Label( "_NextIDList", GUILayout.Width( 130.0f ) );
			    if ( _NextIDList_Index >= r._NextIDList.Count )
				    _NextIDList_Index = 0;
			    if ( GUILayout.Button("<", GUILayout.Width( 18.0f )) )
			    {
			    	_NextIDList_Index -= 1;
			    	if ( _NextIDList_Index < 0 )
			    		_NextIDList_Index = r._NextIDList.Count - 1;
			    }
			    EditorGUILayout.LabelField(_NextIDList_Index.ToString(), GUILayout.Width( 15.0f ));
			    if ( GUILayout.Button(">", GUILayout.Width( 18.0f )) )
			    {
			    	_NextIDList_Index += 1;
			    	if ( _NextIDList_Index >= r._NextIDList.Count )
		        		_NextIDList_Index = 0;
				}
				EditorGUILayout.IntField( r._NextIDList[_NextIDList_Index] );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			if ( r._AnswerIDList.Count == 0 )
			{
			    GUILayout.Label( "_AnswerIDList", GUILayout.Width( 150.0f ) );
			    {
			    	EditorGUILayout.LabelField( "Empty Array" );
			    }
			}
			else
			{
			    GUILayout.Label( "_AnswerIDList", GUILayout.Width( 130.0f ) );
			    if ( _AnswerIDList_Index >= r._AnswerIDList.Count )
				    _AnswerIDList_Index = 0;
			    if ( GUILayout.Button("<", GUILayout.Width( 18.0f )) )
			    {
			    	_AnswerIDList_Index -= 1;
			    	if ( _AnswerIDList_Index < 0 )
			    		_AnswerIDList_Index = r._AnswerIDList.Count - 1;
			    }
			    EditorGUILayout.LabelField(_AnswerIDList_Index.ToString(), GUILayout.Width( 15.0f ));
			    if ( GUILayout.Button(">", GUILayout.Width( 18.0f )) )
			    {
			    	_AnswerIDList_Index += 1;
			    	if ( _AnswerIDList_Index >= r._AnswerIDList.Count )
		        		_AnswerIDList_Index = 0;
				}
				EditorGUILayout.IntField( r._AnswerIDList[_AnswerIDList_Index] );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_FileName", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._FileName );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_MovieTime", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._MovieTime );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_YoutubeLink", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._YoutubeLink );
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
