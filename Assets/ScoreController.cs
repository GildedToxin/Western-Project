using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static ScoreController Instance;
    public float scoreTotal;
    public GameObject scoreVisual;
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public float backEndTimer;
    public int maxTimer = 90;


    // Start is called before the first frame update
    void Awake()
    {
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

        if(backEndTimer > maxTimer)
        {
            print("GAME IS OVER");
        }
    }
    public void AddScore(float points, Transform pos)
    {
        GameObject test = Instantiate(scoreVisual, pos.position, new Quaternion(0, 0, 0, 0));
        test.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = points.ToString();
        scoreText.text = (int.Parse(scoreText.text) + points).ToString();
    }
}
  
