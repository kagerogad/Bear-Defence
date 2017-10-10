﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelectController : MonoBehaviour {

	private Sprite regularSprite;
	public Sprite selectedSprite;

	private SpriteRenderer sr;

	void Start() {
		sr = GetComponent<SpriteRenderer> ();
		regularSprite = sr.sprite;
	}

	void OnMouseEnter() {
		sr.sprite = selectedSprite;
	}

	void OnMouseExit() {
		sr.sprite = regularSprite;
	}
		
}
