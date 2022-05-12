using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardHander : MonoBehaviour
{
    public Image Image_ShopItem;
    public Text Text_Amount;
    public Text Text_Product;
    public Text Text_Cost;


    private int _amount = 0;
    public int Amount
    {
        get { return _amount; }
        set
        {
            _amount = value;
            _isDirty = true;
        }
    }

    private Sprite _shopItem;
    public Sprite ShopItem
    {
        get { return _shopItem; }
        set
        {
            _shopItem = value;
            _isDirty = true;
        }
    }

    private string _product;
    public string Product
    {
        get { return _product; }
        set
        {
            _product = value;
            _isDirty = true;
        }
    }


    private int _cost = 0;
    public int Cost
    {
        get { return _cost; }
        set
        {
            _cost = value;
            _isDirty = true;
        }
    }

    private bool _isDirty = false;

    void Start()
    {

    }

    void Update()
    {
        if (_isDirty)
        {
            if (_shopItem != null)
            {
                Image_ShopItem.sprite = _shopItem;
            }
            Text_Amount.text = _amount.ToString();
            Text_Product.text = _product;
            Text_Cost.text = _cost.ToString();
            _isDirty = false;
        }
    }
}
