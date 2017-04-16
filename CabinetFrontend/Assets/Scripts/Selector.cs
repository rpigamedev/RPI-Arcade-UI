using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Selector : MonoBehaviour {
	public List<RectTransform> gameTitleList;
	public RectTransform selectorBox;
	public Scrollbar scrollBar;
	public Transform content;
	public SelectedGamePanel selectedGamePanel;
	int titleIndex;
	float buttonOffsets; //distance from button to button
	float scrollPosToLerp; //0-1 position value scrolling list should be lerping to
	bool scrollDebounce = false;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < content.childCount; i++) {
			gameTitleList.Add(content.GetChild (i).gameObject.GetComponent<RectTransform>());
		}
		buttonOffsets = 1f / (content.childCount-1);
		scrollPosToLerp = 1;
		selectedGamePanel.UpdateDisplayData (content.GetChild (titleIndex).FindChild ("Metadata").gameObject.GetComponent<GameMetadata>());
	}
	
	// Update is called once per frame
	void Update () {
		selectorBox.position = Vector2.Lerp (selectorBox.position,gameTitleList[titleIndex].position,8*Time.deltaTime);
		scrollBar.value = Mathf.Lerp (scrollBar.value,scrollPosToLerp,8*Time.deltaTime);
		if (Input.GetAxis ("Vertical") == 0)
			scrollDebounce = false;
		if (scrollDebounce == false) {
			if (Input.GetAxis ("Vertical") > 0 && titleIndex - 1 >= 0) {
				scrollPosToLerp += buttonOffsets;
				titleIndex--;
				selectedGamePanel.UpdateDisplayData (content.GetChild (titleIndex).FindChild ("Metadata").gameObject.GetComponent<GameMetadata> ());
				scrollDebounce = true;
			} else if (Input.GetAxis ("Vertical") < 0 && titleIndex + 1 < content.childCount) {
				scrollPosToLerp -= buttonOffsets;
				titleIndex++;
				selectedGamePanel.UpdateDisplayData (content.GetChild (titleIndex).FindChild ("Metadata").gameObject.GetComponent<GameMetadata> ());
				scrollDebounce = true;
			}
		}
		if (Input.GetButtonDown ("Select")) {
			selectedGamePanel.LaunchCurrentGame ();
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
	}
}
