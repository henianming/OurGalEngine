using UnityEngine;
using UnityEngine.UI;

public class HLineLinked : HLine {
	private BoxCollider2D m_bc2d;
	private bool m_isMouseOver;
	private HNode m_start;
	private HNode m_end;
	private Image m_frameImg;

	#region Life

	private void Start() {
		Image img = gameObject.GetComponent<Image>();
		img.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
	}

	override protected void OnEnable() {
		base.OnEnable();

		m_isMouseOver = false;

		m_bc2d = gameObject.GetComponent<BoxCollider2D>();
		m_frameImg = transform.Find("Frame").gameObject.GetComponent<Image>();
		m_frameImg.enabled = false;
	}

	override protected void OnDisable() {
		m_frameImg = null;
		m_bc2d = null;
		
		m_start = null;
		m_end = null;

		base.OnDisable();
	}

	private void Update() {
		if (m_isMouseOver == true && Input.GetMouseButtonUp(MB.LEFT) == true) {
			ClearLink();
		}
	}

	#endregion

	#region Event

	private void OnMouseEnter() {
		m_isMouseOver = true;
		m_frameImg.enabled = true;
	}

	private void OnMouseExit() {
		m_isMouseOver = false;
		m_frameImg.enabled = false;
	}

	#endregion

	override public void SetPosition(int pointIndex, Vector3 pos) {
		base.SetPosition(pointIndex, pos);

		RefreshCollider();
	}

	public void RefreshCollider() {
		Rect r = m_rts.rect;
		float w = r.xMax - r.xMin;
		float h = r.yMax - r.yMin;
		m_bc2d.size = new Vector2(w, h);
		m_bc2d.offset = new Vector2(w / 2, 0);
	}

	public void SetLinkedTarget(HNode start, HNode end) {
		m_start = start;
		m_end = end;
	}

	private void ClearLink() {
		if (m_start == null || m_end == null) {
			G.Warning("no target");
		}

		m_start.ClearLink(m_end);
		m_end.ClearLink(m_start);
		Destroy(gameObject);
	}
}
