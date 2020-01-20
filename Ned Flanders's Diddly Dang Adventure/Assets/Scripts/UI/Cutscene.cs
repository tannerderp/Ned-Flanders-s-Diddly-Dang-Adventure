using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    public double time;
    public double currentTime;

    private int wait = 0;
    [SerializeField] int approximateLoadTime = 80;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        wait++;
        if (wait == approximateLoadTime)
        {
            time = GetComponent<VideoPlayer>().frameCount / 30 + 0.7;
            Debug.Log(time);
        }
        if (wait > approximateLoadTime)
        {
            currentTime = GetComponent<VideoPlayer>().time;
            if (currentTime > time - 0.1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
