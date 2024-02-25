using UnityEngine;

public class CameraToggle : MonoBehaviour
{
    public Camera orthographicCamera;
    public Camera perspectiveCamera;

    void Start()
    {
        orthographicCamera.enabled = false;
        perspectiveCamera.enabled = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleCamera();
        }
    }

    void ToggleCamera()
    {
        orthographicCamera.enabled = !orthographicCamera.enabled;
        perspectiveCamera.enabled = !perspectiveCamera.enabled;
    }

    public bool IsOrthographic()
    {
        return orthographicCamera.enabled;
    }
}