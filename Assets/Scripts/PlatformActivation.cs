using UnityEngine;

public class PlatformActivation : MonoBehaviour
{
    // Allows the creation of platofrms that are only activated when the game is in 2d (based on perspective), Attach to platforms
    private CameraToggle cameraToggle;
    private Collider platformCollider;

 
    void Start()
    {
        cameraToggle = FindObjectOfType<CameraToggle>();
        
        
        platformCollider = GetComponent<Collider>();
    }

    
    void Update()
    {
        if (cameraToggle != null && platformCollider != null)
        {
            platformCollider.enabled = cameraToggle.IsOrthographic();
        }
    }
}