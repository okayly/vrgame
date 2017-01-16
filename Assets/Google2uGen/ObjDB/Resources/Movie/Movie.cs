//----------------------------------------------
//    Google2u: Google Doc Unity integration
//         Copyright © 2015 Litteratus
//
//        This file has been auto-generated
//              Do not manually edit
//----------------------------------------------

using UnityEngine;
using System.Globalization;

namespace Google2u
{
	[System.Serializable]
	public class MovieRow : IGoogle2uRow
	{
		public string _Dialog;
		public int _MovieID;
		public int _SceneID;
		public string _SceneType;
		public int _AnswerID;
		public System.Collections.Generic.List<int> _NextIDList = new System.Collections.Generic.List<int>();
		public string _FileName;
		public string _MovieTime;
		public string _YoutubeLink;
		public string _Comment;
		public MovieRow(string __G2U_ID, string __Dialog, string __MovieID, string __SceneID, string __SceneType, string __AnswerID, string __NextIDList, string __FileName, string __MovieTime, string __YoutubeLink, string __Comment) 
		{
			_Dialog = __Dialog.Trim();
			{
			int res;
				if(int.TryParse(__MovieID, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_MovieID = res;
				else
					Debug.LogError("Failed To Convert _MovieID string: "+ __MovieID +" to int");
			}
			{
			int res;
				if(int.TryParse(__SceneID, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_SceneID = res;
				else
					Debug.LogError("Failed To Convert _SceneID string: "+ __SceneID +" to int");
			}
			_SceneType = __SceneType.Trim();
			{
			int res;
				if(int.TryParse(__AnswerID, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_AnswerID = res;
				else
					Debug.LogError("Failed To Convert _AnswerID string: "+ __AnswerID +" to int");
			}
			{
				int res;
				string []result = __NextIDList.Split(",".ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries);
				for(int i = 0; i < result.Length; i++)
				{
					if(int.TryParse(result[i], NumberStyles.Any, CultureInfo.InvariantCulture, out res))
						_NextIDList.Add( res );
					else
					{
						_NextIDList.Add( 0 );
						Debug.LogError("Failed To Convert _NextIDList string: "+ result[i] +" to int");
					}
				}
			}
			_FileName = __FileName.Trim();
			_MovieTime = __MovieTime.Trim();
			_YoutubeLink = __YoutubeLink.Trim();
			_Comment = __Comment.Trim();
		}

		public int Length { get { return 10; } }

		public string this[int i]
		{
		    get
		    {
		        return GetStringDataByIndex(i);
		    }
		}

		public string GetStringDataByIndex( int index )
		{
			string ret = System.String.Empty;
			switch( index )
			{
				case 0:
					ret = _Dialog.ToString();
					break;
				case 1:
					ret = _MovieID.ToString();
					break;
				case 2:
					ret = _SceneID.ToString();
					break;
				case 3:
					ret = _SceneType.ToString();
					break;
				case 4:
					ret = _AnswerID.ToString();
					break;
				case 5:
					ret = _NextIDList.ToString();
					break;
				case 6:
					ret = _FileName.ToString();
					break;
				case 7:
					ret = _MovieTime.ToString();
					break;
				case 8:
					ret = _YoutubeLink.ToString();
					break;
				case 9:
					ret = _Comment.ToString();
					break;
			}

			return ret;
		}

		public string GetStringData( string colID )
		{
			var ret = System.String.Empty;
			switch( colID )
			{
				case "_Dialog":
					ret = _Dialog.ToString();
					break;
				case "_MovieID":
					ret = _MovieID.ToString();
					break;
				case "_SceneID":
					ret = _SceneID.ToString();
					break;
				case "_SceneType":
					ret = _SceneType.ToString();
					break;
				case "_AnswerID":
					ret = _AnswerID.ToString();
					break;
				case "_NextIDList":
					ret = _NextIDList.ToString();
					break;
				case "_FileName":
					ret = _FileName.ToString();
					break;
				case "_MovieTime":
					ret = _MovieTime.ToString();
					break;
				case "_YoutubeLink":
					ret = _YoutubeLink.ToString();
					break;
				case "_Comment":
					ret = _Comment.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "_Dialog" + " : " + _Dialog.ToString() + "} ";
			ret += "{" + "_MovieID" + " : " + _MovieID.ToString() + "} ";
			ret += "{" + "_SceneID" + " : " + _SceneID.ToString() + "} ";
			ret += "{" + "_SceneType" + " : " + _SceneType.ToString() + "} ";
			ret += "{" + "_AnswerID" + " : " + _AnswerID.ToString() + "} ";
			ret += "{" + "_NextIDList" + " : " + _NextIDList.ToString() + "} ";
			ret += "{" + "_FileName" + " : " + _FileName.ToString() + "} ";
			ret += "{" + "_MovieTime" + " : " + _MovieTime.ToString() + "} ";
			ret += "{" + "_YoutubeLink" + " : " + _YoutubeLink.ToString() + "} ";
			ret += "{" + "_Comment" + " : " + _Comment.ToString() + "} ";
			return ret;
		}
	}
	public class Movie :  Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds {
			vr_001, vr_002, vr_003, vr_004, vr_005, vr_006, vr_007, vr_008, vr_009, vr_010, vr_011, vr_012, vr_013, vr_014, vr_015, vr_016, vr_017, vr_018
			, vr_019, vr_020, vr_021, vr_022, vr_023, vr_024, vr_025, vr_026, vr_027, vr_028, vr_029, vr_030, vr_031, vr_032, vr_033, vr_034, vr_035, vr_036, vr_037, vr_038
			, vr_039, vr_040, vr_041
		};
		public string [] rowNames = {
			"vr_001", "vr_002", "vr_003", "vr_004", "vr_005", "vr_006", "vr_007", "vr_008", "vr_009", "vr_010", "vr_011", "vr_012", "vr_013", "vr_014", "vr_015", "vr_016", "vr_017", "vr_018"
			, "vr_019", "vr_020", "vr_021", "vr_022", "vr_023", "vr_024", "vr_025", "vr_026", "vr_027", "vr_028", "vr_029", "vr_030", "vr_031", "vr_032", "vr_033", "vr_034", "vr_035", "vr_036", "vr_037", "vr_038"
			, "vr_039", "vr_040", "vr_041"
		};
		public System.Collections.Generic.List<MovieRow> Rows = new System.Collections.Generic.List<MovieRow>();
		public override void AddRowGeneric (System.Collections.Generic.List<string> input)
		{
			Rows.Add(new MovieRow(input[0],input[1],input[2],input[3],input[4],input[5],input[6],input[7],input[8],input[9],input[10]));
		}
		public override void Clear ()
		{
			Rows.Clear();
		}
		public IGoogle2uRow GetGenRow(string in_RowString)
		{
			IGoogle2uRow ret = null;
			try
			{
				ret = Rows[(int)System.Enum.Parse(typeof(rowIds), in_RowString)];
			}
			catch(System.ArgumentException) {
				Debug.LogError( in_RowString + " is not a member of the rowIds enumeration.");
			}
			return ret;
		}
		public IGoogle2uRow GetGenRow(rowIds in_RowID)
		{
			IGoogle2uRow ret = null;
			try
			{
				ret = Rows[(int)in_RowID];
			}
			catch( System.Collections.Generic.KeyNotFoundException ex )
			{
				Debug.LogError( in_RowID + " not found: " + ex.Message );
			}
			return ret;
		}
		public MovieRow GetRow(rowIds in_RowID)
		{
			MovieRow ret = null;
			try
			{
				ret = Rows[(int)in_RowID];
			}
			catch( System.Collections.Generic.KeyNotFoundException ex )
			{
				Debug.LogError( in_RowID + " not found: " + ex.Message );
			}
			return ret;
		}
		public MovieRow GetRow(string in_RowString)
		{
			MovieRow ret = null;
			try
			{
				ret = Rows[(int)System.Enum.Parse(typeof(rowIds), in_RowString)];
			}
			catch(System.ArgumentException) {
				Debug.LogError( in_RowString + " is not a member of the rowIds enumeration.");
			}
			return ret;
		}

	}

}
