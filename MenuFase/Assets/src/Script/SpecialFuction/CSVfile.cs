using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class CSVfile : MonoBehaviour
{
  public List<string> ReadCSVFile(string path)
  {
    List<string> textFile = new List<string>();

    TextAsset textAsset = (TextAsset)Resources.Load(path);
    string txtFile = textAsset.text;

    try
    {
      textFile = txtFile.Split('\n').Where(s => s.Length > 0).ToList();
    }
    catch (System.Exception)
    {

      textFile.Add("");
    }
    
    return textFile;

  }
}
