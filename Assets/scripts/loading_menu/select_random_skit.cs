using UnityEngine;
using UnityEngine.UI;
public class select_random_skit : MonoBehaviour
{
    private Text text;
    public Skit[] skits;
    private void Awake()
    {
        text = GetComponent<Text>();
        selectRandomSkit();
    }

    void selectRandomSkit()
    {
        int index = Random.Range(0, skits.Length);
        text.text = skits[index].content;
    }
}
