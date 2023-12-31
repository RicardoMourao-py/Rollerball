using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent agent;
    public PlayerController playerController;
    public PlayAgain PlayAgainScreen;
    private AudioSource pop;

    public void PlayAgain()
    {
        PlayAgainScreen.Setup(playerController.count);
    }

    void Start()
    {
        pop = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        agent.destination = target.transform.position;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            pop.Play();
            PlayAgain();
    }
}
