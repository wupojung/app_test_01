
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using UnityEngine;

public class ShopMgr : MonoBehaviour
{
    public CardHander cardHander;
    public SpriteMgr spriteMgr;


    public GameObject prefabSource;
    public GameObject pool;

    // Start is called before the first frame update
    void Start()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(System.String.Format("https://sheets.googleapis.com/v4/spreadsheets/1FZi9sG2o9FGkJvyYo8nuhyCeVGfcRqNwUuSzUMddt0M/values/%E5%B7%A5%E4%BD%9C%E8%A1%A81!A2:D100?key=AIzaSyAqD-STHxwk6_g30gv6k8-A6WsTZ2ig1dE"));
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        Debug.Log(jsonResponse);

        GoogleSheetEntiy source = JsonConvert.DeserializeObject<GoogleSheetEntiy>(jsonResponse);

        List<ItemEntiy> data = ItemEntiy.FromSheetEntiy(source);

        foreach (var item in data)
        {
            GameObject target = Instantiate(prefabSource);
            target.transform.parent = pool.transform;
            //reset
            target.transform.localScale = Vector3.one;

            //fill data
            CardHander _card = target.GetComponent<CardHander>();
            _card.ShopItem = spriteMgr.sprites[(int)Random.Range(0, 6)];
            _card.Amount =(int)item.amount;
            _card.Product = item.name;
            _card.Cost = (int)item.price;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 70, 50, 30), "Click"))
        {
            cardHander.Amount = 888;
            cardHander.Cost = 500;
            cardHander.Product = "很貴的東西";
            cardHander.ShopItem = spriteMgr.sprites[0];
        }
        if (GUI.Button(new Rect(10, 100, 50, 30), "+"))
        {
            GameObject target = Instantiate(prefabSource);
            target.transform.parent = pool.transform;
            //reset
            target.transform.localScale = Vector3.one;

            //fill data
            CardHander _card = target.GetComponent<CardHander>();
            _card.ShopItem = spriteMgr.sprites[(int)Random.Range(0, 6)];
            _card.Amount = (int)Random.Range(100, 999);
            _card.Product = "很貴的東西" + (int)Random.Range(0, 6);
            _card.Cost = (int)Random.Range(10, 9999);
        }
    }
}
