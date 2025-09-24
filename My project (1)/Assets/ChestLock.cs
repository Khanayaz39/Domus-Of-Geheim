using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ChestLock : MonoBehaviour
{
    public TMP_Text displayText; // Reference to the display text for the entered password
    public string correctPassword = "1991"; // Correct 4-digit password
    private string currentInput = ""; // Current input from the player

    public GameObject chestLid; // Reference to the chest lid (to rotate it)
    private bool isOpening = false; // Flag for checking if lid is opening
    private float rotationSpeed = 300f; // Speed of the lid opening
    private Quaternion targetRotationQuaternion; // Target rotation for the lid (90 degrees)
    private Quaternion initialRotation; // Initial rotation of the chest lid

    // Method to handle button presses for entering digits
    public void PressNumber(string number)
    {
        if (currentInput.Length < 4)
        {
            currentInput += number; // Add number to the input
            UpdateDisplay();
        }
    }

    // Method to clear the entered password
    public void ClearInput()
    {
        currentInput = ""; // Clear the input
        UpdateDisplay();
    }

    // Method to submit the password and check if it's correct
    public void SubmitPassword()
    {
        if (currentInput == correctPassword) // If the entered password matches the correct one
        {
            Debug.Log("Correct password!");
            StartOpeningLid(); // Trigger the lid opening
        }
        else
        {
            Debug.Log("Incorrect password!");
            ClearInput(); // Clear the input field for retry
        }
    }

    // Method to update the display text showing the current input
    public void UpdateDisplay()
    {
        displayText.text = currentInput; // Update the UI display with the current input
    }

    // Method to start the lid opening process
    public void StartOpeningLid()
    {
        initialRotation = chestLid.transform.localRotation; // Save the initial rotation of the chest lid
        targetRotationQuaternion = initialRotation * Quaternion.Euler(-90f, 0f, 0f); // Set the target rotation (90 degrees upwards)
        isOpening = true; // Set the flag to true to start rotating the lid
    }

    // Update is called once per frame
    private void Update()
    {
        if (isOpening)
        {
            // Smoothly rotate the chest lid towards the target rotation
            chestLid.transform.localRotation *= Quaternion.RotateTowards(chestLid.transform.localRotation, targetRotationQuaternion, rotationSpeed * Time.fixedDeltaTime);
            Debug.Log(chestLid.transform.localRotation);
            // If the lid is close enough to the target rotation, stop the opening
            if (Quaternion.Angle(chestLid.transform.localRotation, targetRotationQuaternion) < 1f)
            {
                isOpening = false; // Stop rotating when it reaches the target rotation
            }
        }
    }

    // Method to check if the entered password is correct
    public bool CheckPassword()
    {
        return currentInput == correctPassword; // Check if the entered password matches the correct one
    }
}
