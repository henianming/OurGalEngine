using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using ElementList = System.Collections.Generic.List<ElementSaveStruct>;
using LineList = System.Collections.Generic.List<System.Collections.Generic.List<ElementSaveStruct>>;

class ElementSaveStruct {

}

public class HSave : MonoBehaviour {
	private Button m_button;
	private GameObject m_elementContainer;

	#region Life

	private void OnEnable() {
		m_elementContainer = GameObject.Find("UI/NodeView");

		m_button = gameObject.GetComponent<Button>();
		m_button.onClick.AddListener(OnButtonClicked);
	}

	private void OnDisable() {
		m_button = null;

		m_elementContainer = null;
	}

	#endregion

	private void OnButtonClicked() {
		int childCount = m_elementContainer.transform.childCount;
		for (int i = 0; i < childCount; i++) {
			GameObject gObj = m_elementContainer.transform.GetChild(i).gameObject;
			

		}
	}
}
