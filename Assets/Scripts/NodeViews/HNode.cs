using UnityEngine;

public partial class G {
	public static HLine HNV_line;
	public static GameObject HNV_hoverGameObject;
}

public class HNode : MonoBehaviour {
	#region Event

	private void OnMouseDown() {
		if (G.HNV_line == null) {
			GameObject gObj = Resources.Load("Prefabs/Line") as GameObject;
			gObj = Instantiate(gObj, G.HNV_lineParent.transform);
			G.HNV_line = gObj.GetComponent<HLine>();
			G.HNV_line.SetPosition(1, transform.position);
		} else {
			G.Warning("sm_line is not null");
		}
	}

	private void OnMouseDrag() {
		Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mouseWorldPos.z = transform.position.z;
		G.HNV_line.SetPosition(2, mouseWorldPos);
	}

	private void OnMouseUp() {
		if (G.HNV_line != null) {
			Destroy(G.HNV_line.gameObject);
			G.HNV_line = null;
		}

		if (G.HNV_hoverGameObject != null) {
			LineToOther(G.HNV_hoverGameObject.GetComponent<HNode>());
			G.HNV_hoverGameObject.GetComponent<HNode>().LineToOther(this);
		}
	}

	private void OnMouseEnter() {
		G.HNV_hoverGameObject = gameObject;
	}

	private void OnMouseExit() {
		G.HNV_hoverGameObject = null;
	}

	#endregion

	virtual public GameObject GetNodeRoot() {
		return transform.parent.gameObject;
	}

	virtual public void ClearLink(HNode other) {
		G.Warning("no implement");
	}

	virtual protected void LineToOther(HNode other) {
		G.Log(gameObject.name + " line to " + other.name);
	}

	virtual protected HLineLinked DrawLineToOther(HNode other) {
		GameObject gObj = Resources.Load("Prefabs/LineLinked") as GameObject;
		gObj = Instantiate(gObj, G.HNV_lineParent.transform);
		HLineLinked line = gObj.GetComponent<HLineLinked>();
		line.SetPosition(1, transform.position);
		line.SetPosition(2, other.transform.position);
		line.SetLinkedTarget(this, other);
		return line;
	}
}