using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public static ScoreController Instance; 
    public float scoreTotal;
    public GameObject scoreVisual;
    public TMP_Text scoreText;
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
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddScore(float points, Transform pos)
    {
       GameObject test = Instantiate(scoreVisual, pos.position, new Quaternion(0,0,0,0));
        test.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = points.ToString();

        //scoreText.text = (int.Parse(scoreText.text) + points).ToString();

       // print(scoreText.text);
    }
}
