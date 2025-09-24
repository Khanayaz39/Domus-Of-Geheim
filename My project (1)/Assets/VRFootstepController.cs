using UnityEngine;

public class VRFootstepController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] footstepClips;
    public float stepInterval = 0.5f;

    private CharacterController characterController;
    private float stepTimer = 0f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (characterController != null && characterController.velocity.magnitude > 0.1f)
        {
            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0f)
            {
                PlayFootstep();
                stepTimer = stepInterval;
            }
        }
        else
        {
            stepTimer = 0f;
        }
    }

    void PlayFootstep()
    {
        if (footstepClips.Length > 0)
        {
            int index = Random.Range(0, footstepClips.Length);
            audioSource.clip = footstepClips[index];
            audioSource.Play();
        }
    }
}