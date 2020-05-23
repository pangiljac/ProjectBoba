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
    public int drinkHolderSize;

    private bool areDrinksSet = false;
    private GameObject[] drinkHolder;
    private Drink receipt;
    private string currentScene;

    private Drink[] drinks;

    // Start is called before the first frame update
    void Start()
    {
        if(areDrinksSet == false) {
            Debug.Log("Start");
            drinks = new Drink[drinkHolderSize];
            areDrinksSet = true;
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);

        currentScene = scene.name;

        if (currentScene == "Station2") {
            
            drinkHolder = GameObject.FindGameObjectsWithTag("Cup");          
        }
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

        if (currentStation == 2) {
            //Weird Bug that doesn't properly follow the names
            if (Input.GetKeyDown("z"))
            {
                Debug.Log(drinkHolder[0].name);
                highlightCup(0);
            }
            else if (Input.GetKeyDown("x"))
            {
                Debug.Log(drinkHolder[2].name);
                highlightCup(2);
            }
            else if (Input.GetKeyDown("c"))
            {
                Debug.Log(drinkHolder[1].name);
                highlightCup(1);
            }
        }
        
    }

    void highlightCup(int index) {
        GameObject highlight;

        for (int x = 0; x < drinkHolder.Length; x++) {
            
            highlight = drinkHolder[x].transform.GetChild(4).gameObject;
            if (x == index)
                highlight.SetActive(true);
            else
                highlight.SetActive(false);
        }
            


    }

    void OnDisable()
    {
        Debug.Log("Disabled");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
