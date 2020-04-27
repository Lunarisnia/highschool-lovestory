using UnityEngine;

[CreateAssetMenu(fileName = "New Dialog", menuName="Dialog/New")]
// [System.Serializable]
public class Dialogue : ScriptableObject
{
    public string speakerName;

    [TextArea(3, 10)]
    public string[] sentences;
    public Sprite[] portraits;
}
