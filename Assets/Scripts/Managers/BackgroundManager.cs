using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public Sprite MainMenuSprite;
    public Sprite NormalModeSprite; 
    public Sprite RageModeSprite;
    public Sprite GoodFlash;
    public Sprite BadFlash;

    public SpriteRenderer BackgroundRenderer;
    public SpriteRenderer FlashRenderer;

    void Update()
    {
        if (isGoodFlash || isBadFlash)
        {
            currFlashTime += Time.deltaTime;
            if (currFlashTime >= maxFlashTime)
            {
                currFlashTime = 0.0f;
                isGoodFlash = false;
                isBadFlash = false;
                FlashRenderer.sprite = null;
            }
        }
    }

    public void GoNormalBackground()
    {
        BackgroundRenderer.sprite = NormalModeSprite;
    }

    public void GoRageBackground()
    {
        BackgroundRenderer.sprite = RageModeSprite;
    }

    public void GoMainMenuBackground()
    {
        BackgroundRenderer.sprite = MainMenuSprite;
    }

    public void GoGoodFlash()
    {
        isGoodFlash = true;
        FlashRenderer.sprite = GoodFlash;
        currFlashTime = 0.0f;
    }

    public void GoBadFlash()
    {
        isBadFlash = true;
        FlashRenderer.sprite = BadFlash;
        currFlashTime = 0.0f;
    }

    private float maxFlashTime = 0.1f;
    private float currFlashTime = 0.2f;
    private bool isGoodFlash = false;
    private bool isBadFlash = false;
}
