using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorManager : Singleton<IndicatorManager>
{
    public RectTransform labelContainer;

    public Indicator indicatorPrefab;

    public Indicator AddIndicator(GameObject target, Color color, Sprite sprite = null)
    {
        var newIndicator = Instantiate(indicatorPrefab);

        newIndicator.target = target.transform;

        newIndicator.color = color;

        if (sprite != null)
        {
            newIndicator.GetComponent<Image>().sprite = sprite;
        }

        newIndicator.transform.SetParent(labelContainer, false);

        return newIndicator;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
