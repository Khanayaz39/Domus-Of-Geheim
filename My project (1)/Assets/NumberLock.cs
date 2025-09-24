using UnityEngine;
using UnityEngine.UI;

public class NumberLock : MonoBehaviour
{
    public Text displayText; // Reference to the display text
    public string correctPassword = "1991"; // Correct 4-digit password
    private string currentInput = ""; // Current input from the player

    public GameObject chestLid; // Reference to the chest lid
    private bool isOpening = false; // Flag for lid opening
    private float rotationSpeed = 3f; // Speed of the lid opening
    private float targetRotation = 90f; // 90 degrees for opening

    private Quaternion targetRotationQuaternion; // Target rotation as a Quaternion
    private Quaternion initialRotation; // Initial rotation of the chest lid

    public void PressNumber(string number)
    {
        if (currentInput.Length < 4)
        {
            currentInput += number; // Add number to input
            UpdateDisplay();
        }
    }

    public void ClearInput()
    {
        currentInput = ""; // Clear the input
        UpdateDisplay();
    }

    public void SubmitPassword()
    {
        if (currentInput == correctPassword) // Check if input is correct
        {
            Debug.Log("Correct password!");
            StartOpeningLid(); // Trigger lid opening
        }
        else
        {
            Debug.Log("Wrong password!");
            ClearInput(); // Clear input if wrong password
        }
    }

    public void UpdateDisplay()
    {
        displayText.text = currentInput; // Update the UI display with current input
    }

    public bool CheckPassword()
    {
        return currentInput == correctPassword; // Check if the entered password matches the correct one
    }

    public void StartOpeningLid()
    {
        isOpening = true; // Start rotating the lid
        initialRotation = chestLid.transform.localRotation; // Store initial rotation
        targetRotationQuaternion = initialRotation * Quaternion.Euler(90f, 0f, 0f); // Set target rotation
    }

    private void Update()
    {
        if (isOpening)
        {
            // Smoothly rotate towards the target rotation
            chestLid.transform.localRotation = Quaternion.RotateTowards(chestLid.transform.localRotation, targetRotationQuaternion, rotationSpeed * Time.deltaTime);
            if (Quaternion.Angle(chestLid.transform.localRotation, targetRotationQuaternion) < 1f)
            {
                isOpening = false; // Stop the rotation once it reaches the target rotation
            }
        }
    }
}
