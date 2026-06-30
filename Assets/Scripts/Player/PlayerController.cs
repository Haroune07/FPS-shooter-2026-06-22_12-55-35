using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private InputHandler _inputHandler;
    private StateFactory<PlayerController> _stateFactory;
    public InputData Input {get; private set;}
    public Rigidbody Rb {get; private set;}
    public HSM<PlayerController> Hsm {get; private set;}
    [field : SerializeField] public PlayerStats Stats {get; private set;}
    public IMover Mover {get;private set;}

    void Awake()
    {
        transform.localScale = Stats.standingScale;
        _inputHandler = GetComponent<InputHandler>();
        Rb = GetComponent<Rigidbody>();
        Mover = new StandardMover(this);
        _stateFactory = new(this);
        Hsm = new (this, _stateFactory.Get<GroundedState>()); 
    }

    // Update is called once per frame
    void Update()
    {
        Input = new (_inputHandler);
        Hsm.Update(Time.deltaTime);
    }

    void FixedUpdate()
    {
        Hsm.FixedUpdate(Time.fixedDeltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        Hsm.OnTriggerEnter(other);
    }

    void OnTriggerStay(Collider other)
    {
        Hsm.OnTriggerStay(other);
    }

    void OnTriggerExit(Collider other)
    {
        Hsm.OnTriggerExit(other);        
    }

    public bool Grounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, Stats.groundRayCastDist);
    }

    public bool IsOnSlope()
    {
        Vector3 normal = Vector3.up;
        if(Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, Stats.groundRayCastDist))
            normal = hit.normal;
        return normal != Vector3.up;
    }
}
