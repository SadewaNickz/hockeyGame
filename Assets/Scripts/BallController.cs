using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public int force;
    Rigidbody2D rigid;
    int scoreP1;
    int scoreP2;

    Text scoreUIP1;
    Text scoreUIP2;

    GameObject panelSelesai;
    Text txPemenang;

    // Tambahan: waktu bola stuck
    float stuckTimer = 0f;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(2, 0).normalized;
        rigid.AddForce(arah * force);

        scoreP1 = 0;
        scoreP2 = 0;

        scoreUIP1 = GameObject.Find("Score1").GetComponent<Text>();
        scoreUIP2 = GameObject.Find("Score2").GetComponent<Text>();

        panelSelesai = GameObject.Find("PanelSelesai");
        panelSelesai.SetActive(false);

        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayGameplayMusic();
        }
    }

    void Update()
    {
        // Cek jika bola stuck (kecepatan sangat rendah)
        if (rigid.linearVelocity.magnitude < 0.1f)
        {
            stuckTimer += Time.deltaTime;

            if (stuckTimer > 2f) // misalnya 2 detik diam
            {
                Debug.Log("Bola stuck, dorong ulang!");
                Vector2 arahAcak = new Vector2(Random.Range(-1f, 1f), Random.Range(-0.5f, 0.5f)).normalized;
                rigid.AddForce(arahAcak * force);
                stuckTimer = 0f;
            }
        }
        else
        {
            stuckTimer = 0f;
        }
        // ✅ Deteksi jika bola hanya gerak vertikal (X hampir 0)
        if (Mathf.Abs(rigid.linearVelocity.x) < 0.1f && Mathf.Abs(rigid.linearVelocity.y) > 0.1f)
        {
            Debug.Log("Bola gerak vertikal doang, tambah dorongan X!");
            Vector2 arahBaru = new Vector2(Random.Range(0.5f, 1f) * Mathf.Sign(Random.Range(-1f, 1f)), rigid.linearVelocity.y).normalized;
            rigid.linearVelocity = Vector2.zero;
            rigid.AddForce(arahBaru * force);
        }
        // Jika hanya horizontal (gerak kiri-kanan saja)
        if (Mathf.Abs(rigid.linearVelocity.y) < 0.1f && Mathf.Abs(rigid.linearVelocity.x) > 0.1f)
        {
            Vector2 arahBaru = new Vector2(rigid.linearVelocity.x, Random.Range(0.5f, 1f) * Mathf.Sign(Random.Range(-1f, 1f))).normalized;
            rigid.linearVelocity = Vector2.zero;
            rigid.AddForce(arahBaru * force);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "GoalKanan")
        {
            scoreP1 += 1;
            TampilkanScore();

            if (scoreP1 == 2)
            {
                panelSelesai.SetActive(true);
                txPemenang = GameObject.Find("Pemenang").GetComponent<Text>();
                txPemenang.text = "Player Biru Pemenang!";

                if (AudioManager.instance != null)
                {
                    AudioManager.instance.PlayGameOverMusic();
                }

                Destroy(gameObject);
                return;
            }

            ResetBall();
            Vector2 arah = new Vector2(2, 0).normalized;
            rigid.AddForce(arah * force);
        }

        if (coll.gameObject.name == "GoalKiri")
        {
            scoreP2 += 1;
            TampilkanScore();

            if (scoreP2 == 2)
            {
                panelSelesai.SetActive(true);
                txPemenang = GameObject.Find("Pemenang").GetComponent<Text>();
                txPemenang.text = "Player Merah Pemenang!";

                if (AudioManager.instance != null)
                {
                    AudioManager.instance.PlayGameOverMusic();
                }

                Destroy(gameObject);
                return;
            }

            ResetBall();
            Vector2 arah = new Vector2(-2, 0).normalized;
            rigid.AddForce(arah * force);
        }

        if (coll.gameObject.name == "Pemukul1" || coll.gameObject.name == "Pemukul2")
        {
            float sudut = (transform.position.y - coll.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rigid.linearVelocity.x, sudut).normalized;
            rigid.linearVelocity = Vector2.zero;
            rigid.AddForce(arah * force * 2);
        }
    }

    void ResetBall()
    {
        transform.localPosition = Vector2.zero;
        rigid.linearVelocity = Vector2.zero;
    }

    void TampilkanScore()
    {
        Debug.Log("Score P1: " + scoreP1 + " Score P2: " + scoreP2);
        scoreUIP1.text = scoreP1.ToString();
        scoreUIP2.text = scoreP2.ToString();
    }
}
