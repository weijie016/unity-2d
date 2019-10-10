﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
	[SerializeField] float backgroundScrollSpeed = 0.20f;
	Material myMaterial;
	Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
		myMaterial = GetComponent<MeshRenderer>().material;
		offset = new Vector2(0f, backgroundScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
		myMaterial.mainTextureOffset += offset * Time.deltaTime;
    }
}
