using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public GameObject ShopScrollBarContent;
    public GameObject ShopItemPrefab;
    public TextMeshProUGUI CoinsText;

    public SoundManager SoundManager { get; set; } //знаю, что это плохо, но так быстрей, чем переделывать на синглтон
    public List<GameObject> ShopItems { get; set; } = new List<GameObject>();
    public ShopModel Model { get; set; }
    public int Coins { get { return coins; } set { coins = value; CoinsText.text = coins.ToString(); } }
    private int coins;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetShopModel(ShopModel shopModel, int coins)
    {
        Model = shopModel;
        Coins = coins;
        foreach (var item in ShopItems)
        {
            item.GetComponent<ShopItemScript>().BuyNotify -= ShopManager_BuyNotify;
            Destroy(item);
        }
        ShopItems.Clear();
        foreach (var shopItem in shopModel.ShopItems)
        {
            var shopItemObject = Instantiate(ShopItemPrefab);
            shopItemObject.GetComponent<ShopItemScript>().SetModel(shopItem);
            shopItemObject.GetComponent<ShopItemScript>().CheckIfAvailable(Coins);
            shopItemObject.GetComponent<ShopItemScript>().BuyNotify += ShopManager_BuyNotify;
            shopItemObject.transform.SetParent(ShopScrollBarContent.transform, false);
            ShopItems.Add(shopItemObject);
        }
    }

    private void ShopManager_BuyNotify(string shopItemName)
    {
        SoundManager.PlayCircleBlow();
        Coins = Model.BuyItem(shopItemName, Coins);
        CheckAvailableShopItems();
    }

    private void CheckAvailableShopItems()
    {
        foreach (var item in ShopItems)
        {
            item.GetComponent<ShopItemScript>().CheckIfAvailable(Coins);
        }
    }
}
