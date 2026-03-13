using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
public class VRRotateInteractable : MonoBehaviour
{
    private XRGrabInteractable interactable;
    private Transform interactorTransform;
    private Quaternion initialRotationOffset;

    void Awake()
    {
        interactable = GetComponent<XRGrabInteractable>();
        // Subscribe to select events
        interactable.selectEntered.AddListener(OnGrab);
        interactable.selectExited.AddListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        // Get the hand/controller that grabbed the object
        interactorTransform = args.interactorObject.transform;
        
        // Calculate initial offset so the object doesn't "snap" 
        initialRotationOffset = Quaternion.Inverse(interactorTransform.rotation) * transform.rotation;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        interactorTransform = null;
    }

    void Update()
    {
        if (interactorTransform != null)
        {
            // Update object rotation to match controller rotation + offset
            transform.rotation = interactorTransform.rotation * initialRotationOffset;
        }
    }
}
