using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;   

    [SerializeField] int timesHit = 0;  //TODO serialized only for Debugg purpose.

    Level level;

    public void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "1 Hit Breakable")
        {
            level.CountBlocks();
        }
        if (tag == "2 Hit Breakable")
        {
            level.CountBlocks();
        }
        if (tag == "3 Hit Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "1 Hit Breakable")
        {
            HandleHit();
        }
        if (tag == "2 Hit Breakable")
        {
            HandleHit();
        }
        if (tag == "3 Hit Breakable")
        {
            HandleHit();
        }
    }
     
    private void HandleHit()
    {
        timesHit++;
        FindObjectOfType<GameStatus>().IncreaseScore();
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
            DestroyBlock();
        else
            ShowNextHitSprite();
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        else
            Debug.LogError("Sprite is missing in the array" + gameObject.name);
    }

    private void DestroyBlock()
    {
        FindObjectOfType<GameStatus>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerSparklesVFX();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
    
}
