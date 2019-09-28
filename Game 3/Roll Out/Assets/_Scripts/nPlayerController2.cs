//Levi Sutton

using UnityEngine;
using System.Collections;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class nPlayerController2 : MonoBehaviour
{
    private Rigidbody rb;
    public Text timerText;
    public Text highScoreText;
    StreamReader sr;
    public GameObject player;
    public Transform shotSpawn;
    public Transform shotSpawnBack;
    public GameObject shot;
    public GameObject shot2;

    public int index;
    public string sceneName;
    public float speed;
    float timer = 0.0f;
    int highScore = 0;
    string fileName = "Position2.txt";
    string data = "0.0,0.35,0.5";
    private float nextFire;
    public float fireRate;

    void Start()
    {
        timerText.text = "";
        highScoreText.text = "";
        rb = GetComponent<Rigidbody>();
        LoadPosition(fileName);
    }
    void Update()
    {
        timer += Time.deltaTime;
        highScore = (int)timer;
        SetTimer();
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal1");
        float moveVertical = Input.GetAxis("Vertical1");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

        if (Input.GetKeyDown("f"))
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
        if (Input.GetKeyDown("space"))
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot2, shotSpawnBack.position, shotSpawnBack.rotation);
        }

    }
    public void SetTimer()
    {
        timerText.text = "Time:  " + timer.ToString(".00");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            updateHighScore();
            StartCoroutine(SwitchScene());
            SceneManager.LoadScene(index);
            SceneManager.LoadScene("Player2Win");
        }
    }
    public string updateHighScore()
    {
        PlayerPrefs.SetInt("Player Score", highScore);
        highScoreText.text = "High Score: " + highScore.ToString();
        return highScoreText.text;
    }
    IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(10);
    }
    void LoadPosition(string filename)
    {
        try
        {
            if (!File.Exists(filename))
            {
                File.WriteAllText(Application.dataPath + "/" + filename, data);
            }
            sr = new StreamReader(Application.dataPath + "/" + filename);
            string dataline = "";
            dataline = sr.ReadLine();

            string[] values = dataline.Split(',');
            Vector3 pos = Vector3.zero;
            pos.x = float.Parse(values[0]);
            pos.y = float.Parse(values[1]);
            pos.z = float.Parse(values[2]);
            player.transform.position = pos;
            dataline = sr.ReadLine();

        }
        catch (IOException e)
        {
            Debug.Log("Caught: " + e);
        }
        catch (System.IndexOutOfRangeException e)
        {
            Debug.Log(e.Message);
        }

        finally
        {
            if (sr != null)
                sr.Close();
        }
    }
}
