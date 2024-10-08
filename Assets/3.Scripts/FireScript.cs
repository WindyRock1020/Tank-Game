using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour {

	public Rigidbody projectile;//砲彈
	public float speed = 80;//砲彈的飛行速度


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//獲取Ctrl與滑鼠左鍵的按鍵
		//判斷是否按下按鍵
		if(Input.GetButtonDown("Fire1"))
		{
			//產生砲彈在發射點
			Rigidbody shoot = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;  
			//給砲彈方向力，將他從Z軸推出去
			shoot.velocity = transform.TransformDirection(new Vector3( 0, 0, speed));
			//讓坦克的碰撞框忽略砲彈的碰撞框
			Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), shoot.GetComponent<Collider>());
		}
	}
}
