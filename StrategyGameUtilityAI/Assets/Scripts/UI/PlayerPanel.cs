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
    public GameObject BlueFlagsCount;

    // Player red data
    public GameObject PlayerRed;
    public GameObject RedWood;
    public GameObject RedOre;
    public GameObject RedFood;
    public GameObject RedSoldiers;
    public GameObject RedFlagsCount;


    // Panel components
    private Player playerRed;
    private Player playerBlue;
    private Text blueWoodText;
    private Text blueOreText;
    private Text blueFoodText;
    private Text blueSoldierText;
    private Text blueFlagCountText;
    private Text redWoodText;
    private Text redOreText;
    private Text redFoodText;
    private Text redSoldierText;
    private Text redFlagCountText;


    void Start()
    {
        playerBlue = PlayerBlue.GetComponent<Player>();
        playerRed = PlayerRed.GetComponent<Player>();

        blueWoodText = BlueWood.GetComponent<Text>();
        blueOreText = BlueOre.GetComponent<Text>();
        blueFoodText = BlueFood.GetComponent<Text>();
        blueSoldierText = BlueSoldiers.GetComponent<Text>();
        blueFlagCountText = BlueFlagsCount.GetComponent<Text>();

        redWoodText = RedWood.GetComponent<Text>();
        redOreText = RedOre.GetComponent<Text>();
        redFoodText = RedFood.GetComponent<Text>();
        redSoldierText = RedSoldiers.GetComponent<Text>();
        redFlagCountText = RedFlagsCount.GetComponent<Text>();
    }

    void Update()
    {
        blueWoodText.text = playerBlue._PlayerInventory.WoodCount.ToString();
        blueOreText.text = playerBlue._PlayerInventory.OreCount.ToString();
        blueFoodText.text = playerBlue._PlayerInventory.FoodCount.ToString();
        blueSoldierText.text = playerBlue._CurrentSoldiersCount.ToString();
        blueFlagCountText.text = playerBlue._CapturedCPs.Count.ToString();

        redWoodText.text = playerRed._PlayerInventory.WoodCount.ToString();
        redOreText.text = playerRed._PlayerInventory.OreCount.ToString();
        redFoodText.text = playerRed._PlayerInventory.FoodCount.ToString();
        redSoldierText.text = playerRed._CurrentSoldiersCount.ToString();
        redFlagCountText.text = playerRed._CapturedCPs.Count.ToString();
    }
}
