using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScoreController : MonoBehaviour
{
    public static ScoreController Instance;
    public float scoreTotal;
    public GameObject scoreVisual;
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public float backEndTimer;
    public int maxTimer = 90;
    public Canvas canvas;
    private bool test;

    // Start is called before the first frame update
    void Awake()
    {
        test = true;
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        scoreText.text = "0";
        timerText.text = maxTimer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        backEndTimer += Time.deltaTime;

        timerText.text = ((int)(maxTimer - backEndTimer)).ToString();

        if(backEndTimer > maxTimer && test)
        {
            timerText.text = "GAME OVER";
            canvas.gameObject.SetActive(true);
            canvas.gameObject.transform.GetChild(1).GetComponent<TMP_Text>().SetText($"You scored {scoreText.text} Points!");
            test = false;
            StartCoroutine(MyTwoSecondCoroutine());
        }
    }
    public void AddScore(float points, Transform pos)
    {
        print("ADDED SCORE");
        GameObject test = Instantiate(scoreVisual, pos.position, new Quaternion(0, 0, 0, 0));
        test.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = points.ToString();
        scoreText.text = (int.Parse(scoreText.text) + points).ToString();
       
    }
    public void NewGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public IEnumerator MyTwoSecondCoroutine()
    {
        for (int i = 5; i > 0; i--)
        {
            canvas.gameObject.transform.GetChild(2).GetChild(0).GetComponent<TMP_Text>().SetText($"Game Restarting in {i}");
            yield return new WaitForSeconds(1f);
        }
        NewGame();


    }
}
  
