using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

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

    [SerializeField] ScrollRect achievementScroll;

    [SerializeField] GameObject hallway;
    [SerializeField] GameObject classroom;

    public bool isPanelOpen { get; private set; } = false;

    public void ButtonTweenOut() 
    {
        print("Button Out");
        settingsButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        achievementButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        editNameButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        playButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        SettingsPanelTweenIn();
    }

    public void ButtonTweenIn()
    {
        print("Button In");
        settingsButtonTrans.DOScale(0.71721f, endDuration).SetEase(Ease.InSine);
        achievementButtonTrans.DOScale(0.71721f, endDuration).SetEase(Ease.InSine);
        editNameButtonTrans.DOScale(1f, endDuration).SetEase(Ease.InSine);
        playButtonTrans.DOScale(1f, endDuration).SetEase(Ease.InSine);
        SettingsPanelTweenOut();
    }

    public void SettingsPanelTweenIn()
    {
        print("Settings In");
        settingsCloseButtonTrans.transform.DOScale(1f, startDuration).SetEase(Ease.InSine);
        settingsPanel.transform.DOScale(1f, settingsPanelDuration).SetEase(Ease.InSine);
    }

    public void SettingsPanelTweenOut()
    {
        print("Settings Out");
        settingsCloseButtonTrans.transform.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        settingsPanel.transform.DOScale(0f, settingsPanelDuration).SetEase(Ease.OutSine);      
    }

   public void CreditsPanelTweenIn()
   {
        print("Credits In");
        settingsPanel.transform.DOScale(0f, settingsPanelDuration).SetEase(Ease.OutSine);
        creditsPanel.transform.DOScale(1f, creditsPanelDuration).SetEase(Ease.InSine);
   }    

    public void CreditsPanelTweenOut()
    {
        print("Credits Out");
        creditsPanel.transform.DOScale(0f, creditsPanelDuration).SetEase(Ease.OutSine);
        settingsPanel.transform.DOScale(1f, settingsPanelDuration).SetEase(Ease.InSine);
    }

    public void ResetPanelTweenIn()
    {
        print("Reset In");
        resetPanel.transform.DOScale(1f, resetPanelDuration).SetEase(Ease.InSine);
        settingsPanel.transform.DOScale(0f, resetPanelDuration).SetEase(Ease.OutSine);
    }

    public void ResetPanelTweenOut()
    {
        print("Reset Out");
        resetPanel.transform.DOScale(0f, resetPanelDuration).SetEase(Ease.OutSine);
        settingsPanel.transform.DOScale(1f, settingsPanelDuration).SetEase(Ease.InSine);  
    }

    public void EditNamePanelTweenIn()
    {
        if (editNameButtonTrans != null)
        {
            print("Edit In");
            settingsButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
            achievementButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
            editNameButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
            playButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
            editNamePanel.transform.DOScale(1f, editNamePanelDuration).SetEase(Ease.InSine);
        }
    }

    public void EditNamePanelTweenOut()
    {
        print("Edit Out");
        settingsButtonTrans.DOScale(0.71721f, endDuration).SetEase(Ease.InSine);
        achievementButtonTrans.DOScale(0.71721f, endDuration).SetEase(Ease.InSine);
        editNameButtonTrans.DOScale(1f, endDuration).SetEase(Ease.InSine);
        playButtonTrans.DOScale(1f, endDuration).SetEase(Ease.InSine);
        editNamePanel.transform.DOScale(0f, editNamePanelDuration).SetEase(Ease.OutSine);
    }

    public void AchievementsPanelTweenIn()
    {
        print("Achievements In");
        settingsButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        achievementButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        editNameButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        playButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        achievementsPanel.DOScale(1f, achievementsPanelDuration).SetEase(Ease.InSine);
        achievementsCloseButtonTrans.DOScale(1f, startDuration).SetEase(Ease.InSine);
    }

    public void AchievementsPanelTweenOut()
    {
        print("Achievements Out");
        settingsButtonTrans.DOScale(0.71721f, endDuration).SetEase(Ease.InSine);
        achievementButtonTrans.DOScale(0.71721f, endDuration).SetEase(Ease.InSine);
        editNameButtonTrans.DOScale(1f, endDuration).SetEase(Ease.InSine);
        playButtonTrans.DOScale(1f, endDuration).SetEase(Ease.InSine);
        achievementsPanel.DOScale(0f, achievementsPanelDuration).SetEase(Ease.OutSine);
        achievementsCloseButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);

        achievementScroll.verticalNormalizedPosition = 1;
    }

    public void SettingsMainTweenIn()
    {
        print("Settings Main In");
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
        print("Settings Main Out");
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
        print("AchievementsMain In");
        settingsButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        achievementButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        achievementsPanel.DOScale(1f, achievementsPanelDuration).SetEase(Ease.InSine);
        achievementsCloseButtonTrans.DOScale(1f, startDuration).SetEase(Ease.InSine);

        isPanelOpen = true;       
    }

    public void AchievementsPanelMainTweenOut()
    {
        print("AchievementsMain Out");
        settingsButtonTrans.DOScale(0.71721f, startDuration).SetEase(Ease.InSine);
        achievementButtonTrans.DOScale(0.71721f, startDuration).SetEase(Ease.InSine);
        achievementsPanel.DOScale(0f, achievementsPanelDuration).SetEase(Ease.OutSine);
        achievementsCloseButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);

        isPanelOpen = false;
    }

    public void QuitPanelMain()
    {
        if (hallway.activeInHierarchy)
        {
            LevelManager.Instance.LoadScene("Hub");
        }
        else if (classroom.activeInHierarchy)
        {
            LevelManager.Instance.LoadScene("Main");
        }    
    }

    public void QuitPanelTweenIn()
    {
        print("Quit In");
        settingsPanel.transform.DOScale(0f, settingsPanelDuration).SetEase(Ease.OutSine);
        quitPanel.transform.DOScale(1f, settingsPanelDuration).SetEase(Ease.InSine);
    }

    public void QuitPanelTweenOut()
    {
        print("Quit Out");
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