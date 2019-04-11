using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChanger : MonoBehaviour {

    public float maxChangeTimer = 0.2f;
    public float maxBattery = 5f;
    public float maxBatteryReduce = 5;
    public float maxBatteryLoadTimer = 2f;
    public AudioClip[] audioClip = new AudioClip[2];
    public GameObject gravityArea;

    private float battery;
    private float batteryLoadTimer;
    private float batteryReduce;
    private bool isOn;
    private bool isMoving;
    private bool hasGravityArea;

    private AudioControler audioControler;

	// Use this for initialization
	void Start () {
        battery = maxBattery;
        batteryLoadTimer = maxBatteryLoadTimer;
        isOn = false;
        isMoving = false;
        audioControler = GetComponent<AudioControler>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (isMoving)
        {
            batteryReduce = 1;
        }
        else
        {
            batteryReduce = maxBatteryReduce;
        }

        if (isOn)
        {
            setGravityArea();
            batteryLoadTimer = maxBatteryLoadTimer;
            battery -= Time.deltaTime/ batteryReduce;
            
            if(battery <= 0)
            {
                turnOff();
            }
        }

        else if (battery < maxBattery)
        {
            destroyGravityArea();
            LoadBattery();
        }  
	}

    public void turnOn()
    {
        if (!isOn)
        {
            isOn = true;
            audioControler.playSFX(audioClip[0], 0.8f, 1.5f);
        }
    }

    public void turnOff()
    {
        if (isOn)
        {
            isOn = false;
            audioControler.playSFX(audioClip[1], 0.8f, 1.5f);
        }
    }

    public bool batteryIsEmpty()
    {
        if (battery <= 0)
        {
            return true;
        }
        return false;
    }

    public float getCurrentBattery()
    {
        return battery;
    }

    public void Moving(bool isMoving)
    {
        this.isMoving = isMoving;
    }

    private void LoadBattery()
    {
        batteryLoadTimer -= Time.deltaTime;

        if(batteryLoadTimer <= 0)
        {
            battery = maxBattery;
            batteryLoadTimer = maxBatteryLoadTimer;
        }
    }

    private void setGravityArea()
    {
        if (!hasGravityArea)
        {
            Instantiate(gravityArea);
            hasGravityArea = true;
        }
    }

    private void destroyGravityArea()
    {
        Destroy(GameObject.FindGameObjectWithTag("GravityArea"));
        hasGravityArea = false;
    }
}
