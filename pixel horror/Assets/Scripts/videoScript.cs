using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class videoScript : MonoBehaviour
{

    VideoPlayer Video;

    void Awake()
    {
        Video = GetComponent<VideoPlayer>();
        Video.Play();
        Video.loopPointReached += CheckOver;


    }


    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(2); //the scene that you want to load after the video has ended.
    }
}
