using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

/// <summary>
/// The GameManager class. 
/// Contains all the methods to apply the basic game logic.
/// </summary>
public class GameManager : MonoBehaviour
{
    #region Variables

    /// <value> Gets or sets the instance of a GameManager object </value>
    public static GameManager Instance { get; private set; }

    /* VARIABLES TO COUNT WITH */
    /// <value> Integer to keep track of all the catched poops </value>
    private int catchedPoop = 0;
    /// <value> Integer to keep track of all the missed poops </value>
    private int missedPoop = 0;
    /// <value> Integer to keep track of the amount of items the Farmer unlocks </value>
    private int itemsUnlocked = 0;

    /* VARIABELES TO RUN THE GAME WITH */
    /// <value> Boolean to see if the player in question is the winner (true) or isn't the winner (false) </value>
    private bool winner = false;
    /// <value> Boolean to see if the game has ended (true) or not (false) </value>
    private bool gameEnded = false;

    // Deze geeft waarschijnlijk het # gemiste kakjes aan, maar zal weggelaten worden in de game UI
    [SerializeField]
    private TextMeshProUGUI missedPoopText;


    /* DOWNGRADE CANVAS ELEMENTS */
    /// <value> The slider which will show the Farmer how the environment is evolving (bad -> good). This slider will show the downgrade of the environment </value>
    [SerializeField]
    private Slider downgradeSlider;
    
    /* UPGRADE CANVAS ELEMENTS */
    /// <value> The slider which will show the Farmer how the environment is evolving (bad -> good). This slider will show the upgrade of the environment </value>
    [SerializeField]
    private Slider upgradeSlider;
    /// <value> </value>
    [SerializeField]
    private TextMeshProUGUI upgradeText;
    /// <value> List from RawImage objects which contains all the item icons the Farmer can unlock </value>
    [SerializeField]
    private RawImage[] itemIcons;
    /// <value> List from Texture objects which contains all the item's their textures </value>
    [SerializeField]
    private Texture[] itemTextures;

    /* POPUP CANVAS */
    /// <value> Instance of the Canvas element we want to pop up </value>
    [SerializeField]
    private Canvas popUpCanvas;
    /// <value> The RawImage shown in the pop-up </value>
    [SerializeField]
    private RawImage popUp;
    /// <value> The Button object to close the pop-up canvas </value>
    [SerializeField]
    private Button popUpButton;
    /// <value> List from Texture objects which contain all the pop-ups </value>
    [SerializeField]
    private Texture[] popUps;

    /* ENDING CANVAS */
    /// <value> Instance of the Canvas element we want to close the game with </value>
    [SerializeField]
    private Canvas endingCanvas;
    /// <value> The RawImage shown in the ending canvas </value>
    [SerializeField]
    private RawImage endingImg;
    /// <value> The TextMeshProUGUI object to show the ending title on the canvas </value>
    [SerializeField]
    private TextMeshProUGUI endingTitle;
    /// <value> The Button object to close the ending canvas and the game </value>
    [SerializeField]
    private Button endingButton;
    /// <value> The Texture which will show who won the game on the ending canvas </value>
    [SerializeField]
    private Texture winnerImg;

    /* FARMER ELEMENTS */
    /// <value> The GameObject which represents the body of the Farmer </value>
    [SerializeField]
    private GameObject farmerBody;
    /// <value> The GameObject which represents the left leg of the Farmer </value>
    [SerializeField]
    private GameObject farmerLegLeft;
    /// <value> The GameObject which represents the right leg of the Farmer </value>
    [SerializeField]
    private GameObject farmerLegRight;
    /// <value> Material to use when the Farmer unlocks a new outfit </value>
    [SerializeField]
    private Material blue;

    /* RENDER ELEMENTS */ 
    /// <value> The Renderer object for the body </value>
    private Renderer rendBody;
    /// <value> The Renderer object for the left leg </value>
    private Renderer rendLegLeft;
    /// <value> The  Renderer object for the right leg </value>
    private Renderer rendLegRight;

    #endregion

    #region Standard Methods

    /// <summary>
    /// The Awake method.
    /// If the GameManager awakens we check if there isn't already an instance of the GameManager object. If not, we set this GameManager object to this script.
    /// </summary>
    void Awake()
    {
        if (Instance == null) 
        { 
            Instance = this;
        }
    }

    /// <summary>
    /// The Start method.
    /// We need to set some variabeles when the GameManager starts.
    /// </summary>
    void Start()
    {
        //set all the variabeles from the renderer elements
        rendBody = farmerBody.GetComponent<Renderer>();
        rendLegLeft = farmerLegLeft.GetComponent<Renderer>();
        rendLegRight = farmerLegRight.GetComponent<Renderer>();
        // enable all these variabeles
        rendBody.enabled = true;
        rendLegLeft.enabled = true;
        rendLegRight.enabled = true;
    }

    #endregion

    #region Custom Methods

    /// <summary>
    /// The getCatchedPoop method.
    /// This method is used to know how many poops the Farmer has catched during the game.
    /// </summary>
    /// <returns>This method returns the catchedPoop integer.</returns>
    public int getCatchedPoop()
    {
        return catchedPoop;
    }

