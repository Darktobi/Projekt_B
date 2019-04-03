using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Computer : MonoBehaviour {

    [TextArea(3, 10)]
    public string text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            showText();
        }
    }

    private void showText()
    {
        Debug.Log(text);
    }
}
