using UnityEngine;
using System.Collections;
using UnityEngine.VR;     // enable to get HMD direction
public class CameraControll : MonoBehaviour {
    public GameObject tmp;
    void Start()
    {
        
    }
    void Update()
    {
        // TODO: ここで固定したい位置があれば指定しておく
        Vector3 basePos = Vector3.zero;
      //  Quaternion baseRote = Quaternion.EulerAngles(0, 0, 0);
        basePos.y = 10;

        // VR.InputTracking から hmd の位置を取得
        Vector3 trackingPos =
                UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.CenterEye);

       //Quaternion trackingRote= UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.CenterEye);
        // CameraController 自体の rotation が
        // zero でなければ rotation を掛ける
        // trackingPosition = trackingPos * transform.rotation;

        // 固定したい位置から hmd の位置を
        // 差し引いて実質 hmd の移動を無効化する
        transform.position = basePos - trackingPos;
        transform.LookAt(tmp.transform);

    }

}