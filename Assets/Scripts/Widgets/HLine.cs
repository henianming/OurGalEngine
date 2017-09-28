using UnityEngine;

public class HLine : MonoBehaviour {
	private RectTransform m_rts;

	#region Life

	private void OnEnable() {
		m_rts = gameObject.GetComponent<RectTransform>();
	}

	private void OnDisable() {
		m_rts = null;
	}

	#endregion

	public void SetPosition(int pointIndex, Vector3 pos) {
		if (pointIndex == 1) {
			transform.position = pos;
		} else if (pointIndex == 2) {
			m_rts.sizeDelta = new Vector2(Vector3.Distance(transform.position, pos), m_rts.sizeDelta.y);
			transform.rotation = Quaternion.FromToRotation(Vector3.right, pos - transform.position);
		} else {
			G.Error("error arg pointIndex == " + pointIndex);
		}
	}
}