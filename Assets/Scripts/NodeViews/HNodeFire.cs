using UnityEngine;

class HNodeFire : HNode {
	HNode m_targetNode;
	HLineLinked m_line;

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

	override public void ClearLink(HNode other) {
		if (m_targetNode != other) {
			G.Error("target != other");
			return;
		}

		m_targetNode = null;
		if (m_line != null) {
			m_line = null;
		}
	}

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