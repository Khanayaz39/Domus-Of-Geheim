using UnityEngine;
using System.Collections;

public class ChestLidOpener : MonoBehaviour
{
    public Transform lid;          // Assign your lid GameObject here
    public float openSpeed = 3f;   // Speed of rotation
    public bool isOpened = false;  // Whether the lid has been opened

    private Quaternion targetRotation;

    public void OpenLid()
    {
        if (isOpened) return;

        // Rotate 90 degrees upward on the local X-axis from current rotation
        targetRotation = Quaternion.Euler(-90f, lid.localEulerAngles.y, lid.localEulerAngles.z);
        StartCoroutine(RotateLid());
    }

    private IEnumerator RotateLid()
    {
        isOpened = true;

        while (Quaternion.Angle(lid.localRotation, targetRotation) > 0.1f)
        {
            lid.localRotation = Quaternion.RotateTowards(
                lid.localRotation,
                targetRotation,
                openSpeed * Time.deltaTime * 100f
            );
            yield return null;
        }

        lid.localRotation = targetRotation;
    }
}