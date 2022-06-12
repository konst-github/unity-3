using UnityEngine;

namespace Asteroids
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D followedObject;

        private const float cameraFollowSpeed = 0.5f;
        private const float cameraVelocityModifier = 0.5f;
        private const float cameraShakeDecreaseFactor = 1.0f;
        private const float cameraShakeDuration = 0.5f;
        private float shakeDuration;

        public static Vector2 cameraSize = Vector2.zero;

        private Vector3 velocity = Vector3.zero;
        private const float smoothTime = 0.3f;

        private void Start()
        {
            Debug.Log($"CAMERA size ortho: {Camera.main.orthographicSize}");
            Debug.Log($"CAMERA aspect: {Camera.main.aspect}");
            Debug.Log($"CAMERA field: {Camera.main.fieldOfView}");
            Debug.Log($"CAMERA screen: {Screen.width} : {Screen.height}");

            cameraSize.x = Camera.main.orthographicSize * 2;
            cameraSize.y = cameraSize.x * Camera.main.aspect;

            Debug.Log($"CAMERA size world: {cameraSize}");
        }

        private void Update()
        {
            // https://docs.unity3d.com/ScriptReference/Vector3.SmoothDamp.html
            //transform.position = Vector3.Lerp(transform.position, followedObject.position, 0.1f);
            transform.position = Vector3.SmoothDamp(transform.position, followedObject.position, ref velocity, smoothTime);

            if (shakeDuration > 0)
            {
                Vector3 v = followedObject.position;
                followedObject.position = v + Random.insideUnitSphere / 10;
                shakeDuration -= Time.deltaTime * cameraShakeDecreaseFactor;
            }
        }

        // From https://gist.github.com/ftvs/5822103
        public void StartShake()
        {
            // check if shake is in progress to prevent multiple shakes
            if (shakeDuration <= 0)
            {
                shakeDuration = cameraShakeDuration;
            }
        }
    }
}