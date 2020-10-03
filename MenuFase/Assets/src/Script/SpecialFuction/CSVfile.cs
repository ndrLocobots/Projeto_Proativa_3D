using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; 

public class CSVfile : MonoBehaviour
{
  public List<string> ReadCSVFile(string path)
  {
    List<string> textFile = new List<string>();
    StreamReader streamReader = new StreamReader(path);

    using (streamReader)
    {
      while (true)
      {

        string data = streamReader.ReadLine();

        if (data == null)
        {
          break;
        }

        data = data.Replace("\"", "");
        textFile.Add(data);
      }
    }

    return textFile;

  }
}
