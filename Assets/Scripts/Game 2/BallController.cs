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
        if (rigid.linearVelocity.magnitude < 0.1f)
        {
            stuckTimer += Time.deltaTime;

            if (stuckTimer > 2f)
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

        if (Mathf.Abs(rigid.linearVelocity.x) < 0.1f && Mathf.Abs(rigid.linearVelocity.y) > 0.1f)
        {
            Vector2 arahBaru = new Vector2(Random.Range(0.5f, 1f) * Mathf.Sign(Random.Range(-1f, 1f)), rigid.linearVelocity.y).normalized;
            rigid.linearVelocity = Vector2.zero;
            rigid.AddForce(arahBaru * force);
        }

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

            ResetBall();
            Vector2 arah = new Vector2(2, 0).normalized;
            rigid.AddForce(arah * force);
        }

        if (coll.gameObject.name == "GoalKiri")
        {
            scoreP2 += 1;
            TampilkanScore();

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

    // Tambahan: fungsi untuk akhir permainan berdasarkan waktu
    public void CekPemenangSaatWaktuHabis()
    {
        panelSelesai.SetActive(true);
        txPemenang = GameObject.Find("Pemenang").GetComponent<Text>();

        if (scoreP1 > scoreP2)
        {
            txPemenang.text = "Player Biru Pemenang!";
        }
        else if (scoreP2 > scoreP1)
        {
            txPemenang.text = "Player Merah Pemenang!";
        }
        else
        {
            txPemenang.text = "Permainan Seri!";
        }

        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayGameOverMusic();
        }

        Destroy(gameObject);
    }
}
