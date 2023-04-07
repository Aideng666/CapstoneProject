using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UITweening : MonoBehaviour
{
    //UI References
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
    //[SerializeField] Transform quitHubPanel;
    //[SerializeField] Transform quitHubButton;

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

    /// <summary>
    /// Animates the buttons out making them inactive
    /// </summary>
    public void ButtonTweenOut() 
    {
        settingsButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        achievementButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        editNameButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        playButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        //quitHubButton.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        SettingsPanelTweenIn();
    }

    /// <summary>
    /// animates the buttons making them active
    /// </summary>
    public void ButtonTweenIn()
    {
        settingsButtonTrans.DOScale(0.71721f, endDuration).SetEase(Ease.InSine);
        achievementButtonTrans.DOScale(0.71721f, endDuration).SetEase(Ease.InSine);
        editNameButtonTrans.DOScale(1f, endDuration).SetEase(Ease.InSine);
        playButtonTrans.DOScale(1f, endDuration).SetEase(Ease.InSine);
        //quitHubButton.DOScale(1f, endDuration).SetEase(Ease.InSine);
        SettingsPanelTweenOut();
    }

    /// <summary>
    /// Animates the settings panel opening
    /// </summary>
    public void SettingsPanelTweenIn()
    {
        settingsCloseButtonTrans.transform.DOScale(1f, startDuration).SetEase(Ease.InSine);
        settingsPanel.transform.DOScale(1f, settingsPanelDuration).SetEase(Ease.InSine);
    }

    /// <summary>
    /// Animates the settings panel closing
    /// </summary>
    public void SettingsPanelTweenOut()
    {
        settingsCloseButtonTrans.transform.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        settingsPanel.transform.DOScale(0f, settingsPanelDuration).SetEase(Ease.OutSine);      
    }

    /// <summary>
    /// Animates the credits panel opening
    /// </summary>
    public void CreditsPanelTweenIn()
   {
        settingsPanel.transform.DOScale(0f, settingsPanelDuration).SetEase(Ease.OutSine);
        creditsPanel.transform.DOScale(1f, creditsPanelDuration).SetEase(Ease.InSine);
   }

    /// <summary>
    /// Animates the credits panel closing
    /// </summary>
    public void CreditsPanelTweenOut()
    {
        creditsPanel.transform.DOScale(0f, creditsPanelDuration).SetEase(Ease.OutSine);
        settingsPanel.transform.DOScale(1f, settingsPanelDuration).SetEase(Ease.InSine);
    }

    /// <summary>
    /// Animates the reset panel opening
    /// </summary>
    public void ResetPanelTweenIn()
    {
        resetPanel.transform.DOScale(1f, resetPanelDuration).SetEase(Ease.InSine);
        settingsPanel.transform.DOScale(0f, resetPanelDuration).SetEase(Ease.OutSine);
    }

    /// <summary>
    /// Animates the reset panel closing
    /// </summary>
    public void ResetPanelTweenOut()
    {
        resetPanel.transform.DOScale(0f, resetPanelDuration).SetEase(Ease.OutSine);
        settingsPanel.transform.DOScale(1f, settingsPanelDuration).SetEase(Ease.InSine);  
    }

    /// <summary>
    /// Animates the name panel opening
    /// </summary>
    public void EditNamePanelTweenIn()
    {
        if (editNameButtonTrans != null)
        {
            settingsButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
            achievementButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
            editNameButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
            playButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
            editNamePanel.transform.DOScale(1f, editNamePanelDuration).SetEase(Ease.InSine);
            //quitHubButton.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        }
    }

    /// <summary>
    /// Animates the name panel closing
    /// </summary>
    public void EditNamePanelTweenOut()
    {
        settingsButtonTrans.DOScale(0.71721f, endDuration).SetEase(Ease.InSine);
        achievementButtonTrans.DOScale(0.71721f, endDuration).SetEase(Ease.InSine);
        editNameButtonTrans.DOScale(1f, endDuration).SetEase(Ease.InSine);
        playButtonTrans.DOScale(1f, endDuration).SetEase(Ease.InSine);
        editNamePanel.transform.DOScale(0f, editNamePanelDuration).SetEase(Ease.OutSine);
        //quitHubButton.DOScale(1f, endDuration).SetEase(Ease.InSine);
    }

    /// <summary>
    /// Animates the achievements panel opening
    /// </summary>
    public void AchievementsPanelTweenIn()
    {
        settingsButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        achievementButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        editNameButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        playButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        achievementsPanel.DOScale(1f, achievementsPanelDuration).SetEase(Ease.InSine);
        achievementsCloseButtonTrans.DOScale(1f, startDuration).SetEase(Ease.InSine);
        //quitHubButton.DOScale(0f, startDuration).SetEase(Ease.OutSine);
    }

    /// <summary>
    /// Animates the achievements panel closing
    /// </summary>
    public void AchievementsPanelTweenOut()
    {
        settingsButtonTrans.DOScale(0.71721f, endDuration).SetEase(Ease.InSine);
        achievementButtonTrans.DOScale(0.71721f, endDuration).SetEase(Ease.InSine);
        editNameButtonTrans.DOScale(1f, endDuration).SetEase(Ease.InSine);
        playButtonTrans.DOScale(1f, endDuration).SetEase(Ease.InSine);
        achievementsPanel.DOScale(0f, achievementsPanelDuration).SetEase(Ease.OutSine);
        achievementsCloseButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        //quitHubButton.DOScale(1f, endDuration).SetEase(Ease.InSine);

        achievementScroll.verticalNormalizedPosition = 1;
    }

    /// <summary>
    /// Animates the MainSettings panel in
    /// </summary>
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

    /// <summary>
    /// Animates the MainSettings panel out
    /// </summary>
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

    /// <summary>
    /// Animates the MainAchievement panel in
    /// </summary>
    public void AchievementsPanelMainTweenIn()
    {
        settingsButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        achievementButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        achievementsPanel.DOScale(1f, achievementsPanelDuration).SetEase(Ease.InSine);
        achievementsCloseButtonTrans.DOScale(1f, startDuration).SetEase(Ease.InSine);

        isPanelOpen = true;       
    }

    /// <summary>
    /// Animates the MainAchievement panel out
    /// </summary>
    public void AchievementsPanelMainTweenOut()
    {
        settingsButtonTrans.DOScale(0.71721f, startDuration).SetEase(Ease.InSine);
        achievementButtonTrans.DOScale(0.71721f, startDuration).SetEase(Ease.InSine);
        achievementsPanel.DOScale(0f, achievementsPanelDuration).SetEase(Ease.OutSine);
        achievementsCloseButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);

        achievementScroll.verticalNormalizedPosition = 1;

        isPanelOpen = false;
    }

    /// <summary>
    /// Activates the quit depending on the scene
    /// </summary>
    public void QuitPanelMain()
    {
        if (hallway.activeInHierarchy)
        {
            SceneManager.LoadScene("Hub");
        }
        else if (classroom.activeInHierarchy)
        {
            SceneManager.LoadScene("Main");
        }    
    }

    /// <summary>
    /// Animates the Quit panel in
    /// </summary>
    public void QuitPanelTweenIn()
    {
        settingsPanel.transform.DOScale(0f, settingsPanelDuration).SetEase(Ease.OutSine);
        quitPanel.transform.DOScale(1f, settingsPanelDuration).SetEase(Ease.InSine);
    }

    /// <summary>
    /// Animates the Quit panel out
    /// </summary>
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

    /// <summary>
    /// Animates the hubs quit panel in
    /// Fur use of Quit Button for exiting Mobile application
    /// </summary>
    /*public void QuitPanelHubTweenIn()
    {
        settingsButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        achievementButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        editNameButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        playButtonTrans.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        quitHubButton.DOScale(0f, startDuration).SetEase(Ease.OutSine);
        quitHubPanel.DOScale(1f, startDuration).SetEase(Ease.InSine);
    }*/

    /// <summary>
    /// Animates the hubs quit panel out
    /// Fur use of Quit Button for exiting Mobile application
    /// </summary>
    /*public void QuitPanelHubTweenOut()
    {
        settingsButtonTrans.DOScale(0.71721f, endDuration).SetEase(Ease.InSine);
        achievementButtonTrans.DOScale(0.71721f, endDuration).SetEase(Ease.InSine);
        editNameButtonTrans.DOScale(1f, endDuration).SetEase(Ease.InSine);
        playButtonTrans.DOScale(1f, endDuration).SetEase(Ease.InSine);
        quitHubButton.DOScale(1f, endDuration).SetEase(Ease.InSine);
        quitHubPanel.DOScale(0f, endDuration).SetEase(Ease.OutSine);
    }*/

    // For Mobile Release Quit
    /*public void QuitApplication()
    {
        Application.Quit();
    }*/
}