using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorInteractable : MonoBehaviour
{
    public Transform doorHinge;       // Assign in Inspector
    public float openAngle = 90f;
    public float openSpeed = 2f;

    private bool isOpen = false;
    private Quaternion initialRotation;
    private Quaternion targetRotation;

    private void Start()
    {
        if (doorHinge == null)
            doorHinge = transform;

        initialRotation = doorHinge.rotation;
        targetRotation = Quaternion.Euler(doorHinge.eulerAngles + new Vector3(0, openAngle, 0));
    }

    public void TryOpenDoor(XRBaseInteractor interactor)
    {
        PlayerInventory inventory = interactor.GetComponentInParent<PlayerInventory>();
        if (inventory != null && inventory.hasKey && !isOpen)
        {
            isOpen = true;
            Debug.Log("Door opened!");
        }
        else if (!isOpen)
        {
            Debug.Log("You need a key to open this door.");
        }
    }

    private void Update()
    {
        if (isOpen)
        {
            doorHinge.rotation = Quaternion.Slerp(doorHinge.rotation, targetRotation, Time.deltaTime * openSpeed);
        }
    }
}