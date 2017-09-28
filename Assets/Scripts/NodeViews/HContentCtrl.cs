using UnityEngine;

public class HContentCtrl : MonoBehaviour {
	private static float sm_scaleSpeed = 0.05f;

	private Transform m_contentTs;
	private bool m_isMouseEnter;
	private BoxCollider2D m_bc2d;
	private RectTransform m_rts;
	private float m_curScaleArg;

	#region Life

	private void OnEnable() {
		m_isMouseEnter = false;

		m_curScaleArg = 1.0f;
		m_contentTs = transform.Find("Content");
		m_bc2d = gameObject.GetComponent<BoxCollider2D>();
		m_rts = gameObject.GetComponent<RectTransform>();
	}

	private void OnDisable() {
		m_rts = null;
		m_bc2d = null;
		m_contentTs = null;
	}

	private void Update() {
		Rect r = m_rts.rect;
		float w = r.xMax - r.xMin;
		float h = r.yMax - r.yMin;
		m_bc2d.size = new Vector2(w, h);

		if (m_isMouseEnter == true && Input.mouseScrollDelta.y != 0.0f) {
			float scaleChangeValue = Input.mouseScrollDelta.y * sm_scaleSpeed;
			m_curScaleArg += scaleChangeValue;
			if (m_curScaleArg < 0) {
				m_curScaleArg = 0.0f;
			}
			G.Log("" + scaleChangeValue + " " + m_curScaleArg);
			Vector3 scale = m_contentTs.localScale;
			scale.x = Mathf.Pow(m_curScaleArg, 2);
			scale.y = scale.x;
			m_contentTs.localScale = scale;
		}
	}

	#endregion

	#region Event

	private void OnMouseOver() {
		m_isMouseEnter = true;
	}

	private void OnMouseExit() {
		m_isMouseEnter = false;
	}
	
	#endregion
}
