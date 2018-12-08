using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
     
    //Screens
    public GameObject MainMenu;
    public GameObject GameScreen; 
    public GameObject GamePauseScreen;
    public GameObject SkillUpgradeScreen;
    public GameObject GameOverScreen;

    //Menus
    public GameObject Options;
    public GameObject AudioMenu;
    public GameObject HowToPlayMenu;
    public GameObject CreditsMenu;


    //Objects
    public GameObject Player;
    Vector3 initialPosition;

    //UI Texts
    public Text KratosHealthPoints;
    public Text KratosRageLevel;
    public Text KratosCurrentLevel;
    public Text KratosXP;
    public Text KratosSkillPoints;
    public Text UpgradeKratosSkillPoints;

    // Use this for initialization
    void Start () {
        MainMenu.SetActive(true);
        GameScreen.SetActive(false);
        GamePauseScreen.SetActive(false);
        SkillUpgradeScreen.SetActive(false);
        GameOverScreen.SetActive(false);
        Options.SetActive(false);
        AudioMenu.SetActive(false);
        HowToPlayMenu.SetActive(false);
        CreditsMenu.SetActive(false);
        Player.SetActive(false);
        initialPosition = Player.transform.position;
        //this.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("MasterVol", 0f);
        //this.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("MenuVol", 0f);
 
    }
	
	// Update is called once per frame
	void Update () {

        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
            && GameScreen.activeInHierarchy)
        {
            Pause();
        }

        KratosHealthPoints.text = "Health: " + Player.GetComponent<KratusControl>().KratosHealthPoints;
        KratosRageLevel.text = "Rage: " + Player.GetComponent<KratusControl>().KratosRageLevel;
        KratosCurrentLevel.text = "Level: " + Player.GetComponent<KratusControl>().KratosCurrentLevel;
        KratosXP.text = "XP: " + Player.GetComponent<KratusControl>().KratosXP;
        KratosSkillPoints.text = "Skill Points: " + Player.GetComponent<KratusControl>().KratosSkillPoints;
        UpgradeKratosSkillPoints.text = "Skill Points: " + Player.GetComponent<KratusControl>().KratosSkillPoints;

        if (Player.GetComponent<KratusControl>().BossDefeated)
            Credits();

        if (Player.GetComponent<KratusControl>().GameOver)
        {
            GameOverScreen.SetActive(true);
            GameScreen.SetActive(false);
            Player.GetComponent<KratusControl>().GameScreenOn = false;
            Player.GetComponent<KratusControl>().GameOver = false;
        }


    }

    public void StartGame()
    {
        //this.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("MasterVol", -80f);
        //this.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("MenuVol", -80f);
        MainMenu.SetActive(false);
        GameScreen.SetActive(true);
        Player.SetActive(true);
        Player.GetComponent<Invector.CharacterController.vThirdPersonController>().enabled = true;
        Player.GetComponent<Invector.CharacterController.vThirdPersonInput>().enabled = true;
        Player.transform.position = initialPosition;

        Player.GetComponent<KratusControl>().GameScreenOn = true;
        Player.GetComponent<KratusControl>().NormalLevel.SetActive(true);

    }

    public void Pause()
    {
        //this.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("MasterVol", 0f);
        //this.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("MenuVol", 0f);
        GameScreen.SetActive(false);
        GamePauseScreen.SetActive(true);
        Player.GetComponent<Invector.CharacterController.vThirdPersonController>().enabled = false;
        Player.GetComponent<Invector.CharacterController.vThirdPersonInput>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        Player.GetComponent<KratusControl>().GameScreenOn = false;
    }

    public void Resume()
    {
        //this.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("MasterVol", -80f);
        //this.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("MenuVol", -80f);
        GameScreen.SetActive(true);
        GamePauseScreen.SetActive(false);
        Player.GetComponent<Invector.CharacterController.vThirdPersonController>().enabled = true;
        Player.GetComponent<Invector.CharacterController.vThirdPersonInput>().enabled = true;
        Player.GetComponent<KratusControl>().GameScreenOn = true;

    }

    public void RestartLevel()
    {
        if (Player.GetComponent<KratusControl>().NormalLevel.activeInHierarchy)
        {

            Player.GetComponent<KratusControl>().NormalLevel.GetComponent<NormalLevel>().Start();
            Player.GetComponent<Animator>().avatar = Player.GetComponent<KratusControl>().DefaultAvatar;
        }
        else if (Player.GetComponent<KratusControl>().BossLevel.activeInHierarchy)
        {
           
            Player.GetComponent<KratusControl>().BossLevel.GetComponentInChildren<BossLevel>().Start();
            Player.GetComponent<Animator>().avatar = Player.GetComponent<KratusControl>().DefaultAvatar;
        }
        GameOverScreen.SetActive(false);
        GamePauseScreen.SetActive(false);
        GameScreen.SetActive(true);
        Player.GetComponent<KratusControl>().GameScreenOn = true;
        Player.GetComponent<KratusControl>().GameOver = false;
    }

    public void OptionsMenu()
    {
        MainMenu.SetActive(false);
        Options.SetActive(true);
    }

    public void Audio() 
    {
        MainMenu.SetActive(false);
        Options.SetActive(false);
        AudioMenu.SetActive(true);
    }

    public void HowToPlay()
    {
        MainMenu.SetActive(false);
        Options.SetActive(false);
        HowToPlayMenu.SetActive(true);
    }

    public void Credits()
    {
        MainMenu.SetActive(false);
        GameScreen.SetActive(false);
        Options.SetActive(false);
        CreditsMenu.SetActive(true);
    }

    public void BackToOptionsMenu()
    {
        Options.SetActive(true);
        AudioMenu.SetActive(false);
        HowToPlayMenu.SetActive(false);
        CreditsMenu.SetActive(false);
    }

    public void BackToPauseMenu()
    {
        GamePauseScreen.SetActive(true);
        SkillUpgradeScreen.SetActive(false);
    }

    public void BackToMainMenu()
    {
        MainMenu.SetActive(true);
        Options.SetActive(false);
        AudioMenu.SetActive(false);
        HowToPlayMenu.SetActive(false);
        CreditsMenu.SetActive(false);
    }

    public void Upgrade()
    {
        GamePauseScreen.SetActive(false);
        SkillUpgradeScreen.SetActive(true);
    }


    public void QuitToMainMenu()
    {
        MainMenu.SetActive(true);
        GameScreen.SetActive(false);
        GamePauseScreen.SetActive(false);
        SkillUpgradeScreen.SetActive(false);
        GameOverScreen.SetActive(false);
        Options.SetActive(false);
        AudioMenu.SetActive(false);
        HowToPlayMenu.SetActive(false);
        CreditsMenu.SetActive(false);
    }

    public void QuitApp()
    {
                // save any game data here
        #if UNITY_EDITOR
                // Application.Quit() does not work in the editor so
                // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                 Application.Quit();
        #endif
    }

}