    /// <summary>
    /// The getMissedpoop method.
    /// This method is used to know how many poops the Farmer has missed during the game.
    /// </summary>
    /// <returns>This method returns the missedPoop integer.</returns>
    public int getMissedPoop()
    {
        return missedPoop;
    }

    /// <summary>
    /// The addCatchedPoop method.
    /// This method increases the catchedPoop integer with 1. 
    /// <para> It calls the updateScoreGUI function so the player can see the amount of catched poops change on the screen. </para>
    /// <para> If the catchedPoop integer equals 5, it increases the itemsUnlocked integer value with 1 and calls the openPopUp function. </para>
    /// </summary>
    public void addCathedPoop()
    {
        catchedPoop++;

        updateScoreGUI();

        if (catchedPoop == 5)
        {
            itemsUnlocked++;
            openPopUp(itemsUnlocked);
        }
    }

    /// <summary>
    /// The addMissedPoop method.
    /// This method increases the missedPoop integer with 1. 
    /// <para> When we divide the missedPoop integer by 5 and the remainder (%-operator) is 0, we will downgrade the enivornment by calling the updateDowngradeGUI method. </para>
    /// </summary>
    public void addMissedPoop()
    {
        missedPoop++;
        missedPoopText.text = "missed: " + missedPoop;  //TEST

        if(missedPoop%5 == 0)
        {
            updateDowngradeGUI();
        }
    }

    /// <summary>
    /// The updateScoreGUI method.
    /// Will show the Farmer the amount of catched poops on the screen. 
    /// </summary>
    private void updateScoreGUI()
    {
        upgradeText.text = catchedPoop + "/5";
    }

    /// <summary>
    /// The openPopUp method. 
    /// This method will show a pop up each time the Farmer unlocks one of the items.
    /// <para> If the itemToUnlock equals one, the body of the Farmer get's a new color (= blue). </para>
    /// <para> If the itemToUnlock equals four, the Farmer has won the game. The game will end. </para>
    /// </summary>
    /// <param name="itemToUnlock">The number of the item in the itemIcons list we want to unlock.</param>
    private void openPopUp(int itemToUnlock)
    {
        // Upgrade the value of the slider so the Farmer knows he is closer to winning the game
        upgradeSlider.value++;
        // Set the right texture for the unlocked item
        itemIcons[itemToUnlock-1].texture = itemTextures[itemToUnlock-1];

        // Show the right pop up for the unlocked item
        popUp.texture = popUps[itemToUnlock - 1];
        // Set the canvas active (so it's visible on the screen)
        popUpCanvas.gameObject.SetActive(true);

        Time.timeScale = 0;

        // If itemToUnlock equals one, change the colour of the Farmers' body
        if (itemToUnlock == 1)
        {
            var matsBody = rendBody.materials;
            matsBody[1] = blue;
            rendBody.materials = matsBody;

            var matsLegLeft = rendLegLeft.materials;
            matsLegLeft[0] = blue;
            rendLegLeft.materials = matsLegLeft;

            var matsLegRight = rendLegRight.materials;
            matsLegRight[0] = blue;
            rendLegRight.materials = matsLegRight;
        }

        // If itemToUnlock equals four, end the game and make the Farmer the winner
        if (itemToUnlock == 4)
        {
            gameEnded = true;
            winner = true;
        }
    }

    /// <summary>
    /// The updateDowngradeGUI method.
    /// This method will change the downgrade slider so both the players know the environment is getting worse. 
    /// <para> If the value of the downgrade slider is equal to zero, the game will end and the Cow will be the winner. </para>
    /// </summary>
    private void updateDowngradeGUI()
    {
        downgradeSlider.value = downgradeSlider.value - 1;

        if(downgradeSlider.value == 0)
        {
            gameEnded = true;
            winner = false;
            endGame();
        }

    }

    /// <summary>
    /// The closePopUp method.
    /// This method will be envoked when the game ends or the player closes the pop-up.
    /// <para> If the gameEnded variable equals true, end the game. </para>
    /// <para> If the gameEnded variable equals false, reset the catchedPoop integer to zero and set the canvas to inactive. </para>
    /// </summary>
    public void closePopUp()
    {
        if (gameEnded)
        {
            endGame();
        }
        else
        {
            catchedPoop = 0;
            popUpCanvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    /// <summary>
    /// The endGame method.
    /// This method is called when there is a winner.
    /// <para> Set the pop-up canvas to inactive. </para>
    /// <para> If the player is the winner, show the winner image and text. </para>
    /// <para> Set the ending canvas to active. </para>
    /// </summary>
    private void endGame()
    {
        popUpCanvas.gameObject.SetActive(false);
        if (winner)
        {
            endingImg.texture = winnerImg;
            endingTitle.text = "Je hebt gewonnen";
        }

        Time.timeScale = 0;
        endingCanvas.gameObject.SetActive(true);
    }

    /// <summary>
    /// The restartGame method.
    /// This method is called when the game is restarted.
    /// <para> Reload the scene. </para>
    /// </summary>
    public void restartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    #endregion

}
