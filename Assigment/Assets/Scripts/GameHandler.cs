using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
  [SerializeField] float loadDelay = 1f;
  [SerializeField] ParticleSystem hitEffect;
  LevelManager lm;

  void Start() 
  {
    lm = FindObjectOfType<LevelManager>();
  }
  void Update() 
  {
    if(transform.position.y >= 3.7 )
    {
    lm.LoadFinsih();
    }
  }
void OnCollisionEnter2D(Collision2D other)
  {
    LoseSequence();
  }

  void LoseSequence()
  {
   GetComponent<PlayerControls>().enabled = false;
   PlayHitEffect();
   Invoke("ReloadLevel",loadDelay);
  }
  void ReloadLevel()
  {
   int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
   SceneManager.LoadScene(currentSceneIndex);
  }
  void PlayHitEffect()
  {
    ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
    Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
  }
}

