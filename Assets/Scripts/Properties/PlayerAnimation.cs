using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAnimation : MonoBehaviour {
    public List<AudioObject> AttackClips = new List<AudioObject>();
    public List<AudioObject> HitClips = new List<AudioObject>();
    public AudioObject deadclip = null, specialClip = null, specialClipAttack = null, chargeClip = null;
    private Animation _animation = null;
    public AudioObject WalkClip = null;
    System.Random _random = new System.Random();
    void Start()
    {

        _animation = this.GetComponent<Animation>();
        _animation.Play("Idle");
        AnimationEvent _event = new AnimationEvent();
        _event.time = _animation.GetClip("Attack").length;
        _event.functionName = "AudioPlay";
   
        if (this.GetComponent<Animation>().GetClip("Back") != null)
        {
            this.GetComponent<Animation>()["Back"].speed = -0.5f;
        }
        if (this.GetComponent<Animation>().GetClip("Charge") != null)
        {
            this.GetComponent<Animation>()["Charge"].speed = 4;
            _event = new AnimationEvent();
            _event.time = 0;
            _event.functionName = "PlayChargeAudio";
            _animation.GetClip("Charge").AddEvent(_event);
            print("addedd Hit");
        }
        if (this.GetComponent<Animation>().GetClip("Hit") != null)
        {
            this.GetComponent<Animation>()["Hit"].speed = 0.5f;
            _event = new AnimationEvent();
            _event.time = 0;
            _event.functionName = "PlayHitAudio";
            _animation.GetClip("Hit").AddEvent(_event);
            print("addedd Hit");
        }
        if (this.GetComponent<Animation>().GetClip("Block") != null)
        {
            this.GetComponent<Animation>()["Block"].speed = 1f;
            _event = new AnimationEvent();
            _event.time = 0;
            _event.functionName = "PlayHitAudio";
            _animation.GetClip("Block").AddEvent(_event);
            print("addedd Hit");
        }
        if (this.GetComponent<Animation>().GetClip("Dead") != null)
        {
            this.GetComponent<Animation>()["Dead"].speed = 1f;
            _event = new AnimationEvent();
            _event.time = 0;
            _event.functionName = "PlayDeadAudio";
            _animation.GetClip("Dead").AddEvent(_event);
            print("addedd Hit");
        }
        if (this.GetComponent<Animation>().GetClip("Run") != null)
        {
            _event = new AnimationEvent();
            _event.time = _animation.GetClip("Run").length  /2;
            _event.functionName = "PlayRunAudio";
            _animation.GetClip("Run").AddEvent(_event);
            print("Added Run Animation");
        }
        if (this.GetComponent<Animation>().GetClip("Attack") != null){
            this.GetComponent<Animation>()["Attack"].speed = 1.5f;
        }


        if(this.GetComponent<AudioSource>()  == null){
            this.gameObject.AddComponent<AudioSource>();
        }
    }
    GameObject combo3rock = null;
    void Combo3ParticleA(GameObject g)
    {
        GameObject rock = Instantiate(g) as GameObject;
        combo3rock = rock;
       PlayerObject p;
       if ((p = this.GetComponent<PlayerObject>()) != null && combo3rock != null)
       {
           if (p._target != null)
           {
               foreach (Transform t in combo3rock.transform)
               {
                   
                   t.GetComponent<Rigidbody>().AddForce(Vector3.up* 3, ForceMode.Impulse);
               }
           }

       }
       if (this.GetComponent<AudioSource>() != null)
       {
           if (specialClipAttack.mainClip != null) this.GetComponent<AudioSource>().PlayOneShot(specialClipAttack.mainClip);
           if (specialClipAttack.voiceClip != null) this.GetComponent<AudioSource>().PlayOneShot(specialClipAttack.voiceClip);
       }
    }
    void Combo3ParticleB()
    {
        PlayerObject p;
        if ((p = this.GetComponent<PlayerObject>()) != null && combo3rock != null)
        {
            if (p._target != null)
            {
                foreach (Transform t in combo3rock.transform)
                {
                    t.transform.LookAt(p._target.transform);
                    t.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    t.GetComponent<Rigidbody>().AddForce(t.transform.forward * 30, ForceMode.Impulse);
                }
            }
             
        }
    }
     void ComboParticle(GameObject g)
    {
      GameObject spear =  Instantiate(g, this.transform.position, this.transform.rotation) as GameObject;
        if(spear.GetComponent<Rigidbody>() != null)
      spear.GetComponent<Rigidbody>().AddForce(this.transform.forward * 5, ForceMode.Impulse);
    }
    void JumpAttack(GameObject g)
    {
        if (g != null)
        {
            Transform[] ts = this.GetComponentsInChildren<Transform>();

            Transform t = null;
            foreach (Transform _t in ts)
            {
                if (_t.name == "weapon") t = _t;
                break;
            }
            if (t == null) t = this.transform.Find("trans_rhand");
            Instantiate(g, t.position + new Vector3(0, 0.7f, 0) + t.transform.forward, t.rotation);
            print(t.name);
        }
    }
    void PlayRunAudio()
    {
        print("Playing Run Audio");
        if (this.GetComponent<AudioSource>() != null)
        {
            if (WalkClip.mainClip != null)  this.GetComponent<AudioSource>().PlayOneShot(WalkClip.mainClip);
            if (WalkClip.voiceClip!= null) this.GetComponent<AudioSource>().PlayOneShot(WalkClip.voiceClip);
        }
    }
    void SpecialSetUp()
    {
        if (this.GetComponent<AudioSource>() != null)
        {
            if (specialClip.mainClip != null) this.GetComponent<AudioSource>().PlayOneShot(specialClip.mainClip);
            if (specialClip.voiceClip != null) this.GetComponent<AudioSource>().PlayOneShot(specialClip.voiceClip);
        }
    }
    void AnimSpecialAttack(GameObject g)
    {
        if (g != null)
        {
            Transform[] ts = this.GetComponentsInChildren<Transform>();
            Transform t = null;
            foreach (Transform _t in ts)
            {
                if (_t.name == "weapon") t = _t;
                break;
            }
            if (t == null) t = this.transform.Find("trans_rhand");
            Instantiate(g, t.position + new Vector3(0, 0.7f, 0) + t.transform.forward, t.rotation);
            if (this.GetComponent<AudioSource>() != null)
            {
                if (specialClipAttack.mainClip != null) this.GetComponent<AudioSource>().PlayOneShot(specialClipAttack.mainClip);
                if (specialClipAttack.voiceClip != null) this.GetComponent<AudioSource>().PlayOneShot(specialClipAttack.voiceClip);
            }
        }
    }
    void AiAttack(GameObject g)
    {
        if (g != null)
        {
            Transform[] ts = this.GetComponentsInChildren<Transform>();

            Transform t = null;
            foreach (Transform _t in ts)
            {
                if (_t.name == "weapon") t = _t;
                break;
            }
            if (t == null) t = this.transform.Find("Ladislao_RHand");
            GameObject c = Instantiate(g) as GameObject;
            c.transform.position = t.position + new Vector3(0, 1.7f, 0) + t.transform.forward;
            print(t.name);
        }
    }
    void SetTo(string currentAnimation, string _animationName)
    {
        //play animation after the animation is done
    }
    void AudioPlay()
    {
        if (this.GetComponent<AudioSource>() != null){
            int index = _random.Next(0, AttackClips.Count - 1);
            if (AttackClips[index].mainClip != null) this.GetComponent<AudioSource>().PlayOneShot(AttackClips[index].mainClip);
            if (AttackClips[index].voiceClip != null) this.GetComponent<AudioSource>().PlayOneShot(AttackClips[index].voiceClip);
        }
    }
    void PlayHitAudio()
    {
        if (this.GetComponent<AudioSource>() != null)
        {
            int index = _random.Next(0, HitClips.Count - 1);
            if (HitClips[index].mainClip != null) this.GetComponent<AudioSource>().PlayOneShot(HitClips[index].mainClip);
            if (HitClips[index].voiceClip != null) this.GetComponent<AudioSource>().PlayOneShot(HitClips[index].voiceClip);
        }
        print("PlayhitAudio");
    }
    void PlayDeadAudio()
    {
        if (this.GetComponent<AudioSource>() != null)
        {
            if (deadclip.mainClip != null) this.GetComponent<AudioSource>().PlayOneShot(deadclip.mainClip);
            if (deadclip.voiceClip != null) this.GetComponent<AudioSource>().PlayOneShot(deadclip.voiceClip);
        }
        print("PlayhitAudio");
    }
    void PlayChargeAudio()
    {
        if (this.GetComponent<AudioSource>() != null)
        {
            if (chargeClip.mainClip != null) this.GetComponent<AudioSource>().PlayOneShot(chargeClip.mainClip);
            if (chargeClip.voiceClip != null) this.GetComponent<AudioSource>().PlayOneShot(chargeClip.voiceClip);
        }
    }
    
}
