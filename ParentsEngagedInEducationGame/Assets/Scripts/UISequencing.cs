using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UISequencing : MonoBehaviour
{
    [SerializeField] Transform gradeCompleteText;
    [SerializeField] Transform reportCardPanel;
    [SerializeField] Transform[] gradeStars;
    [SerializeField] GameObject[] gradeStarsEmpty;

    public void PlaySequence()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(gradeCompleteText.DOScale(1f, 1f).SetEase(Ease.InSine)).AppendInterval(1f)       
            .Append(gradeCompleteText.DOScale(0f, 1f).SetEase(Ease.OutSine)).AppendInterval(1f)
            .Append(reportCardPanel.DOScale(1f, 1f).SetEase(Ease.InSine)).AppendInterval(1f);

        foreach (GameObject star in gradeStarsEmpty)
        {
            star.SetActive(false);         
        }

        foreach (Transform star in gradeStars)
        {        
            sequence.Append(star.DOScale(0.4036823f, 0.5f).SetEase(Ease.InSine)).AppendInterval(1f);
        }
    }
}