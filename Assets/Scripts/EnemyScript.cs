using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public int hp = 5;

	void Update () {
		if(hp <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
