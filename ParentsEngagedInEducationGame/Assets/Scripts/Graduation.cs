using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Graduation : MonoBehaviour
{
    [SerializeField] Transform[] stars;

    // Start is called before the first frame update
    //Plays the graduation stars sequence
    void Start()
    {
        Sequence sequence = DOTween.Sequence();

        foreach (Transform star in stars)
        {
            sequence.Append(star.DOScale(1f, 1f));
        }
    }

    //Returns to the hub menu
    public void Continue()
    {
        SceneManager.LoadScene("Hub");
    }
}