using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using UnityEngine;

public class Goal : MonoBehaviour
{
  GameObject goalText;
  private bool isGoal = false;
  [DllImport("__Internal")]
  private static extern void StartEyeDetection();

  private AudioSource audioSource;

  private ScoreManeger scoreManeger;
  private GameObject scoreText;
  public int minScore;


  void Start()
  {
    // Debug.Log("aaaaaa");
    goalText = GameObject.Find("Canvas").transform.Find("GoalText").gameObject;
    audioSource = GetComponent<AudioSource>();
    scoreText = GameObject.Find("ScoreText");
    scoreManeger = scoreText.GetComponent<ScoreManeger>();
  }
  // ぶつかった際に呼ばれるメソッド
  void OnCollisionEnter(Collision collision)
  {

    if (collision.gameObject.tag == "Player")
    {
      audioSource.PlayOneShot(audioSource.clip);
      goalText.SetActive(true);

      if (scoreManeger.score >= minScore)
      {
        StartCoroutine(ExecuteAfterAudio(1.0f));
      }
      // Quit();
    }

  }
  private IEnumerator ExecuteAfterAudio(float delay)
  {
    yield return new WaitForSeconds(delay);
    Debug.Log("StartEye");
    StartEyeDetection();
  }
  //   void Quit()
  //   {
  //     // isGoal = true;
  // #if UNITY_EDITOR
  //       UnityEditor.EditorApplication.isPlaying = false;
  // #else
  //     Application.Quit();
  // #endif
  //   }
}
