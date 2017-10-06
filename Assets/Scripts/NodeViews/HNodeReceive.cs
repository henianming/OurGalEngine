using UnityEngine;
using System.Collections.Generic;

class HNodeReceive : HNode {
	List<HNode> m_targetNodeList;

	#region Life

	private void OnEnable() {
		m_targetNodeList = new List<HNode>();
	}

	private void OnDisable() {
		m_targetNodeList = null;
	}

	#endregion

	override public void ClearLink(HNode other) {
		bool result = m_targetNodeList.Remove(other);

		if (result == false) {
			G.Error("other is not link");
		}
	}

	override protected void LineToOther(HNode other) {
		GameObject selfRoot = GetNodeRoot();
		GameObject otherRoot = other.GetNodeRoot();
		if (selfRoot == otherRoot) {
			return;
		}

		HNodeFire otherNodeTemp = other as HNodeFire;
		if (otherNodeTemp == null) {
			return;
		}

		bool result = false;
		foreach (HNode n in m_targetNodeList) {
			if (other == n) {
				result = true;
				break;
			}
		}

		if (result == false) {
			m_targetNodeList.Add(other);
		}
	}
}