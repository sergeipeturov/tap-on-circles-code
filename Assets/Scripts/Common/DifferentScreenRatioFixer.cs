using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifferentScreenRatioFixer : MonoBehaviour
{
    private void Awake()
    {
		Resize();
    }

    private void Update()
    {
		Resize();
    }

    private void Resize()
	{
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		if (sr == null) return;
		//transform.localScale = new Vector3(1, 1, 1);

		//float width = sr.sprite.bounds.size.x;
		//float height = sr.sprite.bounds.size.y;

		float width = transform.localScale.x;
		float height = transform.localScale.y;

		float worldScreenHeight = Camera.main.orthographicSize * 2f;
		float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

		Vector3 xWidth = transform.localScale;
		xWidth.x = worldScreenWidth / width;
		transform.localScale = xWidth;
		Vector3 yHeight = transform.localScale;
		yHeight.y = worldScreenHeight / height;
		transform.localScale = yHeight;
	}
}
