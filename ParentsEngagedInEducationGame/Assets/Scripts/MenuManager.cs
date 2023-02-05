using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] SceneManagement sceneManager;
    [SerializeField] Image fillableBar;
    [SerializeField] float time = 10f;
    bool isBarFilled = false;

    // Start is called before the first frame update
    void Start()
    {
        fillableBar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        BufferSceneTransition();
    }

    public void BufferSceneTransition()
    {
        fillableBar.fillAmount += 1.0f / time * Time.deltaTime;

        if (fillableBar.fillAmount == 1)
        {
            isBarFilled = true;
        }

        if (isBarFilled)
        {
            sceneManager.FadeToScene();
            SceneManager.LoadScene(2);
            isBarFilled = false;
        }
    }
}
