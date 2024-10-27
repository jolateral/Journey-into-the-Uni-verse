using TMPro;
using UnityEngine;

public class GetScore : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TMP_Text text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text="Score: "+ GameManager.score.ToString();
    }
}
