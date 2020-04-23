using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;

public class JSONManager : MonoBehaviour
{
    public List<SkitModel> newSkit;
    public SkitModel skitChanges;

    [ContextMenu("Add-Skit-Entry")]
    public void addSkitEntry()
    {
        if (newSkit.Count < 1)
        {
            Debug.Log("Please enter the required data beforehand.");
        }
        else
        {
            var json = new Skits().readJsonFile();
            newSkit.ForEach(delegate (SkitModel model)
            {
                json[json.Count].Add("skit_id", json.Count);
                json[json.Count - 1]["skit"] = model.skit;
                json[json.Count - 1]["isDeleted"] = model.isDeleted;

            });
            string binary = json.SaveToBinaryBase64();
            Debug.Log(json);
            File.WriteAllText(API.skitPath, binary);
        }
    }

    [ContextMenu("Load-Skit")]
    public void loadAllSkit()
    {
        var json = new Skits().readJsonFile();
        Debug.Log(json);
    }

    [ContextMenu("Reset-Skit")]
    public void resetSkit()
    {
        string initSkit = "[{\"skit_id\":0,\"skit\":\"\"RAWRRAAAAW MEEEEEW AAAAAAAAA RWWEEEE\" - Momohana\",\"isDeleted\":0}]";
        JSONNode json = JSON.Parse(initSkit);
        string binary = json.SaveToBinaryBase64();

        File.WriteAllText(API.skitPath, binary);
        Debug.Log(json);
    }

    [ContextMenu("Update-Skit")]
    public void updateSkitEntry()
    {
        var json = new Skits().readJsonFile();
        if (json[skitChanges.skit_id]["isDeleted"] != null)
        {
            json[skitChanges.skit_id]["skit"] = skitChanges.skit;
            json[skitChanges.skit_id]["isDeleted"] = skitChanges.isDeleted;
            string binary = json.SaveToBinaryBase64();
            File.WriteAllText(API.skitPath, binary);

            Debug.Log(json);
        }
        else
        {
            Debug.Log("Skit not found.");
        }
    }
}

