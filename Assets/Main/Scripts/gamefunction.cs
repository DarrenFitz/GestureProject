using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamefunction : MonoBehaviour {
    private List<GameObject> emeny_copylist = new List<GameObject>();
    private List<GameObject> rock_copylist = new List<GameObject>();
    public GameObject emeny;
    public GameObject rock;
    public GameObject ship;

    public float Y = 3.75f;
    public float espawn;
    public float rspawn;
    private float time; 
    private float rtime;

    bool product_emeny = true;

    public GameObject LoseText;
    public GameObject WinText = null;
    public Text ScoreText;
    public int Score = 0;
    public Text LifeText; 
    public int Life = 3;
    public static gamefunction Instance; 
    void Start () {
        Instance = this;
        LoseText.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if(KinectManager.instance.IsPlaying)
        {
            time += Time.deltaTime; 
            if (time > espawn)
            {
                Vector3 pos = new Vector3(Random.Range(-2.5f, 2.5f), Y, 0); 
                if (product_emeny == true)
                {
                    GameObject thisobject = Instantiate(emeny, pos, transform.rotation) as GameObject;
                    emeny_copylist.Add(thisobject);

                }
                time = 0f;
            }
            rtime += Time.deltaTime;
            if (rtime > rspawn)
            {
                Vector3 rpos = new Vector3(Random.Range(-2.5f, 2.5f), Y, 0);
                if (product_emeny == true)
                {
                    GameObject robject = Instantiate(rock, rpos, transform.rotation) as GameObject;
                    rock_copylist.Add(robject);
                }
                rtime = 0f;
            }
        }
        
    }

    public void AddScore()
    {
        Score += 2;
        ScoreText.text = "Score: " + Score;
    }
    public void MinusScore()
    {
        Score -= 1;
        ScoreText.text = "Score: " + Score;
    }

    public int GetScore()
    {
        return Score;
    }
    public void SetScore(int n)
    {
        Score = n;
    }

    public void MinusLife()
    {
        StartCoroutine(TurnRed());
        Life -= 1;
        if (Life == 0)
            EndGame();
        LifeText.text = "Life: " + Life; 
    }

    public void EndGame()
    {
        product_emeny = false;
        foreach (GameObject d in emeny_copylist)
        {
            Destroy(d);
        }
        foreach (GameObject d in rock_copylist)
        {
            Destroy(d);
        }
        emeny_copylist.Clear();
        rock_copylist.Clear();
        ship.SetActive(false);
        LoseText.SetActive(true);
        StartCoroutine(WaitToBack());
    }
    private IEnumerator TurnRed()
    {
        Color _red = Color.red;
        _red.a = 0.5f;
        Color col = ship.GetComponent<SpriteRenderer>().color;
        ship.GetComponent<SpriteRenderer>().color = _red;
        yield return new WaitForSeconds(0.2f);
        ship.GetComponent<SpriteRenderer>().color = col;
        yield return new WaitForSeconds(0.2f);
        ship.GetComponent<SpriteRenderer>().color = _red;
        yield return new WaitForSeconds(0.2f);
        ship.GetComponent<SpriteRenderer>().color = col;
        yield return new WaitForSeconds(0.2f);
    }
    private IEnumerator WaitToBack()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("menu", LoadSceneMode.Single);
    }
    public void WinGame()
    {
        product_emeny = false;
        foreach (GameObject d in emeny_copylist)
        {
            Destroy(d);
        }
        foreach (GameObject d in rock_copylist)
        {
            Destroy(d);
        }
        emeny_copylist.Clear();
        rock_copylist.Clear();
        ship.SetActive(false);
        WinText.SetActive(true);
        StartCoroutine(WaitToBack());
    }
}
