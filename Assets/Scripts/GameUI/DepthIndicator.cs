using UnityEngine;
using TMPro;

public class DepthIndicator : MonoBehaviour
{
    [SerializeField] private TMP_Text depthTMP;
    private float upSpeed;
    private float parentHeight;

    void Start()
    {
        upSpeed = StepsSpawner.stepUpSpeed * 100;

        parentHeight = transform.parent.GetComponent<RectTransform>().rect.height;
        transform.localPosition = new Vector3(0, -(parentHeight/2) ,0);
        // depthTMP.text = "--- " + ((int)upSpeed).ToString();
    }

    private void FixedUpdate()
    {
        UpdatePointPos();
        if (transform.localPosition.y > 1400) Destroy(gameObject);
    }

    private void UpdatePointPos()
    {
        transform.localPosition += new Vector3(0, upSpeed, 0) * Time.fixedDeltaTime;
    }
}
