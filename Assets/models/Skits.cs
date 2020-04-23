using SimpleJSON;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[Serializable]
public class SkitModel
{
    public int skit_id;
    public string skit;
    public int isDeleted = 0;

}

public class Skits
{

    // public List<SkitModel> skits = new List<SkitModel>();
    public JSONNode readJsonFile()
    {
        string b64 = File.ReadAllText(API.skitPath);
        JSONNode json = JSONNode.LoadFromBinaryBase64(b64);
        return json;
    }
}