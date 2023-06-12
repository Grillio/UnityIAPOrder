using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject PurchaseWindow;
    public GameObject GearCanvas;
    public GameObject InsufficientFunds;
    public Canvas gearCanvas;

    public GameObject container;

    private GameObject selectedTexture;

    public List<string> purchasedItems = new List<string>();

    public void openCanvas(GameObject _object)
    {
        Debug.Log(_object.tag);
        selectedTexture = null;
        //if the object passed in was a gear item then open that items texture details
        if (_object.tag == "Gear")
        {
            GearInfo _gearInfo = _object.GetComponent<GearInfo>(); 
            Animator animation = GearCanvas.GetComponent<Animator>();
            ClearContainer();
            FloodContainer(_gearInfo);
            GearCanvas.SetActive(true);
            animation.SetTrigger("Open");
            float ContainerSize = Mathf.Ceil(_gearInfo.textures.Length / 3);
            container.GetComponent<RectTransform>().sizeDelta = new UnityEngine.Vector3(184, ContainerSize * 57, 1);
        }
        //if the object passed in was a texture for a gear then open the window to purchase that texture if it has yet to be purchased.
        if(_object.tag == "Texture"){
            selectedTexture = _object;
            if (purchasedItems.Contains(_object.name))
            {
                //Add in function to equip the texture to the character here:



                //
            }
            else
            {
                
                Animator animation = PurchaseWindow.GetComponent<Animator>();
                PurchaseWindow.SetActive(true);
                animation.SetTrigger("Open");
            }
        }
    }

    public void PurchaseItem()
    {
        selectedTexture.GetComponent<TextureInfo>().Unlocked = true;
        float TexturePrice = selectedTexture.GetComponent<TextureInfo>().Cost;

        //Add in code to decrease the value of the gems that the player has
        if(!purchasedItems.Contains(selectedTexture.name))
            purchasedItems.Add(selectedTexture.name);

        //add in code to check if the player doesn't have sufficient funds


        //


        //
        PurchaseWindow.SetActive(false);
    }

    private IEnumerator FlashInsufficientFunds()
    {
        InsufficientFunds.SetActive(true);
        float flashTime = 2f;
        while(flashTime >= 0)
        {
            flashTime -= Time.deltaTime;
            yield return null;
        }
        InsufficientFunds.SetActive(false);
    }

    private void ClearContainer()
    {
        for(int i = container.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(container.transform.GetChild(i).gameObject);
        }
    }

   private void FloodContainer(GearInfo _gearInfo)
    {
        foreach (GameObject textureObjPlaceholder in _gearInfo.textures)
        {
            var newTexture = Instantiate(textureObjPlaceholder, container.transform);
            if(purchasedItems.Contains(newTexture.name))
                newTexture.GetComponent<TextureInfo>().Unlocked = true;
        }
    }

    public void closeCanvas(GameObject _window)
    {
        Animator animation = _window.GetComponent<Animator>();
        animation.SetTrigger("Close");
        StartCoroutine(closeNow(_window));
    }

    private IEnumerator closeNow(GameObject _obj)
    {
        yield return new WaitForSeconds(.5f);
        _obj.SetActive(false);
    }
}
