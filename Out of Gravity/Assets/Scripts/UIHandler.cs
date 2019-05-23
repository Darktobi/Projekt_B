using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour {

    public Image redKey;
    public Image blueKey;
    public Image greenKey;
    public Text batteryText;
    public Text battery;
    public Text frames;
    public Image useInfo;
    public AudioClip batteryWarning;

    private Player player;
    private GravityChanger gravityChanger;
    private AudioControler audioControler;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gravityChanger = GameObject.Find("GravityChanger").GetComponent<GravityChanger>();
        audioControler = GetComponent<AudioControler>();
        batteryText.enabled = false;
        battery.enabled = false;
        useInfo.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        showFramerate();
        showBattery();
	}

    public void showUseInfo()
    {
        useInfo.gameObject.SetActive(true);
    }

    public void disableUseInfo()
    {
        useInfo.gameObject.SetActive(false);
    }

    public void showKeys(Key.KeyColor color)
    {
        if (color == Key.KeyColor.Red)
        {
            redKey.gameObject.SetActive(true);
        }

        if (color == Key.KeyColor.Blue)
        {
            blueKey.gameObject.SetActive(true);
        }

        if (color == Key.KeyColor.Green)
        {
            greenKey.gameObject.SetActive(true);
        }
    }

    private void showFramerate()
    {
        frames.text = Mathf.Round(1 / Time.smoothDeltaTime).ToString();
    }

    private void showBattery()
    {
        if (player.hasGravityChanger)
        {
            batteryText.enabled = true;
            battery.enabled = true;

            float batteryInPercent = Mathf.Round((gravityChanger.getCurrentBattery() / gravityChanger.maxBattery) * 100);

            if(batteryInPercent <= 15)
            {
                if (gravityChanger.isBatteryLoading())
                {
                    audioControler.stopSFX();   
                }
                else
                {
                    if (!audioControler.SFXisPlaying())
                    {
                        audioControler.playSFX(batteryWarning, 0.5f, 1);
                    }
                }
            }
            else
            {
                audioControler.stopSFX();
            }

            battery.text = batteryInPercent.ToString() + " % ";
        }
    }
}
