using UnityEngine;

public partial class G {
	public static GameObject HNode_lineParent;
	public static HLine HNode_line;
	public static GameObject HNode_hoverGameObject;
}

public class HNode : MonoBehaviour {
	#region Life

	virtual protected void Start() {
		if (G.HNode_lineParent == null) {
			G.HNode_lineParent = GameObject.Find("UI/NodeView/Content");
		}
	}

	#endregion

	#region Event

	private void OnMouseDown() {
		if (G.HNode_line == null) {
			GameObject gObj = Resources.Load("Prefabs/Line") as GameObject;
			gObj = Instantiate(gObj, G.HNode_lineParent.transform);
			G.HNode_line = gObj.GetComponent<HLine>();
			G.HNode_line.SetPosition(1, transform.position);
		} else {
			G.Warning("sm_line is not null");
		}
	}

	private void OnMouseDrag() {
		Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mouseWorldPos.z = transform.position.z;
		G.HNode_line.SetPosition(2, mouseWorldPos);
	}

	private void OnMouseUp() {
		if (G.HNode_line != null) {
			Destroy(G.HNode_line.gameObject);
			G.HNode_line = null;
		}

		if (G.HNode_hoverGameObject != null) {
			this.LineToOther(G.HNode_hoverGameObject.GetComponent<HNode>());
			G.HNode_hoverGameObject.GetComponent<HNode>().LineToOther(this);
		}
	}

	private void OnMouseEnter() {
		G.HNode_hoverGameObject = gameObject;
	}

	private void OnMouseExit() {
		G.HNode_hoverGameObject = null;
	}

	#endregion

	virtual protected void LineToOther(HNode other) {
		G.Log(gameObject.name + " line to " + other.name);
	}

	virtual public GameObject GetNodeRoot() {
		return transform.parent.gameObject;
	}

	virtual protected HLine DrawLineToOther(HNode other) {
		GameObject gObj = Resources.Load("Prefabs/Line") as GameObject;
		gObj = Instantiate(gObj, G.HNode_lineParent.transform);
		HLine line = gObj.GetComponent<HLine>();
		line.SetPosition(1, transform.position);
		line.SetPosition(2, other.transform.position);
		return line;
	}
}