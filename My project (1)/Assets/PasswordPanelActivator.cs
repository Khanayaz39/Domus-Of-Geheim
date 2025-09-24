using UnityEngine;

public class PasswordPanelActivator : MonoBehaviour
{
    public GameObject passwordPanel; // Assign PasswordPanel here

    private bool isPanelOpen = false;

    public void InteractWithLock()
    {
        if (!isPanelOpen)
        {
            passwordPanel.SetActive(true); // Show the panel
            isPanelOpen = true;
        }
    }
}