using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UITweening : MonoBehaviour
{
    [SerializeField] Transform settingsButtonTrans;
    [SerializeField] Transform achievementButtonTrans;
    [SerializeField] Transform editNameButtonTrans;
    [SerializeField] Transform settingsCloseButtonTrans;
    [SerializeField] GameObject settingsPanel;
    public float movePos = 100f;
    public float startDuration = 1f;
    public float endDuration = 1f;
    public float closePos = 100f;

    Tween settingsButtonTween;
    Tween achievementButtonTween;
    Tween editNameTween;
    Tween settingsCloseButtonTween;
    Tween settingsPanelTween;

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
        editNameTween = editNameButtonTrans.DOMove(editNameButtonTrans.position + Vector3.up * movePos, startDuration).SetEase(Ease.OutSine);
        SettingsPanelTweenIn();
    }

    public void ButtonTweenIn()
    {
        settingsButtonTween = settingsButtonTrans.DOMove(settingsButtonTrans.position + Vector3.right * movePos, endDuration).SetEase(Ease.InOutElastic);
        achievementButtonTween = achievementButtonTrans.DOMove(achievementButtonTrans.position + Vector3.right * movePos, endDuration).SetEase(Ease.InOutElastic);
        editNameTween = editNameButtonTrans.DOMove(editNameButtonTrans.position + Vector3.down * movePos, endDuration).SetEase(Ease.InOutElastic);
        SettingsPanelTweenOut();
    }

    public void SettingsPanelTweenIn()
    {
        settingsPanel.SetActive(true);
        settingsCloseButtonTween = settingsCloseButtonTrans.transform.DOMove(settingsCloseButtonTrans.position + Vector3.right * closePos, startDuration).SetEase(Ease.InSine);
        settingsPanelTween = settingsPanel.transform.DOScale(1f, 1f).SetEase(Ease.InSine);
    }

    public void SettingsPanelTweenOut()
    {
        settingsPanel.SetActive(false);
        settingsCloseButtonTween = settingsCloseButtonTrans.transform.DOMove(settingsCloseButtonTrans.position + Vector3.left * closePos, startDuration).SetEase(Ease.OutSine);
    }
}
