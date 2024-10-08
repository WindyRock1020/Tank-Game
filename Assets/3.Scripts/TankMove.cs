using UnityEngine;
using System.Collections;

public class TankMove : MonoBehaviour {

	public float mSpeed = 1;//移動速度
	public float rSpeed = 1;//旋轉速度

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var h = Input.GetAxis("Horizontal");//獲取水平軸向按鍵
		var v = Input.GetAxis("Vertical");//獲取垂直軸向按鍵
		
		transform.Translate(0,0,mSpeed * -v);//根據水平軸向按鍵來前進或後退
		transform.Rotate(0,rSpeed * h,0);//根據垂直軸向按鍵來旋轉
	}
}
