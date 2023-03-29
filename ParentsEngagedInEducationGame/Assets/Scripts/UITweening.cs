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

    [SerializeField] Transform[] answerButtonTrans;
    [SerializeField] GameObject questionPanel;
    public float startDuration = 1f;
    public float endDuration = 1f;
    public float settingsPanelDuration = 1f;
    public float creditsPanelDuration = 1f;
    public float resetPanelDuration = 1f;
    public float editNamePanelDuration = 1f;
    public float achievementsPanelDuration = 1f;

    public bool isPanelOpen { get; private set; } = false;

    public void ButtonTweenOut() 
    {
        settingsButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        achievementButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        editNameButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        playButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        SettingsPanelTweenIn();
    }

    public void ButtonTweenIn()
    {
        settingsButtonTrans.DOScale(0.71721f, endDuration).SetEase(Ease.InSine);
        achievementButtonTrans.DOScale(0.71721f, endDuration).SetEase(Ease.InSine);
        editNameButtonTrans.DOScale(1f, endDuration).SetEase(Ease.InSine);
        playButtonTrans.DOScale(1f, endDuration).SetEase(Ease.InSine);
        SettingsPanelTweenOut();
    }

    public void SettingsPanelTweenIn()
    {
        settingsCloseButtonTrans.transform.DOScale(1f, startDuration).SetEase(Ease.InSine);
        settingsPanel.transform.DOScale(1f, settingsPanelDuration).SetEase(Ease.InSine);
    }

    public void SettingsPanelTweenOut()
    {
        settingsCloseButtonTrans.transform.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        settingsPanel.transform.DOScale(0f, settingsPanelDuration).SetEase(Ease.OutSine);      
    }

   public void CreditsPanelTweenIn()
   {        
        settingsPanel.transform.DOScale(0f, settingsPanelDuration).SetEase(Ease.OutSine);
        creditsPanel.transform.DOScale(1f, creditsPanelDuration).SetEase(Ease.InSine);
   }    

    public void CreditsPanelTweenOut()
    {
        creditsPanel.transform.DOScale(0f, creditsPanelDuration).SetEase(Ease.OutSine);
        settingsPanel.transform.DOScale(1f, settingsPanelDuration).SetEase(Ease.InSine);
    }

    public void ResetPanelTweenIn()
    {
        resetPanel.transform.DOScale(1f, resetPanelDuration).SetEase(Ease.InSine);
        settingsPanel.transform.DOScale(0f, resetPanelDuration).SetEase(Ease.OutSine);
    }

    public void ResetPanelTweenOut()
    {
        resetPanel.transform.DOScale(0f, resetPanelDuration).SetEase(Ease.OutSine);
        settingsPanel.transform.DOScale(1f, settingsPanelDuration).SetEase(Ease.InSine);  
    }

    public void EditNamePanelTweenIn()
    {
        settingsButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        achievementButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        editNameButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        playButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        editNamePanel.transform.DOScale(1f, editNamePanelDuration).SetEase(Ease.InSine);
    }

    public void EditNamePanelTweenOut()
    {
        settingsButtonTrans.DOScale(0.71721f, endDuration).SetEase(Ease.InSine);
        achievementButtonTrans.DOScale(0.71721f, endDuration).SetEase(Ease.InSine);
        editNameButtonTrans.DOScale(1f, endDuration).SetEase(Ease.InSine);
        playButtonTrans.DOScale(1f, endDuration).SetEase(Ease.InSine);
        editNamePanel.transform.DOScale(0f, editNamePanelDuration).SetEase(Ease.OutSine);
    }

    public void AchievementsPanelTweenIn()
    {
        settingsButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        achievementButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        editNameButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        playButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        achievementsPanel.DOScale(1f, achievementsPanelDuration).SetEase(Ease.InSine);
        achievementsCloseButtonTrans.DOScale(1f, startDuration).SetEase(Ease.InSine);
    }

    public void AchievementsPanelTweenOut()
    {
        settingsButtonTrans.DOScale(0.71721f, endDuration).SetEase(Ease.InSine);
        achievementButtonTrans.DOScale(0.71721f, endDuration).SetEase(Ease.InSine);
        editNameButtonTrans.DOScale(1f, endDuration).SetEase(Ease.InSine);
        playButtonTrans.DOScale(1f, endDuration).SetEase(Ease.InSine);
        achievementsPanel.DOScale(0f, achievementsPanelDuration).SetEase(Ease.OutSine);
        achievementsCloseButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);

        //scrollView.ScrollTo(scrollView.ElementAt(0));
        //scrollRect.verticalNormalizedPosition = 0;
    }

    public void SettingsMainTweenIn()
    {
        settingsButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        settingsPanel.transform.DOScale(1f, settingsPanelDuration).SetEase(Ease.InSine);
        achievementButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        questionPanel.SetActive(false);

        foreach (Transform trans in answerButtonTrans)
        {
            trans.DOScale(0f, settingsPanelDuration).SetEase(Ease.OutSine);
        }

        isPanelOpen = true;
    }

    public void SettingsMainTweenOut()
    {
        settingsButtonTrans.DOScale(0.71721f, endDuration).SetEase(Ease.InSine);
        settingsPanel.transform.DOScale(0f, settingsPanelDuration).SetEase(Ease.OutSine);
        achievementButtonTrans.DOScale(0.71721f, endDuration).SetEase(Ease.InSine);
        questionPanel.SetActive(true);

        foreach (Transform trans in answerButtonTrans)
        {
            trans.DOScale(1f, settingsPanelDuration).SetEase(Ease.InSine);
        }

        isPanelOpen = false;
    }

    public void AchievementsPanelMainTweenIn()
    {
        settingsButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        achievementButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        achievementsPanel.DOScale(1f, achievementsPanelDuration).SetEase(Ease.InSine);
        achievementsCloseButtonTrans.DOScale(1f, startDuration).SetEase(Ease.InSine);

        isPanelOpen = true;       
    }

    public void AchievementsPanelMainTweenOut()
    {
        settingsButtonTrans.DOScale(0.71721f, startDuration).SetEase(Ease.InSine);
        achievementButtonTrans.DOScale(0.71721f, startDuration).SetEase(Ease.InSine);
        achievementsPanel.DOScale(0f, achievementsPanelDuration).SetEase(Ease.OutSine);
        achievementsCloseButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);

        isPanelOpen = false;
    }

    public void QuitPanelMain()
    {
        LevelManager.Instance.LoadScene("Hub");
    }

    public void QuitPanelTweenIn()
    {
        settingsPanel.transform.DOScale(0f, settingsPanelDuration).SetEase(Ease.OutSine);
        quitPanel.transform.DOScale(1f, settingsPanelDuration).SetEase(Ease.InSine);
    }

    public void QuitPanelTweenOut()
    {
        settingsButtonTrans.DOScale(0.71721f, endDuration).SetEase(Ease.InSine);
        achievementButtonTrans.DOScale(0.71721f, endDuration).SetEase(Ease.InSine);
        quitPanel.transform.DOScale(0f, settingsPanelDuration).SetEase(Ease.OutSine);
     
        questionPanel.SetActive(true);
        foreach (Transform trans in answerButtonTrans)
        {
            trans.DOScale(1f, settingsPanelDuration).SetEase(Ease.InSine);
        }

        isPanelOpen = false;
    }
}