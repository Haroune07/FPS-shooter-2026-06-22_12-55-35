using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private InputHandler _input;    
    public InputData Input {get;set;}
    public Rigidbody Rb {get; private set;}
    public HSM<PlayerController> Hsm {get; private set;}
    private StateFactory<PlayerController> stateFactory;
    public PlayerStats Stats;

    void Awake()
    {
        _input = GetComponent<InputHandler>();
        Rb = GetComponent<Rigidbody>();
        stateFactory = new(this);
        Hsm = new (this, stateFactory.Get<GroundedState>()); 
    }

    // Update is called once per frame
    void Update()
    {
        Input = new (_input.Move, _input.Look, _input.JumpThisFrame, _input.Sprint, _input.CrouchThisFrame, _input.HoldCrouch);
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

}
