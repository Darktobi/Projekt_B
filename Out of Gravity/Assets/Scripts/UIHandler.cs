using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour {

    public Text redKeys;
    public Text blueKeys;
    public Text greenKeys;
    public Text batteryText;
    public Text battery;
    public Text frames;
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
	}
	
	// Update is called once per frame
	void Update () {
        showFramerate();
        showKeys();
        showBattery();
	}

    private void showFramerate()
    {
        frames.text = Mathf.Round(1 / Time.smoothDeltaTime).ToString();
        
    }

    private void showKeys()
    {
        redKeys.text = player.getCurrentKey(Key.KeyColor.Red).ToString();
        blueKeys.text = player.getCurrentKey(Key.KeyColor.Blue).ToString();
        greenKeys.text = player.getCurrentKey(Key.KeyColor.Green).ToString();
    }

    private void showBattery()
    {
        if (player.hasGravityChanger)
        {
            batteryText.enabled = true;
            battery.enabled = true;

            float batteryInPercent = Mathf.Round((gravityChanger.getCurrentBattery() / gravityChanger.maxBattery) * 100);

            if(batteryInPercent <= 10)
            {
                
                if (batteryInPercent <= 0)
                {
                    audioControler.stop();
                    batteryInPercent = 0;
                    
                }
                else
                {
                    audioControler.plaxSFXFull(batteryWarning, 0.5f, 1);
                }
            }
            else
            {
                audioControler.stop();
            }

            battery.text = batteryInPercent.ToString() + " % ";
        }

     
    }
}
