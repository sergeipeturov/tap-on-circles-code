using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemScript : MonoBehaviour
{
    public delegate void Buy(string shopItemName);
    public event Buy BuyNotify;

    public TextMeshProUGUI Description;
    public TextMeshProUGUI Cost;
    public Image BuyButton;
    public Image[] SILevels;
    public GameObject CostObject;

    public Sprite SILevelGreen;
    public Sprite SILevelGrey;
    public Sprite BuyButtonGreen;
    public Sprite BuyButtonRed;
    public Sprite BuyButtonGrey;

    public ShopItemModel Model { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetModel(ShopItemModel shopItemModel)
    {
        Model = shopItemModel;
        Description.text = LocalizationManager.GetStringByKey(shopItemModel.DescriptionKey);
        Cost.text = shopItemModel.CurrentCost.ToString();
        for (int i = 0; i < 5; i++)
        {
            SILevels[i].sprite = SILevelGrey;
        }
        for (int i = 0; i < shopItemModel.CurrentLevel; i++)
        {
            SILevels[i].sprite = SILevelGreen;
        }
    }

    public void CheckIfAvailable(int coins)
    {
        if (Model.CurrentLevel == 5)
        {
            BuyButton.sprite = BuyButtonGrey;
            BuyButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            if (coins - Model.CurrentCost >= 0)
            {
                BuyButton.sprite = BuyButtonGreen;
                BuyButton.GetComponent<Button>().interactable = true;
            }
            else
            {
                BuyButton.sprite = BuyButtonRed;
                BuyButton.GetComponent<Button>().interactable = false;
            }
        }
    }

    public void OnBuyClick()
    {
        BuyNotify?.Invoke(Model.Name);
        SetModel(Model);
    }
}
