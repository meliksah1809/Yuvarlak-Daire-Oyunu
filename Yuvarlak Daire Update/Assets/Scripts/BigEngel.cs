using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEngel : MonoBehaviour
{
    public SpriteRenderer srr;
    public Color colorMavi;
    public Color colorSarý;
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
    public int sonuc_sayi;
    public Color sonuc_renk;
    public string sonuc_tag;
    public string sonuc_currentcolor;


    void Start()
    {
        rastgele_sayi = Random.Range(2, 5) ;
        sonuc_sayi = rastgele_sayi;
        instantiate = FindObjectOfType<Instantiate>();
        srr = GetComponent<SpriteRenderer>();
        SetRandomColor();
        sonuc_renk = srr.color;
        Color eskiRenk = srr.color; // Mevcut rengi al
        float yeniAlfaDegeri = 1f; // Yeni alfa deðeri, 0 (tamamen þeffaf) ile 1 (tamamen opak) arasýnda olmalýdýr
        Color yeniRenk = new Color(eskiRenk.r, eskiRenk.g, eskiRenk.b, yeniAlfaDegeri); // Alfa deðerini deðiþtirilmiþ renk oluþtur
        srr.color = yeniRenk; // Nesnenin rengini güncelle
        startPosition = new Vector3(startX, transform.position.y, transform.position.z);
        endPosition = new Vector3(endX, transform.position.y, transform.position.z);
        transform.position = startPosition;
    }

    void Update()
    {

        // Hareket yönünü belirleme
        Vector3 hareket = bittiMi ? startPosition : endPosition;

        // Hedefe doðru hareket etme (sadece x ekseni üzerinde)
        float step = rastgele_sayi * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, hareket, step);

        // Hedefe ulaþýldýðýnda yönü tersine çevirme
        if (transform.position == hareket)
        {
            bittiMi = !bittiMi;
        }
    }
    public void SetRandomColor()
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
                srr.color = colorSarý;
                currentColor = "Sarý";
                tag = "Sarý";

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
