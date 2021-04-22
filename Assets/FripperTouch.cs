using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperTouch : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
        int touchCount = Input.touchCount;

        for (int i = 0; i < touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            switch (touch.phase)
            {
                case TouchPhase.Began: // 画面に指が触れた時に行いたい処理をここに書く

                    //画面の左側をタップしたら左のフリッパーが動く
                    if ((touch.position.x <= Screen.width / 2) && (touch.phase == TouchPhase.Began && tag == "LeftFripperTag"))
                    {
                        SetAngle(this.flickAngle);
                    }

                    //画面の右側をタップしたら右のフリッパーが動く
                    if ((touch.position.x >= Screen.width / 2) && (touch.phase == TouchPhase.Began && tag == "RightFripperTag"))
                    {
                        SetAngle(this.flickAngle);
                    }
                    break;

                case TouchPhase.Ended: // 画面から指が離れた時に行いたい処理をここに書く

                    // 画面の左側を離したら左のフリッパーが戻る
                    if ((touch.position.x <= Screen.width / 2) && (touch.phase == TouchPhase.Ended && tag == "LeftFripperTag"))
                    {
                        SetAngle(this.defaultAngle);
                    }

                    // 画面の右側を離したら右のフリッパーが戻る
                    if ((touch.position.x >= Screen.width / 2) && (touch.phase == TouchPhase.Ended && tag == "RightFripperTag"))
                    {
                        SetAngle(this.defaultAngle);
                    }
                    break;
            }
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
