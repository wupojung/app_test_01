
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
    public GameObject pool; //target  

    public GameObject itemPool;

    // Start is called before the first frame update
    void Start()
    {
        //
        InstantiateObjectToItemPool();

        List<ItemEntiy> data = GetDataFromGoogleSheet();

        foreach (var item in data)
        {
            GameObject target = GetGameObjectFromItemPool(item);

            target.transform.parent = pool.transform;
            //reset
            target.transform.localScale = Vector3.one;
        }
    }

    private GameObject GetGameObjectFromItemPool(ItemEntiy item)
    {
        GameObject result = null;
        try
        {
            result = itemPool.transform.GetChild(0).gameObject;
            //fill data
            CardHander _card = result.GetComponent<CardHander>();
            _card.ShopItem = spriteMgr.sprites[item.spriteIndex];
            _card.Amount = (int)item.amount;
            _card.Product = item.name;
            _card.Cost = (int)item.price;
        }
        catch (System.Exception exp)
        {
            Debug.LogError(exp.ToString());
            throw;
        }
        return result;
    }

    private void InstantiateObjectToItemPool()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject target = Instantiate(prefabSource);
            target.transform.parent = itemPool.transform;
        }

    }

    private List<ItemEntiy> GetDataFromGoogleSheet()
    {
        List<ItemEntiy> result = new List<ItemEntiy>();
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(System.String.Format("https://sheets.googleapis.com/v4/spreadsheets/1FZi9sG2o9FGkJvyYo8nuhyCeVGfcRqNwUuSzUMddt0M/values/%E5%B7%A5%E4%BD%9C%E8%A1%A81!A2:E100?key=AIzaSyAqD-STHxwk6_g30gv6k8-A6WsTZ2ig1dE"));
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string jsonResponse = reader.ReadToEnd();
            Debug.Log(jsonResponse);

            GoogleSheetEntiy source = JsonConvert.DeserializeObject<GoogleSheetEntiy>(jsonResponse);

            result = ItemEntiy.FromSheetEntiy(source);
        }
        catch (System.Exception exp)
        {
            Debug.LogError(exp.ToString());
            throw;
        }
        return result;
    }


    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 100, 50, 30), "-"))
        {
            // item 1  --> item pool 
            pool.transform.GetChild(0).parent = itemPool.transform;

        }
    }
}
