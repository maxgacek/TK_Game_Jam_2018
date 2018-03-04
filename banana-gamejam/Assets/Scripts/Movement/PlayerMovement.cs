using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class PlayerMovement : MonoBehaviour
{
	public Rigidbody body;
	public float movementSpeed = 1.0f;
    public float jumpPower = 1.0f;
	public float fallMltp = 2.0f;
	public float gravityForceMltp = 0.25f;

	public string xAxisCode = "Horizontal";
	public string yAxisCode = "Vertical";
	public string jumpAxisCode = "Fire1";
    public string powerAxisCode = "Fire2";

	public ResourceController energy;
	public float powerCost;

	public PushOnCollision3D cast;
    public GameObject Flame;
    public GameObject particles;

	bool onFlyInit = false;
	bool onFly = false;  
	bool fallCasted = true;

    public AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip powerSound;
    public AudioClip hurtSound;

    bool hasPlayed;

    void Start()
    {
        if (body == null)
            body = GetComponent<Rigidbody>();
    }

    Vector3 lastInputRotation;
	Vector3 input;

	private void Update()
	{
		input = new Vector3(Input.GetAxis(xAxisCode), 0, Input.GetAxis(yAxisCode)).normalized;

		body.WakeUp();
    }

	void FixedUpdate()
    {
		if ((input.x != 0 || input.z != 0))
			lastInputRotation = input;

		if (Input.GetButton("Cancel"))
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

		if (onFlyInit)
		{
			body.AddForce(input * movementSpeed * Time.fixedDeltaTime);
			body.AddForce(Vector3.up * jumpPower * Time.fixedDeltaTime);
		}
		onFlyInit = false;

		if (onFly)
		{
            

            body.AddForce(-Vector3.up * jumpPower * gravityForceMltp * Time.fixedDeltaTime);
			if (fallCasted)
				body.AddForce(Vector3.down * (jumpPower * fallMltp) * Time.fixedDeltaTime);

            else if (Input.GetButtonDown(powerAxisCode) && energy.Spend(powerCost))
			{
                
                Instantiate(particles, body.transform.position, Quaternion.identity);
				fallCasted = true;
				cast.activate();

                audioSource.PlayOneShot(powerSound);

            }

        }

		body.rotation = Quaternion.Euler(0, Vector3.Angle(-Vector3.forward, lastInputRotation) * (lastInputRotation.x > 0 ? -1 : 1), 0);
    }   

    private void OnCollisionStay(Collision col)
    {
		if (col.gameObject.tag != "Wall")
		{
			onFly = onFlyInit = Input.GetButton(jumpAxisCode);
			fallCasted = !onFly;

            if(Input.GetButton(jumpAxisCode))
                audioSource.PlayOneShot(jumpSound);

        }

        if(col.gameObject.tag == "bullet")
        {
            audioSource.PlayOneShot(hurtSound);
        }
    }
}