using UnityEngine;

public partial class G {
	public static GameObject HNV_lineParent;
}

public class HContentCtrl : MonoBehaviour {
	private static float sm_scaleSpeed = 0.05f;
	private static float sm_scaleMin = 0.001f;

	private Transform m_contentTs;
	private RectTransform m_contentRTs;
	private bool m_isMouseEnter;
	private BoxCollider2D m_bc2d;
	private RectTransform m_rts;
	private float m_curScaleArg;

	private Camera m_camera;
	private bool m_isMiddleDrag;
	private Vector3 m_midDragMousePos = new Vector3();
	private Vector3 m_midDragNodePos = new Vector3();

	#region Life

	private void Start() {
		if (G.HNV_lineParent == null) {
			G.HNV_lineParent = GameObject.Find("UI/NodeView/Content");
		}
	}

	private void OnEnable() {
		m_isMouseEnter = false;
		m_isMiddleDrag = false;

		m_curScaleArg = 1.0f;
		m_contentTs = transform.Find("Content");
		m_contentRTs = m_contentTs.gameObject.GetComponent<RectTransform>();
		m_bc2d = gameObject.GetComponent<BoxCollider2D>();
		m_rts = gameObject.GetComponent<RectTransform>();
		m_camera = Camera.main;
	}

	private void OnDisable() {
		m_camera = null;
		m_rts = null;
		m_bc2d = null;
		m_contentRTs = null;
		m_contentTs = null;
	}

	private void Update() {
		Rect r = m_rts.rect;
		float w = r.xMax - r.xMin;
		float h = r.yMax - r.yMin;
		m_bc2d.size = new Vector2(w, h);

		if (m_isMouseEnter == true) {
			if (Input.mouseScrollDelta.y != 0.0f) {
				float scaleChangeValue = Input.mouseScrollDelta.y * sm_scaleSpeed;
				float oldS = Mathf.Pow(m_curScaleArg, 2);
				m_curScaleArg += scaleChangeValue;
				if (m_curScaleArg < sm_scaleMin) {
					m_curScaleArg = sm_scaleMin;
				}
				float newS = Mathf.Pow(m_curScaleArg, 2);

				Vector3 scale = m_contentTs.localScale;
				scale.x = newS;
				scale.y = newS;
				m_contentTs.localScale = scale;

				Vector2 oldP = m_contentRTs.anchoredPosition;
				float posS = newS / oldS;
				Vector2 newP = new Vector2(oldP.x * posS, oldP.y * posS);
				m_contentRTs.anchoredPosition = newP;
			}

			if (Input.GetMouseButtonDown(MB.MIDDLE) == true) {
				m_isMiddleDrag = true;
				m_midDragMousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
				m_midDragNodePos = m_contentTs.position;
			}
		}

		if (Input.GetMouseButtonUp(MB.MIDDLE) == true) {
			m_isMiddleDrag = false;
		}

		if (m_isMiddleDrag == true) {
			Vector3 mouseWP = m_camera.ScreenToWorldPoint(Input.mousePosition);
			Vector3 moveV = mouseWP - m_midDragMousePos;
			m_contentTs.position = m_midDragNodePos + moveV;
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
