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

    //Sound
    public Sound SoundManager;

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
        this.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("MenuVol", SoundManager.MusicVolume);
 
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
            Player.GetComponent<KratusControl>().NormalLevel.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("NormalLevelVol", -80f); //Normal Level
            Player.GetComponent<KratusControl>().BossLevel.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("BossLevelVol", -80f); //Boss Level

            this.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("MenuVol", SoundManager.MusicVolume);
        }

        if(AudioMenu.activeInHierarchy)
            this.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("MenuVol", SoundManager.MusicVolume);

    }

    public void StartGame()
    {
        this.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("MenuVol", -80f); //Menu
        MainMenu.SetActive(false);
        GameScreen.SetActive(true);
        Player.SetActive(true);
        Player.GetComponent<Invector.CharacterController.vThirdPersonController>().enabled = true;
        Player.GetComponent<Invector.CharacterController.vThirdPersonInput>().enabled = true;
        Player.transform.position = initialPosition;

        Player.GetComponent<KratusControl>().GameScreenOn = true;
        Player.GetComponent<KratusControl>().NormalLevel.SetActive(true);
        Player.GetComponent<KratusControl>().BossLevel.SetActive(false);
        Player.GetComponent<KratusControl>().NormalLevel.GetComponent<NormalLevel>().Start();
        Player.GetComponent<Animator>().avatar = Player.GetComponent<KratusControl>().DefaultAvatar;
    }

    public void Pause()
    {
        Player.GetComponent<KratusControl>().NormalLevel.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("NormalLevelVol", -80f); //Normal Level
        Player.GetComponent<KratusControl>().BossLevel.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("BossLevelVol", -80f); //Boss Level

        this.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("MenuVol", SoundManager.MusicVolume);
        GameScreen.SetActive(false);
        GamePauseScreen.SetActive(true);
   
        Player.GetComponent<Invector.CharacterController.vThirdPersonController>().enabled = false;
        Player.GetComponent<Invector.CharacterController.vThirdPersonInput>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        Player.GetComponent<KratusControl>().GameScreenOn = false;

        Player.SetActive(false);
    }

    public void Resume()
    {
        Player.SetActive(true);
        this.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("MenuVol", -80f);
        GameScreen.SetActive(true);
        GamePauseScreen.SetActive(false);
        Player.GetComponent<Invector.CharacterController.vThirdPersonController>().enabled = true;
        Player.GetComponent<Invector.CharacterController.vThirdPersonInput>().enabled = true;
        Player.GetComponent<KratusControl>().GameScreenOn = true;

        if (Player.GetComponent<KratusControl>().NormalLevel.activeInHierarchy)
        {
            Player.GetComponent<KratusControl>().NormalLevel.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("NormalLevelVol", SoundManager.MusicVolume); //Normal Level
        }
        else if (Player.GetComponent<KratusControl>().BossLevel.activeInHierarchy)
        {
            Player.GetComponent<KratusControl>().BossLevel.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("BossLevelVol", SoundManager.MusicVolume); //Boss Level
        }

    }

    public void RestartLevel()
    {
        Player.SetActive(true);
        Player.GetComponent<Invector.CharacterController.vThirdPersonController>().enabled = true;
        Player.GetComponent<Invector.CharacterController.vThirdPersonInput>().enabled = true;
        this.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("MenuVol", -80f);

        Player.GetComponent<KratusControl>().Start();
        if (Player.GetComponent<KratusControl>().NormalLevel.GetComponent<NormalLevel>().NormalLevelON)
        {
            Player.GetComponent<KratusControl>().NormalLevel.GetComponent<NormalLevel>().Start();
            Player.GetComponent<Animator>().avatar = Player.GetComponent<KratusControl>().DefaultAvatar;
            Player.GetComponent<KratusControl>().NormalLevel.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("NormalLevelVol", SoundManager.MusicVolume); //Normal Level

        }
        else // Boss Level
        {
           
            Player.GetComponent<KratusControl>().BossLevel.GetComponentInChildren<BossLevel>().Start();
            Player.GetComponent<Animator>().avatar = Player.GetComponent<KratusControl>().DefaultAvatar;
            Player.GetComponent<KratusControl>().BossLevel.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("BossLevelVol", SoundManager.MusicVolume); //Boss Level

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
