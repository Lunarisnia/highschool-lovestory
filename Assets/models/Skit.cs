using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[CreateAssetMenu(fileName = "New Skit", menuName = "Skit/New")]
public class Skit : ScriptableObject
{
    public string id;
    public string content;

}