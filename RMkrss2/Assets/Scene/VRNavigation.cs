using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class VRNavigation : MonoBehaviour
{
    // Drag your Input Action (e.g., XRI LeftHand/Interaction/Menu) here in Inspector
    public InputActionReference homeButtonAction;

    private void OnEnable()
    {
        homeButtonAction.action.Enable();
        homeButtonAction.action.performed += ReturnHome;
    }

    private void OnDisable()
    {
        homeButtonAction.action.performed -= ReturnHome;
        homeButtonAction.action.Disable();
    }

    public void ReturnHome(InputAction.CallbackContext context)
    {
        // Loads the scene at index 0 in Build Settings
        SceneManager.LoadScene(0);
    }
}