﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    public Transform target;

    public Transform showDistanceTo;

    public Text distanceLabel;

    public int margin = 50;

    public Color color
    {
        set
        {
            GetComponent<Image>().color = value;
        }

        get
        {
            return GetComponent<Image>().color;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        distanceLabel.enabled = false;

        GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        if (showDistanceTo != null)
        {
            distanceLabel.enabled = true;

            var distance = Vector3.Magnitude(showDistanceTo.position - target.position);

            distanceLabel.text = $"{distance:F0}m";
        }
        else
        {
            distanceLabel.enabled = false;
        }

        GetComponent<Image>().enabled = true;

        var viewportPoint = Camera.main.WorldToViewportPoint(target.position);

        if (viewportPoint.z < 0)
        {
            viewportPoint.z = 0;
            viewportPoint = viewportPoint.normalized;
            viewportPoint.x *= -Mathf.Infinity;
        }

        var screenPoint = Camera.main.ViewportToScreenPoint(viewportPoint);

        screenPoint.x = Mathf.Clamp(screenPoint.x, margin, Screen.width - margin * 2);
  
        screenPoint.y = Mathf.Clamp(screenPoint.y, margin, Screen.height - margin * 2);

        var localPosition = new Vector2();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            transform.parent.GetComponent<RectTransform>(),
            screenPoint,
            Camera.main,
            out localPosition
        );

        var rectTransform = GetComponent<RectTransform>();
        rectTransform.localPosition = localPosition;
    }
}
