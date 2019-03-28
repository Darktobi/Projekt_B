using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChanger : MonoBehaviour {

    public float maxChangeTimer = 0.2f;
    public float maxBattery = 3f;
    public float maxBatteryLoadTimer = 2f;

    private float changeTimer;
    private float battery;
    private float batteryLoadTimer;
    private bool hasGravity;
    private bool gravityIsChanging;
    private float gravityScale = 9.8f;

	// Use this for initialization
	void Start () {
        Physics2D.gravity = new Vector2(0, -gravityScale);
        changeTimer = maxChangeTimer;
        battery = maxBattery;
        batteryLoadTimer = maxBatteryLoadTimer;
        hasGravity = true;
        gravityIsChanging = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (gravityIsChanging)
        {
            changeGravityOverTime();
        }

        if (!hasGravity)
        {
            battery -= Time.deltaTime;
            
            if(battery <= 0)
            {
                gravityOn();
            }
        }

        else if (battery < maxBattery)
        {
            LoadBattery();
        }  
	}

    public void gravityOff()
    {
        if (hasGravity)
        {
            Physics2D.gravity = new Vector2(0, 0);
            hasGravity = false;
            gravityIsChanging = true;
        }
    }

    public void gravityOn()
    {
        if (!hasGravity)
        {
            Physics2D.gravity = new Vector2(0, -gravityScale);
            hasGravity = true;
            gravityIsChanging = true;
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

    private void changeGravityOverTime()
    {
        changeTimer -= Time.deltaTime;

        if (changeTimer <= 0)
        {
            if (!hasGravity)
            {
               
                gravityScale -= 4;
            }
            else
            {
                gravityScale += 4;
            }

            changeTimer = maxChangeTimer;
        }

        if (gravityScale < 0)
        {
            gravityScale = 0;
            gravityIsChanging = false;
        }
        else if (gravityScale > 9.8f)
        {
            gravityIsChanging = false;
            gravityScale = 9.8f;
        }

        Physics2D.gravity = new Vector2(0, -gravityScale);
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
}
