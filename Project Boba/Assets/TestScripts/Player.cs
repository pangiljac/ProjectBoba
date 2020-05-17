using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int currentStation;
    public DrinkStructs drinkStructs;
    public GameObject textBubble;


    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;
    private Drink receipt;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("[1]") && currentStation != 1)
        {
            currentStation = 1;
            SceneManager.LoadScene("Station1");
        }
        else if (Input.GetKeyDown("[2]") && currentStation != 2)
        {
            currentStation = 2;
            SceneManager.LoadScene("Station2");
        }
        else if (Input.GetKeyDown("[3]") && currentStation != 3)
        {
            currentStation = 3;
            SceneManager.LoadScene("Station3");
        }

        if (Input.GetKeyDown("space") && currentStation == 1) {
            Text myText = textBubble.GetComponent<Text>();
            receipt = drinkStructs.RandomizeDrink();
            myText.text = drinkStructs.PrintReceipt(receipt);
        }

        if (Input.GetKey("escape")) {
            Application.Quit();
        }
    }
}
