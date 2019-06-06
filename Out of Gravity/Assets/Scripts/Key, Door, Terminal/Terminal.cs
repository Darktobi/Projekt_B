using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Terminal : MonoBehaviour {

    [SerializeField]
    protected Door door;
    [SerializeField]
    protected Sprite openSprite;
    [SerializeField]
    protected Sprite closedSprite;
    protected AudioControler audioControler;
    protected SpriteRenderer spriteRend;
    protected bool canUse;




	// Use this for initialization
	protected virtual void Start () {
        audioControler = GameObject.Find("SFX_Controler").GetComponent<AudioControler>();
        spriteRend = GetComponent<SpriteRenderer>();
        canUse = false;
    }

    protected void changeSprite()
    {
        if (door.isOpen)
        {
            spriteRend.sprite = openSprite;
        }
        else
        {
            spriteRend.sprite = closedSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canUse= true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canUse = false;
            FindObjectOfType<UIHandler>().disableUseInfo();
        }
    }
}
