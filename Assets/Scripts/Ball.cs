using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    public GameManager gameManager;
    public float speed = 500f;
    public float maxVelocity = 15f;

    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        this.gameManager = FindObjectOfType<GameManager>();
        this.gameManager.UpdateScore();
        this.speed += (this.gameManager.level / 7) * 100;
        this.maxVelocity += (this.gameManager.level / 7) * 15;
        ResetBall();
    }

    private void Update()
    {
        if(this.rigidbody.velocity.magnitude > maxVelocity) {
            this.rigidbody.velocity = Vector3.ClampMagnitude(this.rigidbody.velocity, maxVelocity);
        }
    }

    private void SetRandomTrajectory()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;

        this.rigidbody.AddForce(force.normalized * this.speed);
    }

    public void ResetBall()
    {
        this.transform.position = Vector2.zero;
        this.rigidbody.velocity = Vector2.zero;

        Invoke(nameof(SetRandomTrajectory), 1f);
    }
}
