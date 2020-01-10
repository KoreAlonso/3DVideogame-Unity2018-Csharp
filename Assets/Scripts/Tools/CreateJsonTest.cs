using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class CreateJsonTest : MonoBehaviour
{
    static string recordPath;
    public static Record record;
    static string recordToJson;
    void Start()
    {
        recordPath = "/Assets/recordJson.json";
        record = new Record();

        Debug.Log(Directory.GetCurrentDirectory() + @recordPath);

        if (File.Exists(Directory.GetCurrentDirectory() + @recordPath))
        {
            Debug.Log("Ya existe json");
            readTxt();
        }
        else
        {
            try
            {
                File.CreateText(Directory.GetCurrentDirectory() + @recordPath).Close();
                record.recordEasyMode = 10000;
                record.recordNormalMode = 10000;
                record.recordHardMode = 1000;
                writeTxt();
                Debug.Log("Exito al crear json");
            }
            catch
            {
                Debug.Log("Fallo al crear json");
            }
        }
       
       
    }

    public static void writeTxt()
    {
      
       
        recordToJson = JsonUtility.ToJson(record, true);
        try
        {
            File.WriteAllText(Directory.GetCurrentDirectory() + recordPath, recordToJson);
            Debug.Log("Escrito json con exito");
            Debug.Log(File.ReadAllText(Directory.GetCurrentDirectory() + recordPath));
        }
        catch
        {
            Debug.Log("Fallo al escribir json");
        }
    }

    void readTxt()
    {
        record = JsonUtility.FromJson<Record>(File.ReadAllText(Directory.GetCurrentDirectory() + recordPath));
    }
}
