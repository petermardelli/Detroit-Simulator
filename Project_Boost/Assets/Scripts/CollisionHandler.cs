
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip crashClip;
    [SerializeField] private AudioClip successClip;

    [Tooltip("In Seconds")] [SerializeField] private float levelLoadDelay = 1f;
    private bool isTransitioning = false;
    private void Start(){
        audioSource = GetComponent<AudioSource>();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if(isTransitioning) return;
       switch(other.gameObject.tag)
       {
           case "Friendly":
           print("Is Friendly");
           break;

            case "Finish":
                Finish();
                break;

            default:
                Crash();
                break;

        }

   }

    private void Finish()
    {
        audioSource.PlayOneShot(successClip);
        Invoke(nameof(LoadNextScene), levelLoadDelay);
    }

    private void Crash()
    {
        GetComponent<PlayerController>().enabled = false;
        audioSource.PlayOneShot(crashClip);
        Invoke(nameof(ReloadScene), levelLoadDelay);
    }

    private void LoadNextScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        sceneIndex++;
        if(sceneIndex == SceneManager.sceneCountInBuildSettings) sceneIndex = 0;
        

        
        SceneManager.LoadScene(sceneIndex);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

