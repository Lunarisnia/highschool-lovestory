using UnityEngine;
using UnityEngine.UI;
using System.Data;
using System.Collections.Generic;
public class select_random_skit : MonoBehaviour
{
    private Text text;
    private void Awake()
    {
        text = GetComponent<Text>();
        selectRandomSkit();
    }

    void selectRandomSkit()
    {
        int index;
        List<string> skits = new List<string>();
        IDataReader reader = new skit_service().getAllSkit();
        while (reader.Read())
        {
            skits.Add(reader[1].ToString());
        }
        index = Random.Range(0, skits.Count);
        text.text = skits[index];
    }
}
