using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Keep track of all the boba drinks data in these script

public enum Flavor {
    None = 0,
    MilkTea = 1
    //NumberOfTypes // Maybe use this to create barriers
}

public enum Size {
    None = 0,
    Wrong = 1,
    Correct = 2
}

public enum Topping {
    None = 0,
    Boba = 1
}

public enum Sweetness {
    None = 0,
    FiftyPercent = 1,
    HundredPercent = 2
}

public enum Ice {
    None = 0,
    FiftyPercent = 1,
    HundredPercent = 2
}

public struct Drink {
    public Size size;
    public Flavor flavor;  
    public Topping topping;
    public Sweetness sweetness;
    public Ice ice;
}

public class DrinkStructs : MonoBehaviour
{
    public Drink RandomizeDrink() {

        Drink drink;

        int enumLength = System.Enum.GetValues(typeof(Flavor)).Length;
        drink.flavor = (Flavor)Random.Range(1, enumLength);
        
        enumLength = System.Enum.GetValues(typeof(Topping)).Length;
        drink.topping = (Topping)Random.Range(0, enumLength);
        enumLength = System.Enum.GetValues(typeof(Sweetness)).Length;
        drink.sweetness = (Sweetness)Random.Range(0, enumLength);
        enumLength = System.Enum.GetValues(typeof(Ice)).Length;
        drink.ice = (Ice)Random.Range(0, enumLength);

        drink.size = Size.None;

        return drink;

    }

    public string PrintReceipt(Drink drink)
    {
        string receipt = "Can I get a ";

        Debug.Log(drink.flavor);

        switch (drink.flavor) {
            case Flavor.MilkTea:
                receipt = receipt + "Milk Tea, ";
                break;
            default:
                receipt = "Error in Flavor";
                return receipt;
        }

        switch (drink.sweetness) {
            case Sweetness.None:
                receipt = receipt + "at 0% Sweetness, ";
                break;
            case Sweetness.FiftyPercent:
                receipt = receipt + "at 50% Sweetness, ";
                break;
            case Sweetness.HundredPercent:
                receipt = receipt + "at 100% Sweetness, ";
                break;
            default:
                receipt = "Error in Sweetness";
                return receipt;

        }

        switch (drink.ice) {
            case Ice.None:
                receipt = receipt + "with No Ice, ";
                break;
            case Ice.FiftyPercent:
                receipt = receipt + "with 50% Ice, ";
                break;
            case Ice.HundredPercent:
                receipt = receipt + "with 100% Ice, ";
                break;
            default:
                receipt = "Error in Ice";
                return receipt;
        }

        switch (drink.topping) {
            case Topping.None:
                receipt = receipt + "and No Toppings";
                break;
            case Topping.Boba:
                receipt = receipt + "and Boba";
                break;
            default:
                receipt = "Error in Topping";
                return receipt;
        }


        return receipt;

    }
}
