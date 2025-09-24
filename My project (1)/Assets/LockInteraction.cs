using UnityEngine;
using UnityEngine.UI;

public class LockInteraction : MonoBehaviour
{
    public GameObject passwordUI; // Reference to the UI panel with the password input field
    public GameObject chestLid; // Reference to the chest lid
    public string correctPassword = "1991"; // Set your 4-digit password here
    public NumberLock numberLockScript; // Reference to the NumberLock script (responsible for rotating the chest lid)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player is interacting with the lock
        {
            passwordUI.SetActive(true); // Show the password UI
        }
    }

    public void OnSubmitPassword()
    {
        // Check if the entered password matches
        if (numberLockScript.CheckPassword())
        {
            Debug.Log("Password Correct!");
            numberLockScript.StartOpeningLid(); // Trigger lid opening
            passwordUI.SetActive(false); // Hide the UI
        }
        else
        {
            Debug.Log("Incorrect Password");
            numberLockScript.ClearInput(); // Clear the input field for retry
        }
    }

    public void OnClearPassword()
    {
        numberLockScript.ClearInput(); // Clear the input field for retry
    }
}