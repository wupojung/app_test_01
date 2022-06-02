using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEntiy
{
    public int id;
    public int spriteIndex;
    public string name;
    public float amount;
    public float price;

    public static List<ItemEntiy> FromSheetEntiy(GoogleSheetEntiy source)
    {
        List<ItemEntiy> result = new List<ItemEntiy>();
        try
        {
            foreach (var value in source.values)
            {
                ItemEntiy temp = new ItemEntiy();
                temp.id = int.Parse(value[0]);
                temp.spriteIndex = int.Parse(value[1]);
                temp.name = value[2];
                temp.amount = float.Parse(value[3]);
                temp.price = float.Parse(value[4]);

                result.Add(temp);
            }
        }
        catch (System.Exception exp)
        {
            Debug.LogError(exp.ToString());
            throw;
        }
        return result;
    }

}
