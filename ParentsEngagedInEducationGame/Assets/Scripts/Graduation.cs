using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Graduation : MonoBehaviour
{
    [SerializeField] Transform[] stars;

    // Start is called before the first frame update
    void Start()
    {
        Sequence sequence = DOTween.Sequence();

        foreach (Transform star in stars)
        {
            sequence.Append(star.DOScale(1f, 1f));
        }
    }

    public void Continue()
    {
        LevelManager.Instance.LoadScene("Hub");
    }
}