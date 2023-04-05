using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DepthIndicator : MonoBehaviour
{
    [SerializeField] private TMP_Text depthTMP;

    private RectTransform depthTransf;

    private float upSpeed;
    //private float depth;
    void Start()
    {
        upSpeed = FindFirstObjectByType<StepsSpawner>().upSpeed;

        depthTransf = GetComponent<RectTransform>();
        depthTransf.localPosition = new Vector3(0, -1000, 0);
        if (gameObject.name == "DepthIndicator(Clone)")
        {
            depthTMP.text = "--- " + (upSpeed * 100).ToString("F1");
        } else
        {
            depthTMP.text = "-";
        }
        
    }

    private void Update()
    {
        UpdatePointPos();
        if (depthTransf.localPosition.y > 1400) Destroy(gameObject);
    }

    private void UpdatePointPos()
    {
        depthTransf.localPosition += new Vector3(0, upSpeed * 100, 0) * Time.deltaTime;
    }
}
