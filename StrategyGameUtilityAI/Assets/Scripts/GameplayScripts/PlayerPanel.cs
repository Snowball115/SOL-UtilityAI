using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPanel : MonoBehaviour
{
    // Player blue data
    public GameObject PlayerBlue;
    public GameObject BlueWood;
    public GameObject BlueOre;
    public GameObject BlueFood;
    public GameObject BlueSoldiers;

    // Player red data
    public GameObject PlayerRed;
    public GameObject RedWood;
    public GameObject RedOre;
    public GameObject RedFood;
    public GameObject RedSoldiers;

    // Panel components
    private Player playerRed;
    private Player playerBlue;
    private Text blueWoodText;
    private Text blueOreText;
    private Text blueFoodText;
    private Text blueSoldierText;
    private Text redWoodText;
    private Text redOreText;
    private Text redFoodText;
    private Text redSoldierText;


    void Start()
    {
        playerBlue = PlayerBlue.GetComponent<Player>();
        playerRed = PlayerRed.GetComponent<Player>();

        blueWoodText = BlueWood.GetComponent<Text>();
        blueOreText = BlueOre.GetComponent<Text>();
        blueFoodText = BlueFood.GetComponent<Text>();
        blueSoldierText = BlueSoldiers.GetComponent<Text>();

        redWoodText = RedWood.GetComponent<Text>();
        redOreText = RedOre.GetComponent<Text>();
        redFoodText = RedFood.GetComponent<Text>();
        redSoldierText = RedSoldiers.GetComponent<Text>();
    }

    void Update()
    {
        blueWoodText.text = playerBlue._playerInventory.WoodCount.ToString();
        blueOreText.text = playerBlue._playerInventory.OreCount.ToString();
        blueFoodText.text = playerBlue._playerInventory.FoodCount.ToString();
        blueSoldierText.text = playerBlue._CurrentSoldiersCount.ToString();

        redWoodText.text = playerRed._playerInventory.WoodCount.ToString();
        redOreText.text = playerRed._playerInventory.OreCount.ToString();
        redFoodText.text = playerRed._playerInventory.FoodCount.ToString();
        redSoldierText.text = playerRed._CurrentSoldiersCount.ToString();
    }
}
