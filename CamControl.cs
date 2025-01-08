using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{

    public Camera mmCam;
    public Camera playerCam;
    public Movement movement;
    public Button button;
    public RawImage image;
    public TextMeshProUGUI text;
    public TextMeshProUGUI scoreText;
    public BulletCollide bulletScript;
    public ScoreCounter scoreScript;
    public Shooting shootScript;
    public bool notPlayed = true;

    public AudioClip clip;
    public AudioClip winClip;
    private AudioSource source;
    private AudioSource source2;

    void Start()
    {
        button.onClick.AddListener(OnButtonClick);
        AudioSource[] sources = GetComponents<AudioSource>();
        source = sources[0];
        source2 = sources[1];
        movement.isRunning = false;
        scoreText.enabled = false;
    }

    public void Update()
    {
        if (movement.trans)
        {
            mmCam.enabled = false;
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if(!source.isPlaying && !image.enabled)
        {
            mmCam.enabled = true;
            playerCam.enabled = false;

            if (scoreScript.score == 164)
            {
                scoreText.enabled = true;
                scoreText.text = "YOU PAINTED THE WORLD!!! SCORE: 164/164";

                if (notPlayed)
                {
                    source2.PlayOneShot(winClip);
                    notPlayed = false;
                }
            }
            if(scoreScript.score != 164)
            {
                scoreText.text = "SCORE:\n" + scoreScript.score + "/164\nPress R to Retry";
                scoreText.enabled = true;
            }
        }

    }

    void OnButtonClick()
    {
        movement.isRunning = true;
        source.PlayOneShot(clip);
        button.enabled = false;
        image.enabled = false;
        text.enabled = false;
        button.gameObject.SetActive(false);
        shootScript.hardMode.gameObject.SetActive(false);
    }
}
