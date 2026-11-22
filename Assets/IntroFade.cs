using UnityEngine;
using UnityEngine.UI;

public class IntroFade : MonoBehaviour
{
    [SerializeField] private float delay = 0.5f;
    [SerializeField] private float duration = 3f;

    private Image overlay;
    private float elapsed;

    private void Awake()
    {
        overlay = GetComponent<Image>();
        overlay.color = Color.black;
        overlay.raycastTarget = false;
    }

    private void Update()
    {
        elapsed += Time.unscaledDeltaTime;

        float progress = Mathf.Clamp01((elapsed - delay) / Mathf.Max(duration, 0.01f));
        float alpha = Mathf.SmoothStep(1f, 0f, progress);
        overlay.color = new Color(0f, 0f, 0f, alpha);

        if (progress >= 1f)
            enabled = false;
    }
}