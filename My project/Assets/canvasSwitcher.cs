using UnityEngine;

public class CanvasSwitcher : MonoBehaviour
{
    // References to the canvases
    public Canvas canvas1;
    public Canvas canvas2;

    // Method to switch from Canvas1 to Canvas2
    public void SwitchToCanvas2()
    {
        // Deactivate Canvas1 and activate Canvas2
        canvas1.gameObject.SetActive(false);
        canvas2.gameObject.SetActive(true);
    }
}