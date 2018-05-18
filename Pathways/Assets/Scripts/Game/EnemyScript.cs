using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    private EnemyLogic logic;

    public Rigidbody2D Rigidbody;

    // Use this for initialization
    void Start () {
        logic = new EnemyLogic();

        Rigidbody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(logic.newDirection() * Time.deltaTime * logic.newRotationSpeed(), Space.World);
        Rigidbody.velocity = -transform.up * logic.newSpeed() * Time.deltaTime;

        
    }

    
    
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("enemy collision");
        if (col.gameObject.tag == "Wall"|| col.gameObject.tag == "Enemy") {
            Rigidbody.velocity = Rigidbody.velocity * -1;
        }
    }
    
}


public class EnemyLogic {
    public string name;

    private float playerSpeed = 30f;
    private float rotateSpeed = 52f;

    public EnemyLogic() {
        name = "bob";
    }

    public float newSpeed() {
        Random.InitState(5656);
        return playerSpeed* Random.Range(playerSpeed/2, playerSpeed);
    }

    public float newRotationSpeed() {
        return rotateSpeed* randomFloat();
    }

    public Vector3 newDirection() {
        Random.InitState(42312);
        return new Vector3(0, 0,Random.Range(-1.0f, 1.0f));
    }

    public float randomFloat() {
        Random.InitState(476768);
        return Random.Range(-1.0f, 1.0f);
    }

}
