using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour {

    public Image redKey;
    public Image blueKey;
    public Image greenKey;
    public Image battery;
    public GameObject batteryPanel;
    public Text frames;
    public GameObject useInfo;
    public AudioClip batteryWarning;

    private Player player;
    private GravityChanger gravityChanger;
    private AudioControler audioControler;

    private bool hideBattery;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gravityChanger = GameObject.Find("GravityChanger").GetComponent<GravityChanger>();
        audioControler = GetComponent<AudioControler>();
        batteryPanel.SetActive(false);
        useInfo.gameObject.SetActive(false);
        hideBattery = false;
    }
	
	// Update is called once per frame
	void Update () {
        showFramerate();
        showBattery();

        //batteryTest.fillAmount -= 1.0f / 30 * Time.deltaTime;
	}

    public void showUseInfo()
    {
        useInfo.gameObject.SetActive(true);
        hideBattery = true;
    }

    public void disableUseInfo()
    {
        useInfo.gameObject.SetActive(false);
        hideBattery = false;
    }

    public void flipPlayerUI()
    {
        useInfo.transform.localPosition = new Vector2(useInfo.transform.localPosition.x * -1, useInfo.transform.localPosition.y);
        batteryPanel.transform.localPosition = new Vector2(batteryPanel.transform.localPosition.x * -1, batteryPanel.transform.localPosition.y);
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

            float batteryInPercent = Mathf.Round((gravityChanger.getCurrentBattery() / gravityChanger.maxBattery) * 100);

            if(batteryInPercent < 100 && !hideBattery)
            {
                batteryPanel.SetActive(true);
                changeBatteryColor(batteryInPercent);
            }
            else
            {
                batteryPanel.SetActive(false);
            }

            battery.fillAmount = batteryInPercent/100;

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

        }
    }

    private void changeBatteryColor(float batteryLoad)
    {
        if(batteryLoad > 60)
        {
            battery.color = Color.green;
        }
        else if(batteryLoad > 30)
        {
            battery.color = Color.yellow;
        }
        else
        {
            battery.color = Color.red;
        }
    }
}
