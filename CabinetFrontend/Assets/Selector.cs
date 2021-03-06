﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Selector : MonoBehaviour {
	public List<RectTransform> gameTitleList;
	public RectTransform selectorBox;
	public Scrollbar scrollBar;
	public Transform content;
	int titleIndex;
	float buttonOffsets; //distance from button to button
	float scrollPosToLerp; //0-1 position value scrolling list should be lerping to
	// Use this for initialization
	void Start () {
		for (int i = 0; i < content.childCount; i++) {
			gameTitleList.Add(content.GetChild (i).gameObject.GetComponent<RectTransform>());
		}
		buttonOffsets = 1f / (content.childCount-1);
		scrollPosToLerp = 1;
	}
	
	// Update is called once per frame
	void Update () {
		selectorBox.position = Vector2.Lerp (selectorBox.position,gameTitleList[titleIndex].position,6*Time.deltaTime);
		scrollBar.value = Mathf.Lerp (scrollBar.value,scrollPosToLerp,6*Time.deltaTime);
		if (Input.anyKeyDown) {
			if (Input.GetAxis ("Vertical") > 0 && titleIndex - 1 >= 0) {
				scrollPosToLerp += buttonOffsets;
				titleIndex--;
			}
			if (Input.GetAxis ("Vertical") < 0 && titleIndex + 1 < content.childCount) {
				scrollPosToLerp -= buttonOffsets;
				titleIndex++;
			}
		}
	}
}
