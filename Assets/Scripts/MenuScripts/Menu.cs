using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadMain() 
    {
        SceneManager.LoadScene("LevelScene");
    }
    public void LoadHowToPlay()
    {
        SceneManager.LoadScene("TutorialScene");
    }
    public void LoadLeaderboard()
    {
        SceneManager.LoadScene("LeaderboardScene");
    }
    public void LoadAchievements() 
    {
        SceneManager.LoadScene("AchievementsScene");
    }
    public void LoadUnlockables() 
    {
        SceneManager.LoadScene("StoryScene");
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene("CreditsScene");
    }
    public void LoadSettings() 
    {
        SceneManager.LoadScene("SettingsScene");
    }
}
