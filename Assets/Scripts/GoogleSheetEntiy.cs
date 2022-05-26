using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoogleSheetEntiy
{
    public string range { get; set; }
    public string majorDimension { get; set; }
    public List<List<string>> values { get; set; }
}
