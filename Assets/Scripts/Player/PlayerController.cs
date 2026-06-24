using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public InputHandler Input {get; private set;}
    public Rigidbody Rb {get; private set;}
    public HSM<PlayerController> Hsm {get; private set;}
    private StateFactory<PlayerController> stateFactory;

    public PlayerStats Stats;

    void Awake()
    {
        Input = GetComponent<InputHandler>();
        Rb = GetComponent<Rigidbody>();
        stateFactory = new(this);
        Hsm = new (this, stateFactory.Get<GroundedState>()); 
    }

    // Update is called once per frame
    void Update()
    {
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
