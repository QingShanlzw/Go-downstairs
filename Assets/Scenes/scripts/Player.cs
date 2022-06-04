using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    GameObject current;
    [SerializeField] int Hp = 10;
    [SerializeField] GameObject Hpbar;
    [SerializeField] Text scoreText;
    [SerializeField] GameObject replayButton;
    //[SerializeField] GameObject scoreT;
    float timescore;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        timescore = 0f;
        score = 0;
        replayButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }
        updateScore();


    }

     void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag == "normal")
        {
            if(other.contacts[0].normal==new Vector2(0f, 1f))
            {
                Debug.Log("撞到了第一种标签");
                current = other.gameObject;
                ModifyHp(1);
            }
           
        }
         else if (other.gameObject.tag == "nail")
        {
            if (other.contacts[0].normal == new Vector2(0f, 1f))
            {
                Debug.Log("撞到了第二种标签");
                current = other.gameObject;
                ModifyHp(-1);
            }

           
        }
        else if (other.gameObject.tag == "ceiling")
        {
            Debug.Log("撞到了天花板");
            current.GetComponent<BoxCollider2D>().enabled = false;
            ModifyHp(-3);
        }

    }
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "deathLine")
        {
            Debug.Log("你输了");
            Die();
        }
    }
    void ModifyHp(int num)
    {
        Hp += num;
        if (Hp > 10)
        {
            Hp = 10;
        }
        if (Hp <= 0)
        {
            Hp = 0;
            Die();
        }
        updateHpbar();
    }
    void updateHpbar()
    {
        for(int i = 0; i < Hpbar.transform.childCount; i++)
        {
            if (Hp > i)
            {
                Hpbar.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                Hpbar.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
    void updateScore()
    {
        timescore += Time.deltaTime;
        if(timescore > 2f)
        {
            Debug.Log("time++");
            score++;
           // scoreT.transform.GetChild(scoreT.transform.childCount-1).transform.GetComponent<TextMeshProUGUI>().text= "the" + score.ToString() + "floor";
        }
    }
    void Die()
    {
        Time.timeScale = 0f;
        replayButton.SetActive(true);
    }
    public void Replay()
    {
        Time.timeScale = 1f;
        //重新载入某个场景
        SceneManager.LoadScene("SampleScene");
    }

}
