using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UITweening : MonoBehaviour
{
    [SerializeField] Transform settingsButtonTrans;
    [SerializeField] Transform achievementButtonTrans;
    public float movePos = 100f;
    public float startDuration = 1f;
    public float endDuration = 1f;

    Tween settingsButtonTween;
    Tween achievementButtonTween;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonTweenOut() 
    {
        settingsButtonTween = settingsButtonTrans.DOMove(settingsButtonTrans.position + Vector3.left * movePos, startDuration).SetEase(Ease.OutSine);
        achievementButtonTween = achievementButtonTrans.DOMove(achievementButtonTrans.position + Vector3.left * movePos, startDuration).SetEase(Ease.OutSine);
    }

    public void ButtonTweenIn()
    {
        settingsButtonTween = settingsButtonTrans.DOMove(settingsButtonTrans.position + Vector3.right * movePos, endDuration).SetEase(Ease.InOutElastic);
        achievementButtonTween = achievementButtonTrans.DOMove(achievementButtonTrans.position + Vector3.right * movePos, endDuration).SetEase(Ease.InOutElastic);
    }
}
