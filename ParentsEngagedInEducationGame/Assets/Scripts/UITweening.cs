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
    [SerializeField] GameObject creditsPanel;
    [SerializeField] GameObject resetPanel;
    [SerializeField] GameObject editNamePanel;
    public float movePos = 100f;
    public float startDuration = 1f;
    public float endDuration = 1f;
    public float closePos = 100f;
    public float settingsPanelDuration = 1f;
    public float creditsPanelDuration = 1f;
    public float resetPanelDuration = 1f;
    public float editNamePanelDuration = 1f;

    Tween settingsButtonTween;
    Tween achievementButtonTween;
    Tween editNameTween;
    Tween settingsCloseButtonTween;
    Tween settingsPanelTween;
    Tween creditsPanelTween;
    Tween resetPanelTween;
    Tween editNamePanelTween;

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
        settingsCloseButtonTween = settingsCloseButtonTrans.transform.DOMove(settingsCloseButtonTrans.position + Vector3.right * closePos, startDuration).SetEase(Ease.InSine);
        settingsPanelTween = settingsPanel.transform.DOScale(1f, settingsPanelDuration).SetEase(Ease.InSine);
    }

    public void SettingsPanelTweenOut()
    {
        settingsCloseButtonTween = settingsCloseButtonTrans.transform.DOMove(settingsCloseButtonTrans.position + Vector3.left * closePos, startDuration).SetEase(Ease.OutSine);
        settingsPanelTween = settingsPanel.transform.DOScale(0f, 1).SetEase(Ease.OutSine);      
    }

   public void CreditsPanelTweenIn()
   {        
        settingsPanelTween = settingsPanel.transform.DOScale(0f, 0.5f).SetEase(Ease.OutSine);
        creditsPanelTween = creditsPanel.transform.DOScale(1f, 0.5f).SetEase(Ease.InSine);
   }    

    public void CreditsPanelTweenOut()
    {
        creditsPanelTween = creditsPanel.transform.DOScale(0f, 0.5f).SetEase(Ease.OutSine);
        settingsPanelTween = settingsPanel.transform.DOScale(1f, 0.5f).SetEase(Ease.InSine);
    }

    public void ResetPanelTweenIn()
    {
        settingsPanelTween = settingsPanel.transform.DOScale(0f, 0.5f).SetEase(Ease.OutSine);
        resetPanelTween = resetPanel.transform.DOScale(1f, 0.5f).SetEase(Ease.InSine);
    }

    public void ResetPanelTweenOut()
    {
        resetPanelTween = resetPanel.transform.DOScale(0f, 0.5f).SetEase(Ease.OutSine);
        settingsPanelTween = settingsPanel.transform.DOScale(1f, 0.5f).SetEase(Ease.InSine);  
    }

    public void EditNamePanelTweenIn()
    {
        settingsButtonTween = settingsButtonTrans.DOMove(settingsButtonTrans.position + Vector3.left * movePos, startDuration).SetEase(Ease.OutSine);
        achievementButtonTween = achievementButtonTrans.DOMove(achievementButtonTrans.position + Vector3.left * movePos, startDuration).SetEase(Ease.OutSine);
        editNameTween = editNameButtonTrans.DOMove(editNameButtonTrans.position + Vector3.up * movePos, startDuration).SetEase(Ease.OutSine);
        editNamePanelTween = editNamePanel.transform.DOScale(1f, 0.5f).SetEase(Ease.InSine);
    }

    public void EditNamePanelTweenOut()
    {
        settingsButtonTween = settingsButtonTrans.DOMove(settingsButtonTrans.position + Vector3.right * movePos, endDuration).SetEase(Ease.InOutElastic);
        achievementButtonTween = achievementButtonTrans.DOMove(achievementButtonTrans.position + Vector3.right * movePos, endDuration).SetEase(Ease.InOutElastic);
        editNameTween = editNameButtonTrans.DOMove(editNameButtonTrans.position + Vector3.down * movePos, endDuration).SetEase(Ease.InOutElastic);
        editNamePanelTween = editNamePanel.transform.DOScale(0f, 0.5f).SetEase(Ease.OutSine);
    }

}
