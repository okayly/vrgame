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
	public class BT_ANSWERRow : IGoogle2uRow
	{
		public int _AnswerID;
		public string _Answer;
		public string _Comment;
		public BT_ANSWERRow(string __G2U_ID, string __AnswerID, string __Answer, string __Comment) 
		{
			{
			int res;
				if(int.TryParse(__AnswerID, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_AnswerID = res;
				else
					Debug.LogError("Failed To Convert _AnswerID string: "+ __AnswerID +" to int");
			}
			_Answer = __Answer.Trim();
			_Comment = __Comment.Trim();
		}

		public int Length { get { return 3; } }

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
					ret = _AnswerID.ToString();
					break;
				case 1:
					ret = _Answer.ToString();
					break;
				case 2:
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
				case "_AnswerID":
					ret = _AnswerID.ToString();
					break;
				case "_Answer":
					ret = _Answer.ToString();
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
			ret += "{" + "_AnswerID" + " : " + _AnswerID.ToString() + "} ";
			ret += "{" + "_Answer" + " : " + _Answer.ToString() + "} ";
			ret += "{" + "_Comment" + " : " + _Comment.ToString() + "} ";
			return ret;
		}
	}
	public class BT_ANSWER :  Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds {
			answer_1, answer_2, answer_3, answer_4, answer_5, answer_6, answer_7, answer_8, answer_9, answer_10, answer_11, answer_12, answer_13, answer_14, answer_15, answer_16
		};
		public string [] rowNames = {
			"answer_1", "answer_2", "answer_3", "answer_4", "answer_5", "answer_6", "answer_7", "answer_8", "answer_9", "answer_10", "answer_11", "answer_12", "answer_13", "answer_14", "answer_15", "answer_16"
		};
		public System.Collections.Generic.List<BT_ANSWERRow> Rows = new System.Collections.Generic.List<BT_ANSWERRow>();
		public override void AddRowGeneric (System.Collections.Generic.List<string> input)
		{
			Rows.Add(new BT_ANSWERRow(input[0],input[1],input[2],input[3]));
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
		public BT_ANSWERRow GetRow(rowIds in_RowID)
		{
			BT_ANSWERRow ret = null;
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
		public BT_ANSWERRow GetRow(string in_RowString)
		{
			BT_ANSWERRow ret = null;
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
