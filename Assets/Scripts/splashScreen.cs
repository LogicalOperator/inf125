using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class splashScreen : MonoBehaviour
{

    public Image splashImg;
    public Image splashLogo;
    public string loadLevel;

    IEnumerator Start()
    {
        splashLogo.canvasRenderer.SetAlpha(0.0f);
        splashImg.canvasRenderer.SetAlpha(0.0f);
        yield return new WaitForSeconds(1.7f);
        FadeIn(splashLogo, 1.0f);
        yield return new WaitForSeconds(1.0f);
        FadeIn(splashImg, 1.5f);
        yield return new WaitForSeconds(2.5f);
        FadeOut(splashLogo, 2.5f);
        FadeOut(splashImg, 2.5f);
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(loadLevel);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(loadLevel);
        }
    }

    void FadeIn(Image current, float duration)
    {
        current.CrossFadeAlpha(1.0f, duration, false);
    }

    void FadeOut(Image current, float duration)
    {
        current.CrossFadeAlpha(0.0f, duration, false);
    }
}
