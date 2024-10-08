using UnityEngine;
using System.Collections;

public class TankTrack : MonoBehaviour {

	public float mSpeed = 1;
	public float rSpeed = 1;
	
	public Transform tower;
	public float towerSpeed = 1;
	
	public Transform barrel;
	public float barrelSpeed = 1;
	public float maxAngle = 25;
	public float minAngle = -5;

	private float angle;
	
	public Renderer trackL;//左履帶
	public Renderer trackR;//右履帶
	public float trackSpeed = 0.02f;//履帶轉動速度

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		var h = Input.GetAxis("Horizontal");
		var v = Input.GetAxis("Vertical");			
		
		transform.Translate(0,0,mSpeed * -v);
		transform.Rotate(0,rSpeed * h,0);

        var x = Input.GetAxis("Mouse X");
        tower.Rotate(0, 0, towerSpeed * x);

        angle += Input.GetAxis("Mouse ScrollWheel") * barrelSpeed;
        angle = Mathf.Clamp(angle, minAngle, maxAngle);

        Vector3 barrelAngle = barrel.localEulerAngles;
        barrelAngle.x = angle;
        barrel.localEulerAngles = barrelAngle;

        //根據垂直軸向按鍵來決定執行:前或後的程式
        //:前，依據垂直軸向按鍵來決定履帶是向前或向後轉動
        //:後，依據水平軸向按鍵來決定左右履帶的轉動方向
        Vector2 trackLOffset = trackL.material.mainTextureOffset;
		trackLOffset.x += v != 0 ? trackSpeed * v : trackSpeed * h; 
		trackL.material.mainTextureOffset = trackLOffset;

		Vector2 trackROffset = trackR.material.mainTextureOffset;
		trackROffset.x += v != 0 ? trackSpeed * v : trackSpeed * -h;
		trackR.material.mainTextureOffset = trackROffset;
	}
}
