using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPanel : MonoBehaviour
{
    public GameObject PlayerBlue;
    public GameObject PlayerRed;
    public GameObject BlueWood;
    public GameObject BlueOre;
    public GameObject BlueFood;
    public GameObject RedWood;
    public GameObject RedOre;
    public GameObject RedFood;

    private Player playerRed;
    private Player playerBlue;
    private Text blueWoodText;
    private Text blueOreText;
    private Text blueFoodText;
    private Text redWoodText;
    private Text redOreText;
    private Text redFoodText;


    void Start()
    {
        playerBlue = PlayerBlue.GetComponent<Player>();
        playerRed = PlayerRed.GetComponent<Player>();

        blueWoodText = BlueWood.GetComponent<Text>();
        blueOreText = BlueOre.GetComponent<Text>();
        blueFoodText = BlueFood.GetComponent<Text>();

        redWoodText = RedWood.GetComponent<Text>();
        redOreText = RedOre.GetComponent<Text>();
        redFoodText = RedFood.GetComponent<Text>();
    }

    void Update()
    {
        blueWoodText.text = playerBlue._playerInventory.WoodCount.ToString();
        blueOreText.text = playerBlue._playerInventory.OreCount.ToString();
        blueFoodText.text = playerBlue._playerInventory.FoodCount.ToString();

        redWoodText.text = playerRed._playerInventory.WoodCount.ToString();
        redOreText.text = playerRed._playerInventory.OreCount.ToString();
        redFoodText.text = playerRed._playerInventory.FoodCount.ToString();
    }
}
