using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    //ゲームオーバを表示するテキスト
    private GameObject scoreText;

    public int totalscore = 0; 　// 合計点数

    void Start()
    {
      //シーン中のGameOverTextオブジェクトを取得
      this.scoreText = GameObject.Find("scoreText");

    }

    //ボール接触時に点を獲得する
    void OnCollisionEnter(Collision collision)
    {
        {

            // タグ別に点数を獲得する
            if (collision.gameObject.tag == "SmallStarTag")
            {
                totalscore += 10;
            }

            else if (collision.gameObject.tag == "LargeStarTag")
            {
                totalscore += 20;
            }

            else if (collision.gameObject.tag == "SmallCloudTag")
            {
                totalscore += 30;
            }

            else if (collision.gameObject.tag == "LargeCloudTag")
            {
                totalscore += 40;
            }

            Debug.Log(totalscore);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //scoreTextに合計点数を表示
        this.scoreText.GetComponent<Text>().text = totalscore + "点";
    }
}