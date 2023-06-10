using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public Canvas PurchaseFailedMessage;
    public Canvas ActiveCanvas;

    public Canvas MainCanvas;
    public void PopupError(){
        ActiveCanvas.enabled = false;
        PurchaseFailedMessage.enabled = true;
    }

    public void ExitErrorMessage(){
        ActiveCanvas.enabled = true;
        PurchaseFailedMessage.enabled = false;
    }

    public void ReturnToMenu(){
        ActiveCanvas.enabled = false;
        MainCanvas.enabled = true;
    }
}
