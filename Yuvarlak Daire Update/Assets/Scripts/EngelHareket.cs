using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EngelHareket : MonoBehaviour
{
    public SpriteRenderer srr;
    public Color colorMavi;
    public Color colorSar�;
    public Color colorMor;
    public Color colorPembe;
    public float startX = 0f;
    public float endX = 5f;
    private float hiz = 5;
    private bool bittiMi = true;
    private Vector3 startPosition;
    private Vector3 endPosition;
    public string currentColor;
    private Instantiate instantiate;
    public int rastgele_sayi;

    void Start()
    {
        rastgele_sayi = Random.Range(2, 10);
        instantiate = FindObjectOfType<Instantiate>();
        srr = GetComponent<SpriteRenderer>();
        SetRandomColor();
        Color eskiRenk = srr.color; // Mevcut rengi al
        float yeniAlfaDegeri = 1f; // Yeni alfa de�eri, 0 (tamamen �effaf) ile 1 (tamamen opak) aras�nda olmal�d�r
        Color yeniRenk = new Color(eskiRenk.r, eskiRenk.g, eskiRenk.b, yeniAlfaDegeri); // Alfa de�erini de�i�tirilmi� renk olu�tur
        srr.color = yeniRenk; // Nesnenin rengini g�ncelle
        startPosition = new Vector3(startX, transform.position.y, transform.position.z);
        endPosition = new Vector3(endX, transform.position.y, transform.position.z);
        transform.position = startPosition;
    }

    void Update()
    {

        // Hareket y�n�n� belirleme
        Vector3 hareket = bittiMi ? startPosition : endPosition;

        // Hedefe do�ru hareket etme (sadece x ekseni �zerinde)
        float step = rastgele_sayi * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, hareket, step);

        // Hedefe ula��ld���nda y�n� tersine �evirme
        if (transform.position == hareket)
        {
            bittiMi = !bittiMi;
        }
    }
    private void SetRandomColor()
    {
        int index = Random.Range(0, 3);
        switch (index)
        {
            case 0:
                srr.color = colorMavi;
                currentColor = "Mavi";
                tag = "Mavi";

                break;
            case 1:
                srr.color = colorSar�;
                currentColor = "Sar�";
                tag = "Sar�";

                break;
            case 2:
                srr.color = colorMor;
                currentColor = "Mor";
                tag = "Mor";
                break;
            case 3:
                srr.color = colorPembe;
                currentColor = "Pembe";
                tag = "Pembe";

                break;
        }

    }
}
