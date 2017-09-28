using UnityEngine;

public partial class G {
	#region 属性

	private static int sm_debugCurIndexValue = 0;
	private static int sm_debugCurIndex {
		get {
			return sm_debugCurIndexValue++;
		}
		set {
			sm_debugCurIndexValue = value;
		}
	}

	#endregion

	#region 接口

	private static string sm_logColorStr = "#FFFFFF";
	public static void Log(string context, Object obj = null) {
		string str = GetFmtedStr(context, sm_logColorStr);

		if (obj == null) {
			Debug.Log(str);
		} else {
			Debug.Log(str, obj);
		}
	}

	private static string sm_warningColorStr = "#FFFF00";
	public static void Warning(string context, Object obj = null) {
		string str = GetFmtedStr(context, sm_warningColorStr);

		if (obj == null) {
			Debug.LogWarning(str);
		} else {
			Debug.LogWarning(str, obj);
		}
	}

	private static string sm_errorColorStr = "#FF0000";
	public static void Error(string context, Object obj = null) {
		string str = GetFmtedStr(context, sm_errorColorStr);

		if (obj == null) {
			Debug.LogError(str);
		} else {
			Debug.LogError(str, obj);
		}
	}

	#endregion

	#region 内部函数

	private static string sm_fmtStr = "<color={0:G}>{1,8}  {2:C}</color>\n{3:C}\n<color={4:G}>-----------------------------</color>";
	private static string GetFmtedStr(string context, string color) {
		return string.Format(sm_fmtStr,
			color,
			"", //sm_debugCurIndex,
			"", //System.DateTime.Now.ToString("yyyy/MM/dd  hh:mm:ss"),
			context,
			color
		);
	}

	#endregion
}