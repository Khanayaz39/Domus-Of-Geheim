using System.Collections;
using UnityEngine;
using TMPro;

public class IntroCutscene : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public TMP_Text cutsceneText;
    public float fadeDuration = 1f;
    public float textDisplayTime = 5f;

    private string[] storyLines = new string[]
    {
        "A storm rages outside. The wipers struggle to clear the windshield as the player drives down a desolate highway, lost in thought—memories of his late wife haunting every mile.",
        "Suddenly, an animal darts across the road. He swerves—CRASH!",
        "Moments later, he wakes up. The rain has stopped, but a thick, eerie fog surrounds the car. The highway feels… wrong. Silent. Unnatural.",
        "Seeking help, he stumbles forward, disoriented, until a strange, old house emerges through the mist.",
        "The door is ajar. He knocks. No answer. He steps inside.",
        "SLAM! The door shuts behind him. It won’t open.",
        "Trapped and alone, the only way is forward—deeper into the unknown secrets of the Domus of Geheim."
    };

    private void Start()
    {
        StartCoroutine(PlayCutscene());
    }

    private IEnumerator PlayCutscene()
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;

        foreach (string line in storyLines)
        {
            yield return StartCoroutine(FadeIn());
            cutsceneText.text = line;
            yield return new WaitForSeconds(textDisplayTime);
            yield return StartCoroutine(FadeOut());
        }

        // Hide after the last line
        cutsceneText.text = "";
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
    }

    private IEnumerator FadeIn()
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(0, 1, t / fadeDuration);
            t += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 1;
    }

    private IEnumerator FadeOut()
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(1, 0, t / fadeDuration);
            t += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 0;
    }
}
