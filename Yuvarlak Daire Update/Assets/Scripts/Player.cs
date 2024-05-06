using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public int skor = 0;
    int maxSkor;
    public TextMeshProUGUI max_ScoreText;
    public Rigidbody2D rb;
    public float JumpForce;
    public SpriteRenderer sr;
    public Color colorMavi;
    public Color colorSarý;
    public Color colorMor;
    public Color colorPembe;
    public string currentColor;
    private string ColorChanger;
    TextMeshProUGUI skor_text;
    public AudioSource audioSource;
    public AudioSource audioSource2;
    TextMeshProUGUI max_Score;
    public float maxJumpHeight;
    private bool ziplamatekrar = true;

    private void Start()
    {
        skor_text = GameObject.Find("Canvas/Score").GetComponent<TextMeshProUGUI>();
        max_Score = GameObject.Find("Canvas/MaxScore").GetComponent<TextMeshProUGUI>();
        maxSkor = PlayerPrefs.GetInt("MaxSkor", 0);
        max_ScoreText.text = "Max Skor: " + maxSkor.ToString();
        SetRandomColor();
        rb.bodyType = RigidbodyType2D.Static;
    }
    private void Update()
    {
        // Dokunmatik ekran týklamalarýný kontrol et
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Ýlk dokunmatik ekran giriþini alýn (diðerleri de düþünülmelidir)
                                             // Dokunmatik ekranýn týklama (basma) anýnda

            if (touch.phase == TouchPhase.Began /*Input.GetKeyDown(KeyCode.Space)*/)
            {
                rb.velocity = Vector2.up * JumpForce;
                audioSource.Play();

            }
            if (rb.bodyType == RigidbodyType2D.Static)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
            }


            //if (transform.position.y > initialYPosition + 2) 
            //{
            //    rb.velocity = Vector2.zero;
            //    ziplamatekrar = true;
            }
            if (transform.position.y <= -7)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
       // }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ColorChanger"))
        {
            audioSource2.Play();
            skor += 10;
            Color textColor = skor_text.color;
            Color eskiRenk = sr.color;
            Color yeniRenk;
            do
            {
                yeniRenk = SetRandomColor();
            } while (yeniRenk == eskiRenk && yeniRenk == textColor);
            skor_text.color = yeniRenk;
            skor_text.text = skor.ToString();
            if (skor > maxSkor)
            {
                maxSkor = skor;
                max_Score.text = maxSkor.ToString();
                PlayerPrefs.SetInt("MaxSkor", maxSkor);
            }

        }
        if (!collision.CompareTag(currentColor) && !collision.CompareTag("ColorChanger"))
        {

            Debug.Log("gameover");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    private Color SetRandomColor()
    {
        int index = Random.Range(0, 4);
        switch (index)
        {
            case 0:
                sr.color = colorMavi;
                currentColor = "Mavi";
                return colorMavi;
            case 1:
                sr.color = colorSarý;
                currentColor = "Sarý";
                return colorSarý;
            case 2:
                sr.color = colorMor;
                currentColor = "Mor";
                return colorMor;
            case 3:
                sr.color = colorPembe;
                currentColor = "Pembe";
                return colorPembe;
            default:
                return Color.white;
        }
    }

}
