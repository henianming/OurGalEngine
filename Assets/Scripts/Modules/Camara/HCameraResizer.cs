using UnityEngine;

public class HCameraResizer : MonoBehaviour {
	private Camera m_camera;
	private float m_oldSize;

	#region Life

	private void OnEnable() {
		m_oldSize = 0;

		m_camera = gameObject.GetComponent<Camera>();
	}

	private void OnDisable() {
		m_camera = null;
	}

	#endregion

	private void Update() {
		float newSize = Screen.height / 2;
		if (m_oldSize != newSize) {
			m_camera.orthographicSize = newSize;
			m_oldSize = newSize;
		}
	}
}
