using UnityEngine;
using System.Collections;

public class TankTower : MonoBehaviour {

	public float mSpeed = 1;
	public float rSpeed = 1;
	
	public Transform tower;//砲塔
	public float towerSpeed = 1;//砲塔旋轉速度
	
	public Transform barrel;//砲管基座
	public float barrelSpeed = 1;//砲管基座仰角變換速度
	public float maxAngle = 25;//仰角上限值
	public float minAngle = -5;//仰角下限值

	private float angle;//紀錄仰角的角度

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var h = Input.GetAxis("Horizontal");
		var v = Input.GetAxis("Vertical");		
		
		transform.Translate(0,0,mSpeed * -v);
		transform.Rotate(0,rSpeed * h,0);

        var x = Input.GetAxis("Mouse X");//獲取滑鼠水平移動的軸向
        tower.Rotate(0, 0, towerSpeed * x);//根據滑鼠水平移動的軸向來旋轉砲塔

        angle += Input.GetAxis("Mouse ScrollWheel") * barrelSpeed;//獲取滑鼠滾輪軸向
        angle = Mathf.Clamp(angle, minAngle, maxAngle);//限制仰角的角度在範圍內

        Vector3 barrelAngle = barrel.localEulerAngles;
        barrelAngle.x = angle;
        barrel.localEulerAngles = barrelAngle;//根據仰角角度來改變砲管基座的X軸
    }
}
