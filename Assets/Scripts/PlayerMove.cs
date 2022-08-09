using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
	private	VirtualJoystick	virtualJoystick;
    public float moveSpeed = 5.0f;
    private Rigidbody2D rigid2D;
    // Update is called once per frame

    private void Awake() {
        rigid2D = GetComponent<Rigidbody2D>();    
    }
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        float jx = virtualJoystick.Horizontal;
        float jy = virtualJoystick.Vertical;

        if(x > 0 || jx > 0){
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if(x < 0 || jx < 0){
            GetComponent<SpriteRenderer>().flipX = false;
        }

        // transform.position += moveDirection * moveSpeed * Time.deltaTime;
        // moveDirection = new Vector3(x, y, 0);

        rigid2D.velocity = new Vector3(x, y, 0) * moveSpeed;
        transform.position += new Vector3(jx, jy, 0) * moveSpeed * Time.deltaTime;

    }
}
