using Animancer;
using System;
using UnityEngine;

public class Square : MonoBehaviour {
    AnimancerComponent animancer;

    // this animation loops and is treated like the default animation
    [SerializeField] AnimationClip idleAnimation;
    // this animation doesn't loop and is played once when user input is received (e.g., key press)
    [SerializeField] AnimationClip attackAnimation;

    void OnEnable() {
        animancer = GetComponent<AnimancerComponent>();
    }

    void Start() {
        // idle animation should play by default until player acts
        animancer.Play(idleAnimation);
    }

    void Update() {
        // check user input
        if (Input.GetKeyDown("space")) {
            Attack();
        }
    }

    void Attack() {
        // prevent function from being called again until the attack animation has ended
        if (animancer.States.Current.Clip == attackAnimation) return;

        // play attack animation, then return to idle animation when finished
        AnimancerState state = animancer.Play(attackAnimation);
        state.Events.OnEnd = () => animancer.Play(idleAnimation);

        // other things are normally done here but have been omitted for the sake of example
    }

    // made public so Unity's Animation Events can call this
    public void FireEvent() {
        Debug.Log("Fire the event!");
    }
}
