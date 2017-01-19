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
		public string _SceneType;
		public System.Collections.Generic.List<string> _AnswerIDList = new System.Collections.Generic.List<string>();
		public System.Collections.Generic.List<string> _NextIDList = new System.Collections.Generic.List<string>();
		public string _FileName;
		public string _MovieTime;
		public string _YoutubeLink;
		public string _Comment;
		public MovieRow(string __ID, string __Dialog, string __MovieID, string __SceneType, string __AnswerIDList, string __NextIDList, string __FileName, string __MovieTime, string __YoutubeLink, string __Comment) 
		{
			_Dialog = __Dialog.Trim();
			{
			int res;
				if(int.TryParse(__MovieID, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_MovieID = res;
				else
					Debug.LogError("Failed To Convert _MovieID string: "+ __MovieID +" to int");
			}
			_SceneType = __SceneType.Trim();
			{
				string []result = __AnswerIDList.Split("|".ToCharArray(),System.StringSplitOptions.RemoveEmptyEntries);
				for(int i = 0; i < result.Length; i++)
				{
					_AnswerIDList.Add( result[i].Trim() );
				}
			}
			{
				string []result = __NextIDList.Split("|".ToCharArray(),System.StringSplitOptions.RemoveEmptyEntries);
				for(int i = 0; i < result.Length; i++)
				{
					_NextIDList.Add( result[i].Trim() );
				}
			}
			_FileName = __FileName.Trim();
			_MovieTime = __MovieTime.Trim();
			_YoutubeLink = __YoutubeLink.Trim();
			_Comment = __Comment.Trim();
		}

		public int Length { get { return 9; } }

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
					ret = _SceneType.ToString();
					break;
				case 3:
					ret = _AnswerIDList.ToString();
					break;
				case 4:
					ret = _NextIDList.ToString();
					break;
				case 5:
					ret = _FileName.ToString();
					break;
				case 6:
					ret = _MovieTime.ToString();
					break;
				case 7:
					ret = _YoutubeLink.ToString();
					break;
				case 8:
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
				case "_SceneType":
					ret = _SceneType.ToString();
					break;
				case "_AnswerIDList":
					ret = _AnswerIDList.ToString();
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
			ret += "{" + "_SceneType" + " : " + _SceneType.ToString() + "} ";
			ret += "{" + "_AnswerIDList" + " : " + _AnswerIDList.ToString() + "} ";
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
			vr_1, vr_2, vr_3, vr_4, vr_5, vr_6, vr_7, vr_8, vr_9, vr_10, vr_11, vr_12, vr_13, vr_14, vr_15, vr_16, vr_17, vr_18
			, vr_19, vr_20, vr_21, vr_22, vr_23, vr_24, vr_25, vr_26, vr_27, vr_28, vr_29, vr_30, vr_31, vr_32, vr_33, vr_34, vr_35, vr_36, vr_37, vr_38
			, vr_39, vr_40, vr_41
		};
		public string [] rowNames = {
			"vr_1", "vr_2", "vr_3", "vr_4", "vr_5", "vr_6", "vr_7", "vr_8", "vr_9", "vr_10", "vr_11", "vr_12", "vr_13", "vr_14", "vr_15", "vr_16", "vr_17", "vr_18"
			, "vr_19", "vr_20", "vr_21", "vr_22", "vr_23", "vr_24", "vr_25", "vr_26", "vr_27", "vr_28", "vr_29", "vr_30", "vr_31", "vr_32", "vr_33", "vr_34", "vr_35", "vr_36", "vr_37", "vr_38"
			, "vr_39", "vr_40", "vr_41"
		};
		public System.Collections.Generic.List<MovieRow> Rows = new System.Collections.Generic.List<MovieRow>();
		public override void AddRowGeneric (System.Collections.Generic.List<string> input)
		{
			Rows.Add(new MovieRow(input[0],input[1],input[2],input[3],input[4],input[5],input[6],input[7],input[8],input[9]));
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
