using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarretController : MonoBehaviour {
    public Vector3 acceleration;//加速度
    public float m_speed;
    public Vector3 initPos;
    public GameObject Tracker;

    Vector3 currentPos;
	// Use this for initialization
	void Start () {
        currentPos = this.gameObject.transform.position;
        initSet();
    }
	
	// Update is called once per frame
	void Update () {
            m_speed=((this.gameObject.transform.position-currentPos)/Time.deltaTime).magnitude;
            acceleration = (this.gameObject.transform.position - currentPos) ;
            currentPos = this.gameObject.transform.position;

        Vector3 tmp = Tracker.transform.position;
        tmp *= 10;
        this.gameObject.transform.position = tmp;
    }

    /// <summary>
    /// ここからドラッグ
    /// </summary>
    private Vector3 screenPoint;
    private Vector3 offset;

    void OnMouseDown()
    {
        //カメラから見たオブジェクトの現在位置を画面位置座標に変換
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        //取得したscreenPointの値を変数に格納
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;

        //オブジェクトの座標からマウス位置(つまりクリックした位置)を引いている。
        //これでオブジェクトの位置とマウスクリックの位置の差が取得できる。
        //ドラッグで移動したときのずれを補正するための計算だと考えれば分かりやすい
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(x, y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        //ドラッグ時のマウス位置を変数に格納
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;

       // Debug.Log(x.ToString() + " - " + y.ToString());

        //ドラッグ時のマウス位置をシーン上の3D空間の座標に変換する
        Vector3 currentScreenPoint = new Vector3(x, y, screenPoint.z);

        //上記にクリックした場所の差を足すことによって、オブジェクトを移動する座標位置を求める
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + offset;

        //オブジェクトの位置を変更する
        transform.position = currentPosition;
    }
    public void initSet()
    {
        initPos = this.gameObject.transform.position;
    }
}
