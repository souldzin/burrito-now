using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckScript : MonoBehaviour {
    const string ANIMATION_FIRE = "fire";
    const float BURRITO_FIRE_SPEED = 12.0f;
    private Vector3 CANNON_POSITION = new Vector3(1.2f, -0.2f);

    public Vector3 velocity = new Vector2(0, 1.0f);
    public float rotationSpeed = 60.0f;
    public GameObject burritoPrefab;

    private Vector3 _initialPosition;
    private SkeletonAnimation _skeletonAnimation;

    // Methods
    // ----------------------

	// Use this for initialization
	void Start ()
    {
        _initialPosition = this.transform.position;
        _skeletonAnimation = this.GetComponent<SkeletonAnimation>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 translate = velocity * Time.deltaTime;

        this.transform.Translate(translate);
	}

    public void ShootBurrito()
    {
        PlayShootAnimation();
        CreateBurrito();
    }

    public void Die ()
    {
        Debug.Log("You died!");
        this.transform.SetPositionAndRotation(_initialPosition, Quaternion.identity);
    }

    public void TurnLeft()
    {
        Turn(Quaternion.Euler(0.0f, 0.0f, 1.0f));
    }

    public void TurnRight()
    {
        Turn(Quaternion.Euler(0.0f, 0.0f, -1.0f));
    }

    public void Turn(Quaternion rotateTo)
    {
        this.transform.Rotate(rotateTo.eulerAngles * rotationSpeed);
    }

    // ShootBurrito helpers
    // ----------------

    private void CreateBurrito()
    {
        // get burrito position to vehicle
        var position = transform.position + (transform.rotation * CANNON_POSITION);

        // get burrito rotation to vehicle
        var rotation = Quaternion.Euler(0, 0, 90) * transform.rotation;

        // create
        CreateBurrito(position, rotation);
    }

    private void CreateBurrito(Vector3 position, Quaternion rotation)
    {
        var burrito = GameObject.Instantiate(burritoPrefab, position, rotation, null);
        var script = burrito.GetComponent<BurritoScript>();
        if(script != null)
        {
            var fireVelocity = (Vector3.right * BURRITO_FIRE_SPEED);
            var burritoVelocity = Quaternion.Euler(0, 0, -90) * (this.velocity + fireVelocity);
            script.Initialize(burritoVelocity);
        }
    }

    private void PlayShootAnimation()
    {
        _skeletonAnimation.state.AddAnimation(1, ANIMATION_FIRE, false, 0);
    }
}
