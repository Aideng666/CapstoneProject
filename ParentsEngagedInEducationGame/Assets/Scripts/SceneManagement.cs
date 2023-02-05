using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagement : MonoBehaviour
{
    public Animator animator;
    public int sceneToLoad;
    public bool shouldAutoLoad = false;
    public bool canProceed = false;

    public void FadeToScene()
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeOutComplete()
    {
        if (shouldAutoLoad)
        {
            SceneManager.LoadScene(sceneToLoad);
        }    

        if (canProceed)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    public void OnFadeInComplete()
    {
        if (shouldAutoLoad)
        {
            FadeToScene();
        }
    }
}
