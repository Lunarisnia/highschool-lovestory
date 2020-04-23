using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
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
        while (true)
        {
            JSONNode skits = new Skits().readJsonFile();
            int randomIndex = Random.Range(0, skits.Count);
            if (skits[randomIndex]["isDeleted"] == 0)
            {
                text.text = skits[randomIndex]["skit"];
                break;
            }
        }
    }
}
