//	Copyright (c) KimPuppy.
//	http://bakak112.tistory.com/

using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Target = null;

    public float Speed = 7.5f;
    public float ZoomSpeed = 7.5f;

    public Vector3 Offset = Vector3.zero;
    public float DefaultZoom = 5.0f;

    private Camera cameraObject;

    private Vector3 anchorPoint = Vector3.zero;
    private float zoomSize = 1.0f;

    private float shakePower = 0.0f;
    private float shakeAmount = 7.5f;

    public Camera CameraObject { get => cameraObject; set => cameraObject = value; }

    private void Awake()
    {
        cameraObject = GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        if (Target != null)
        {
            anchorPoint = Vector3.Lerp(anchorPoint, Target.position, Speed * Time.deltaTime);
            cameraObject.orthographicSize = Mathf.Lerp(cameraObject.orthographicSize, DefaultZoom * zoomSize, ZoomSpeed * Time.deltaTime);
        }
        shakePower -= shakePower / shakeAmount;
        transform.position = anchorPoint + Offset + new Vector3(Random.Range(-shakePower, shakePower), Random.Range(-shakePower, shakePower), -0.0f);
    }

    public void Shake(float power, float amount = 7.5f)
    {
        shakePower = power;
        shakeAmount = amount;
    }

    public void SetTarget(GameObject target, float speed = 7.5f)
    {
        Target = target.transform;
        Speed = speed;
    }

    public void SetSize(float size, float speed = 7.5f)
    {
        zoomSize = size;
        ZoomSpeed = speed;
    }
}