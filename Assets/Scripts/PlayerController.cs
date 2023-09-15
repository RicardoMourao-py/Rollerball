using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public PlayAgain PlayAgainScreen;
    private float timeLeft; // Tempo restante
    private bool isGameOver; // Indicador de término do jogo
    public float gameTime = 60.0f; // Duração total do jogo em segundos
    public Text timeText;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    public void PlayAgain()
    {
        PlayAgainScreen.Setup(count);
    }

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = gameTime;
        isGameOver = false;
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void SetCountText()
    {
        countText.text = "Points: " + count.ToString();
        if(count >= 6)
        {
            winTextObject.SetActive(true); // TODO: verificar como aparecer na tela
            PlayAgain();       // TODO: mudar lógica se houver tempo
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;

            SetCountText();
        }
        
    }

    void Update()
    {
        if (!isGameOver)
        {
            timeLeft -= Time.deltaTime;

            // Verifica se o tempo acabou
            if (timeLeft <= 0)
            {
                timeLeft = 0;
                isGameOver = true;
                PlayAgain(); 
            }

            // Atualiza o texto da UI
            timeText.text = "Time: " + Mathf.Round(timeLeft);
        }
    }

}