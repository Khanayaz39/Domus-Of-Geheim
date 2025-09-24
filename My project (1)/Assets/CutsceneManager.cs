using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public TextMeshProUGUI cutsceneText;
    public Button continueButton;

    public float fadeDuration = 1.5f;
    public float textDisplayTime = 4f;

    private string[] storyLines = new string[]
    {
        "A storm rages outside. The wipers struggle to clear the windshield...",
        "Suddenly, an animal darts across the road. He swerves—CRASH!",
        "Moments later, he wakes up. The rain has stopped...",
        "Seeking help, he stumbles forward...",
        "The door is ajar. He knocks. No answer...",
        "SLAM! The door shuts behind him...",
        "Trapped and alone, the only way is forward..."
    };

    private void Start()
    {
        continueButton.gameObject.SetActive(false);
        continueButton.onClick.AddListener(LoadSampleScene);
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

        cutsceneText.text = "";
        canvasGroup.alpha = 1f;
        continueButton.gameObject.SetActive(true);
    }

    private IEnumerator FadeIn()
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            timer += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 1f;
    }

    private IEnumerator FadeOut()
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            timer += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 0f;
    }

    public void LoadSampleScene()
    {
        SceneManager.LoadScene("SampleScene"); // Go to main gameplay
    }
}
