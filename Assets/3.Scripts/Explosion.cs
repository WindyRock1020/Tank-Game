using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	public GameObject explosion;//爆炸特效

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//碰撞偵測
	void OnCollisionEnter(Collision collision) 
	{
		//碰撞後產生爆炸
		var expFx = Instantiate (explosion, transform.position, transform.rotation);
        //刪除爆炸
        Destroy(expFx, 5); ;
        //刪除砲彈
        Destroy(gameObject);
	}
}
