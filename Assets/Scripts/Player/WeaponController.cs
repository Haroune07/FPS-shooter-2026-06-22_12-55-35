using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public HSM<WeaponController> StateMachine {get; private set;}
    public PlayerController PlayerController {get; private set;}
    public StateFactory<WeaponController> StateFactory {get; private set;}
    public int CurrentAmmo {get; set;}
    public bool HasAmmo => CurrentAmmo > 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerController = GetComponentInParent<PlayerController>();
        StateFactory = new(this);
        StateMachine = new(this, StateFactory.Get<WeaponIdleState>());
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine.Update(Time.deltaTime);
    }

    void FixedUpdate()
    {
        StateMachine.FixedUpdate(Time.fixedDeltaTime);
    }
}
