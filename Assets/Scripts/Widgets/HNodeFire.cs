using UnityEngine;

class HNodeFire : HNode {
	HNode m_targetNode;
	HLine m_line;

	#region Life

	private void OnEnable() {

	}

	private void OnDisable() {
		if (m_targetNode != null) {
			m_targetNode = null;
			Destroy(m_line);
			m_line = null;
		}
	}

	#endregion

	override protected void LineToOther(HNode other) {
		GameObject selfRoot = GetNodeRoot();
		GameObject otherRoot = other.GetNodeRoot();
		if (selfRoot == otherRoot) {
			return;
		}

		HNodeReceive otherNodeTemp = other as HNodeReceive;
		if (otherNodeTemp == null) {
			return;
		}

		m_targetNode = other;
		if (m_line != null) {
			Destroy(m_line.gameObject);
			m_line = null;
		}
		m_line = DrawLineToOther(other);
	}
}