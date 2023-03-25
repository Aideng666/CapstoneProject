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
    [SerializeField] Transform playButtonTrans;
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject creditsPanel;
    [SerializeField] GameObject resetPanel;
    [SerializeField] GameObject editNamePanel;
    [SerializeField] Transform achievementsPanel;
    [SerializeField] Transform achievementsCloseButtonTrans;
    [SerializeField] Transform quitPanel;
    [SerializeField] Transform[] starFills;

    [SerializeField] Transform[] answerButtonTrans;
    [SerializeField] GameObject questionPanel;
    public float startDuration = 1f;
    public float endDuration = 1f;
    public float settingsPanelDuration = 1f;
    public float creditsPanelDuration = 1f;
    public float resetPanelDuration = 1f;
    public float editNamePanelDuration = 1f;
    public float achievementsPanelDuration = 1f;

    Tween settingsButtonTween;
    Tween achievementButtonTween;
    Tween editNameTween;
    Tween playButtonTween;
    Tween settingsCloseButtonTween;
    Tween settingsPanelTween;
    Tween creditsPanelTween;
    Tween resetPanelTween;
    Tween editNamePanelTween;
    Tween achievementsPanelTween;
    Tween achievementsCloseButtonTween;

    Tween answerButtonsTween;
    Tween quitPanelTween;

    public bool isPanelOpen { get; private set; } = false;

    public void ButtonTweenOut() 
    {
        settingsButtonTween = settingsButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        achievementButtonTween = achievementButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        editNameTween = editNameButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        playButtonTween = playButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        SettingsPanelTweenIn();
    }

    public void ButtonTweenIn()
    {
        settingsButtonTween = settingsButtonTrans.DOScale(0.71721f, endDuration).SetEase(Ease.InSine);
        achievementButtonTween = achievementButtonTrans.DOScale(0.71721f, endDuration).SetEase(Ease.InSine);
        editNameTween = editNameButtonTrans.DOScale(1f, endDuration).SetEase(Ease.InSine);
        playButtonTween = playButtonTrans.DOScale(1f, endDuration).SetEase(Ease.InSine);
        SettingsPanelTweenOut();
    }

    public void SettingsPanelTweenIn()
    {
        settingsCloseButtonTween = settingsCloseButtonTrans.transform.DOScale(1f, startDuration).SetEase(Ease.InSine);
        settingsPanelTween = settingsPanel.transform.DOScale(1f, settingsPanelDuration).SetEase(Ease.InSine);
    }

    public void SettingsPanelTweenOut()
    {
        settingsCloseButtonTween = settingsCloseButtonTrans.transform.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        settingsPanelTween = settingsPanel.transform.DOScale(0f, settingsPanelDuration).SetEase(Ease.OutSine);      
    }

   public void CreditsPanelTweenIn()
   {        
        settingsPanelTween = settingsPanel.transform.DOScale(0f, settingsPanelDuration).SetEase(Ease.OutSine);
        creditsPanelTween = creditsPanel.transform.DOScale(1f, creditsPanelDuration).SetEase(Ease.InSine);
   }    

    public void CreditsPanelTweenOut()
    {
        creditsPanelTween = creditsPanel.transform.DOScale(0f, creditsPanelDuration).SetEase(Ease.OutSine);
        settingsPanelTween = settingsPanel.transform.DOScale(1f, settingsPanelDuration).SetEase(Ease.InSine);
    }

    public void ResetPanelTweenIn()
    {
        resetPanelTween = resetPanel.transform.DOScale(1f, resetPanelDuration).SetEase(Ease.InSine);
        settingsPanelTween = settingsPanel.transform.DOScale(0f, resetPanelDuration).SetEase(Ease.OutSine);
    }

    public void ResetPanelTweenOut()
    {
        resetPanelTween = resetPanel.transform.DOScale(0f, resetPanelDuration).SetEase(Ease.OutSine);
        settingsPanelTween = settingsPanel.transform.DOScale(1f, settingsPanelDuration).SetEase(Ease.InSine);  
    }

    public void EditNamePanelTweenIn()
    {
        settingsButtonTween = settingsButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        achievementButtonTween = achievementButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        editNameTween = editNameButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        playButtonTween = playButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        editNamePanelTween = editNamePanel.transform.DOScale(1f, editNamePanelDuration).SetEase(Ease.InSine);
    }

    public void EditNamePanelTweenOut()
    {
        settingsButtonTween = settingsButtonTrans.DOScale(1f, endDuration).SetEase(Ease.InSine);
        achievementButtonTween = achievementButtonTrans.DOScale(1f, endDuration).SetEase(Ease.InSine);
        editNameTween = editNameButtonTrans.DOScale(1f, endDuration).SetEase(Ease.InSine);
        playButtonTween = playButtonTrans.DOScale(1f, endDuration).SetEase(Ease.InSine);
        editNamePanelTween = editNamePanel.transform.DOScale(0f, editNamePanelDuration).SetEase(Ease.OutSine);
    }

    public void AchievementsPanelTweenIn()
    {
        settingsButtonTween = settingsButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        achievementButtonTween = achievementButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        editNameTween = editNameButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        playButtonTween = playButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        achievementsPanelTween = achievementsPanel.DOScale(1f, achievementsPanelDuration).SetEase(Ease.InSine);
        achievementsCloseButtonTween = achievementsCloseButtonTrans.DOScale(1f, startDuration).SetEase(Ease.InSine);
    }

    public void AchievementsPanelTweenOut()
    {
        settingsButtonTween = settingsButtonTrans.DOScale(0.71721f, endDuration).SetEase(Ease.InSine);
        achievementButtonTween = achievementButtonTrans.DOScale(0.71721f, endDuration).SetEase(Ease.InSine);
        editNameTween = editNameButtonTrans.DOScale(1f, endDuration).SetEase(Ease.InSine);
        playButtonTween = playButtonTrans.DOScale(1f, endDuration).SetEase(Ease.InSine);
        achievementsPanelTween = achievementsPanel.DOScale(0f, achievementsPanelDuration).SetEase(Ease.OutSine);
        achievementsCloseButtonTween = achievementsCloseButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
    }

    public void SettingsMainTweenIn()
    {
        settingsButtonTween = settingsButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        settingsPanelTween = settingsPanel.transform.DOScale(1f, settingsPanelDuration).SetEase(Ease.InSine);
        achievementButtonTween = achievementButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        questionPanel.SetActive(false);

        foreach (Transform trans in answerButtonTrans)
        {
            answerButtonsTween = trans.DOScale(0f, settingsPanelDuration).SetEase(Ease.OutSine);
        }

        isPanelOpen = true;
    }

    public void SettingsMainTweenOut()
    {
        settingsButtonTween = settingsButtonTrans.DOScale(0.71721f, endDuration).SetEase(Ease.InSine);
        settingsPanelTween = settingsPanel.transform.DOScale(0f, settingsPanelDuration).SetEase(Ease.OutSine);
        achievementButtonTween = achievementButtonTrans.DOScale(0.71721f, endDuration).SetEase(Ease.InSine);
        questionPanel.SetActive(true);

        foreach (Transform trans in answerButtonTrans)
        {
            answerButtonsTween = trans.DOScale(1f, settingsPanelDuration).SetEase(Ease.InSine);
        }

        isPanelOpen = false;
    }

    public void AchievementsPanelMainTweenIn()
    {
        settingsButtonTween = settingsButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        achievementButtonTween = achievementButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        achievementsPanelTween = achievementsPanel.DOScale(1f, achievementsPanelDuration).SetEase(Ease.InSine);
        achievementsCloseButtonTween = achievementsCloseButtonTrans.DOScale(1f, startDuration).SetEase(Ease.InSine);

        isPanelOpen = true;       
    }

    public void AchievementsPanelMainTweenOut()
    {
        settingsButtonTween = settingsButtonTrans.DOScale(0.71721f, startDuration).SetEase(Ease.InSine);
        achievementButtonTween = achievementButtonTrans.DOScale(0.71721f, startDuration).SetEase(Ease.InSine);
        achievementsPanelTween = achievementsPanel.DOScale(0f, achievementsPanelDuration).SetEase(Ease.OutSine);
        achievementsCloseButtonTween = achievementsCloseButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);

        isPanelOpen = false;
    }

    public void QuitPanelMain()
    {
        LevelManager.Instance.LoadScene("Hub");
    }

    public void QuitPanelTweenIn()
    {
        settingsPanelTween = settingsPanel.transform.DOScale(0f, settingsPanelDuration).SetEase(Ease.OutSine);
        quitPanelTween = quitPanel.transform.DOScale(1f, settingsPanelDuration).SetEase(Ease.InSine);
    }

    public void QuitPanelTweenOut()
    {
        settingsButtonTween = settingsButtonTrans.DOScale(0.71721f, endDuration).SetEase(Ease.InSine);
        achievementButtonTween = achievementButtonTrans.DOScale(0.71721f, endDuration).SetEase(Ease.InSine);
        quitPanelTween = quitPanel.transform.DOScale(0f, settingsPanelDuration).SetEase(Ease.OutSine);
     
        questionPanel.SetActive(true);
        foreach (Transform trans in answerButtonTrans)
        {
            answerButtonsTween = trans.DOScale(1f, settingsPanelDuration).SetEase(Ease.InSine);
        }

        isPanelOpen = false;
    }
}