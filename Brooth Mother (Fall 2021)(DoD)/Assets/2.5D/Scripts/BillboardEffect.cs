using UnityEngine;

public class BillboardEffect : MonoBehaviour
{
    [Header("References")]
    [SerializeField] protected Transform camTransform;

    [Header("Settings")]
    [SerializeField] protected bool ignore_X_Rotation;
    [SerializeField] protected bool ignore_Z_Rotation;

    private int ignoreX, ignoreZ;

    virtual protected void Awake()
    {
        ignoreX = ignore_X_Rotation ? 0 : 1;
        ignoreZ = ignore_Z_Rotation ? 0 : 1;
        if(camTransform == null)
        {
            if(Camera.main != null)
                camTransform = Camera.main.transform;
            else
                Debug.LogError("No viable camera in scene!!!"); //We tried our best to find the camera, but couldn't :(                
        }
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        FaceCamera();
    }

    private void FaceCamera()
    {
        transform.LookAt(transform.position + camTransform.rotation * Vector3.forward,
            camTransform.rotation * Vector3.up);
        Vector3 newEuler = new Vector3(transform.rotation.eulerAngles.x * ignoreX, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z * ignoreZ);
        transform.rotation = Quaternion.Euler(newEuler);
    }
}
