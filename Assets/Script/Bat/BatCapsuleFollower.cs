using UnityEngine;

public class BatCapsuleFollower : MonoBehaviour
{
    public ParticleSystem NovaExp;

    private BatCapsule _batFollower;
	private Rigidbody _rigidbody;
	private Vector3 _velocity;

	[SerializeField]
	private float _sensitivity = 100f;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		Vector3 destination = _batFollower.transform.position;
		_rigidbody.transform.rotation = transform.rotation;

		_velocity = (destination - _rigidbody.transform.position) * _sensitivity;

		_rigidbody.velocity = _velocity;
		transform.rotation = _batFollower.transform.rotation;
	}

	public void SetFollowTarget(BatCapsule batFollower)
	{
		_batFollower = batFollower;
	}

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.collider.tag);

        if (collision.collider.tag == "projectile")
        {
            NovaExp.Stop();
            NovaExp.time = 0;
            NovaExp.Play(true);
            collision.collider.GetComponent<BallManager>().changeActivePlayer(transform);
        }
    }
}