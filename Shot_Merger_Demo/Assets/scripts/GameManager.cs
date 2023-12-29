using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool AllowFire=true;
    public bool BoolGameOver = false;

    public float FireRate = 1f;
    public float FireRateText = 1;
    public float FireRateTextSum = 0;
    public float FireRateTextMult = 1;

    public int Bonus = 0;

    public GameObject GameOverPanel;
    public GameObject WinPanel;

    [SerializeField] TextMeshProUGUI Wintext;
    public movement player;

    [SerializeField] TextMeshProUGUI text;
    private void SingletonThisObject()
    {
        if (Instance == null)
        {
            Instance = this;
           
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Awake()
    {
        SingletonThisObject();
        player = FindAnyObjectByType<movement>();
        GameOverPanel = GameObject.FindWithTag("GameOverPanel");
        GameOverPanel.SetActive(false);
        WinPanel = GameObject.FindWithTag("WinPanel");
        WinPanel.SetActive(false);
    }
    private void Update()
    {
        FireRateText = FireRateTextSum + FireRateTextMult;
        text.text = FireRateText.ToString()+"/sec";
        if (Bonus==8)
        {
            WinCon();
            Wintext.text = "You Win";
        }
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    public void WinCon()
    {
        WinPanel.SetActive(true);
    }
    public void GameOver()
    {

        StartCoroutine(GameOverAsync());
    }
    private IEnumerator GameOverAsync()
    {
        yield return new WaitForSeconds(2f);
        
        if (Bonus>0)
        {
            WinPanel.SetActive(true);
            Wintext.text = Bonus.ToString() + " " + "x bonus";
        }
        else
        {
            GameOverPanel.SetActive(true);
        }
    }

    public void StartGame()
    {
        player.enabled = true;
        player.GetComponentInChildren<shot>().enabled = true;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        StartGame();
    }


}
