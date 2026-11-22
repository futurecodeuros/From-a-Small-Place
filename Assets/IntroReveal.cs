using TMPro;
using UnityEngine;

public class IntroReveal : MonoBehaviour
{
    [SerializeField] private Transform cityBuilding;
    [SerializeField] private BusRide busRide;
    [SerializeField] private TMP_Text gameTitle;
    [SerializeField] private TMP_Text gameTitle1;
    [SerializeField] private float triggerX = 4f;
    [SerializeField] private Transform blackOverlay;

    private Vector3 overlayFullScale;
 
    private Camera introCamera;
    private float startingSize;
    private float elapsed;
    private bool started;

    private void Start()
    {
        introCamera = GetComponent<Camera>();
        startingSize = introCamera.orthographicSize;
        gameTitle.alpha = 0f;
        gameTitle1.alpha = 0f;
        overlayFullScale = blackOverlay.localScale;
        SetBlackout(0f);
    }
    private void SetBlackout(float progress)
    {
        Vector3 scale = overlayFullScale;
        scale.x = overlayFullScale.x * progress;
        blackOverlay.localScale = scale;
    }

    private void LateUpdate()
    {
        if (!started)
        {
            if (cityBuilding.position.x > triggerX)
                return;

            started = true;
            busRide.StartBraking();
        }

        elapsed += Time.deltaTime;

        float zoomProgress = Mathf.Clamp01(elapsed / 2f);
        SetBlackout(Mathf.SmoothStep(0f, 1f, zoomProgress));
        introCamera.orthographicSize = Mathf.SmoothStep(
            startingSize, startingSize * 0.65f, zoomProgress
        );

        gameTitle.alpha = Mathf.Clamp01((elapsed - 3f) / 1.3f);
        gameTitle1.alpha = Mathf.Clamp01((elapsed - 5f) / 1f);
        if (elapsed >= 6f)
            enabled = false;
    }
}