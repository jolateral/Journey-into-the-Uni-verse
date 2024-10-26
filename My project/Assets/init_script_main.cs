using UnityEngine;

public class init_script_main : MonoBehaviour
{
    public Canvas canvas1;
    public Canvas canvas2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvas1.gameObject.SetActive(true);
        canvas2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
