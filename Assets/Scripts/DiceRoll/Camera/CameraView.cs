using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceRoll
{
    public class CameraView : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private float depth;
        [SerializeField] private SpriteRenderer spriteRenderer;
        // Start is called before the first frame update
        void Awake()
        {
            //FitToScreen();
            ResizeCameraFOV();
        }

        private void FitToScreen()
        {
            // Angle the camera can see above the center.
            float halfFovRadians = mainCamera.fieldOfView * Mathf.Deg2Rad / 2f;

            // How high is it from top to bottom of the view frustum,
            // in world space units, at our target depth?
            float visibleHeightAtDepth = depth * Mathf.Tan(halfFovRadians) * 2f;

            // You could also use Sprite.bounds for this.
            float spriteHeight = spriteRenderer.sprite.rect.height
                               / spriteRenderer.sprite.pixelsPerUnit;

            // How many times bigger (or smaller) is the height we want to fill?
            float scaleFactor = visibleHeightAtDepth / spriteHeight;

            // Scale to fit, uniformly on all axes.
            spriteRenderer.transform.localScale = Vector3.one * scaleFactor;

        }

        private void ResizeCameraFOV()
        {

            mainCamera.orthographicSize = GetHeightProportion() * 2 / 56.25f;
        }
        float GetHeightProportion()
        {
            return ((float)Screen.height * 100) / (float)Screen.width;
        }
    }
}
