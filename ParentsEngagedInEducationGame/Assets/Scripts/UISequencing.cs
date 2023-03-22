using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UISequencing : MonoBehaviour
{
    [SerializeField] Transform gradeCompleteText;
    [SerializeField] Transform reportCardPanel;

    public void PlaySequence()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(gradeCompleteText.DOScale(1f, 1f).SetEase(Ease.InSine)).AppendInterval(2f)       
            .Append(gradeCompleteText.DOScale(0f, 1f).SetEase(Ease.OutSine)).AppendInterval(1f)
            .Append(reportCardPanel.DOScale(1f, 1f).SetEase(Ease.InSine));
    }
}