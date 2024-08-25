using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public Sprite spriteOn;
    public Sprite spriteOff;

    public Sprite imageResumeButton;
    public Sprite imageStartButton;
    public Image imageButtonStart;
    public RectTransform transformButtonStart;
    public Image ImageButtonMusic;
    public Image ImageButtonSound;

    [SerializeField] private bool statSounds = true;
    [SerializeField] private bool statMusic = true;

    public GameObject panelOption;
    private void Start()
    {
        LoadOptions();
        panelOption.SetActive(false);
        UpdateLevel();
    }

    private void UpdateLevel() {
        if (PlayerPrefs.GetInt("currentLevel") >= 2) {
            imageButtonStart.sprite = imageResumeButton;
            transformButtonStart.sizeDelta = new Vector2(478.37f, transformButtonStart.sizeDelta.y);
        } 
        else {
            imageButtonStart.sprite = imageStartButton;
            transformButtonStart.sizeDelta = new Vector2(392.82f, transformButtonStart.sizeDelta.y);
        }
    }
    public void ResetStage() {
        PlayerPrefs.SetInt("currentLevel", 1);
        UpdateLevel();
    }
    public void ButtonQuit() {
        SavingOptions();
        Application.Quit();
        Debug.Log("Application Quited");
    }

    private void SavingOptions() {
        if (ImageButtonSound.sprite == spriteOn) {
            PlayerPrefs.SetInt("Sounds", 1);
        }
        else {
            PlayerPrefs.SetInt("Sounds", 0);
        }

        if (ImageButtonMusic.sprite == spriteOn) {
            PlayerPrefs.SetInt("Musics", 1);
        }
        else {
            PlayerPrefs.SetInt("Musics", 0);
        }
    }

    private void LoadOptions() {
        if (PlayerPrefs.GetInt("Sounds") == 0) {
            ImageButtonSound.sprite = spriteOff;
        }
        else {
            ImageButtonSound.sprite = spriteOn;
        }

        if (PlayerPrefs.GetInt("Musics") == 0) {
            ImageButtonMusic.sprite = spriteOff;
        }
        else {
            ImageButtonMusic.sprite = spriteOn;
        }
    }
    private void OnApplicationQuit()
    {
        SavingOptions();
    }
    public void ButtonOption() {
        panelOption.SetActive(true);
    }

    public void ButtonCloseOption() {
        panelOption.SetActive(false);
    }

    public void SetSound() {
        statSounds = !statSounds;
        if (statSounds) {
            ImageButtonSound.sprite = spriteOn;
        }
        else {
            ImageButtonSound.sprite = spriteOff;
        }
    }
    public void SetMusic() {
    statMusic = !statMusic;
    if (statMusic) {
        ImageButtonMusic.sprite = spriteOn;
    }
    else {
        ImageButtonMusic.sprite = spriteOff;
    }
    }
}
