using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using UnityEngine;

public class S1Mgr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("https://sheets.googleapis.com/v4/spreadsheets/1FZi9sG2o9FGkJvyYo8nuhyCeVGfcRqNwUuSzUMddt0M/values/%E5%B7%A5%E4%BD%9C%E8%A1%A81!A2:D100?key=AIzaSyAqD-STHxwk6_g30gv6k8-A6WsTZ2ig1dE"));
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        Debug.Log(jsonResponse);

        GoogleSheetEntiy source = JsonConvert.DeserializeObject<GoogleSheetEntiy>(jsonResponse);

        List<ItemEntiy> data = ItemEntiy.FromSheetEntiy(source);

        Debug.Log("data count:" + data.Count);
        foreach (var item in data)
        {
            Debug.Log(String.Format("[{0}] {1} : {2} x ${3}", item.id, item.name, item.amount, item.price));
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
