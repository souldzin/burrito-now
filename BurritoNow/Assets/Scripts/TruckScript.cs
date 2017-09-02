using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckScript : MonoBehaviour {
    const string ANIMATION_FIRE = "fire";

    public float speed = 1.0f;
    public Vector2 direction = Vector2.up;
    public GameObject burritoPrefab;

    private Vector3 _initialPosition;
    private SkeletonAnimation _skeletonAnimation;

	// Use this for initialization
	void Start ()
    {
        _initialPosition = this.transform.position;
        _skeletonAnimation = this.GetComponent<SkeletonAnimation>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 translate = direction * speed * Time.deltaTime;

        this.transform.Translate(translate);
	}

    public void ShootBurrito()
    {
        Debug.Log("You burritoed!");
        PlayShootAnimation();
        CreateBurrito();
    }

    public void Die ()
    {
        Debug.Log("You died!");
        this.transform.SetPositionAndRotation(_initialPosition, Quaternion.identity);
    }

    // ShootBurrito helpers
    // ----------------

    private void CreateBurrito()
    {
        var position = transform.position;
        var rotation = transform.rotation;
        var burrito = Instantiate(burritoPrefab, position, rotation);
    }

    private void PlayShootAnimation()
    {
        _skeletonAnimation.state.AddAnimation(1, ANIMATION_FIRE, false, 0);
    }
}
