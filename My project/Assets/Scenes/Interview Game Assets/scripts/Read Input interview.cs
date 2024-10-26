using UnityEngine;

public class ReadInterviewInput : MonoBehaviour
{
    private string input;
    //Start is called before the first frame update
    void Start()
    {

    }

    //Update is called once per frame
    void Update()
    {

    }

    public void ReadStringInput(string s)    
    {
        input = s;
        Debug.Log(input);

    }
}
