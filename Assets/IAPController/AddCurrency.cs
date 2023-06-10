using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class AddCurrency : MonoBehaviour
{
    public void AddCurrencyToGame(Product product){
        float CurrencyToAdd = (float) product.definition.payout.quantity;

        //now add in the currencytoadd into the correct game float
        
    }
}
