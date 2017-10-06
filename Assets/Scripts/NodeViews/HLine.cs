using UnityEngine;

public class HLine : MonoBehaviour {
	protected RectTransform m_rts;

	#region Life

	virtual protected void OnEnable() {
		m_rts = gameObject.GetComponent<RectTransform>();
	}

	virtual protected void OnDisable() {
		m_rts = null;
	}

	#endregion

	virtual public void SetPosition(int pointIndex, Vector3 pos) {
		if (pointIndex == 1) {
			transform.position = pos;
		} else if (pointIndex == 2) {
			float s = G.HNV_lineParent.transform.localScale.x;
			m_rts.sizeDelta = new Vector2(Vector3.Distance(transform.position, pos) / s, m_rts.sizeDelta.y);
			transform.rotation = Quaternion.FromToRotation(Vector3.right, pos - transform.position);
		} else {
			G.Error("error arg pointIndex == " + pointIndex);
		}
	}
}