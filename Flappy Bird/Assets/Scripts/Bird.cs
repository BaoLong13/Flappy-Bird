using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody2D birdRigidBody;
    private Transform birdTransform;

    private const float JUMPAMOUNT = 4.5f;

    public int currX = 2;
    
    private void Awake()
    {
        birdRigidBody = GetComponent<Rigidbody2D>();
        birdTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump(new Vector2(0,1));
        } 
    }

    private void FixedUpdate()
    {
        Move(currX);
    }

    public void Jump(Vector2 jumpDir)
    {
        birdRigidBody.velocity = jumpDir * JUMPAMOUNT;
    }

    public void Move(int horizontalDir)
    {
        birdRigidBody.AddForce(new Vector2(horizontalDir, 0));
    }

    public void ResetBird()
    {
        birdTransform.position = new Vector2(0, 0);
        gameObject.SetActive(true);
        currX = 2;
        gameObject.GetComponent<SpriteRenderer>().flipX = false;
    }

    public void KillBird()
    {
        gameObject.SetActive(false);
    }
}
