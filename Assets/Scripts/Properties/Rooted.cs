using UnityEngine;
using System.Collections;

public class Rooted : PlayerObject {

    public GameObject Projectile = null;
    public Transform[] ShootPoint = null;
    private GameObject _projectile = null;
    public GameObject hpOverlay = null;
    public override void Start(){
        base.Start();
        this.type = PlayerType.EnemyRootedAI;
        hpOverlay = Instantiate(hpOverlay, this.transform.position, this.transform.rotation) as GameObject;
        hpOverlay.transform.SetParent(this.transform, false);
        _projectile =  Instantiate(Projectile) as GameObject;
        _projectile.SetActive(false);
        _projectile.GetComponent<Damage>().friendlyFire = false;
        _projectile.GetComponent<Damage>().friendTag = this.gameObject.tag;
    }
    public void LookTo(Transform _target)
    {
        this.transform.LookAt(_target);
    }
    public void Attack()
    {
        
        foreach (Transform t in ShootPoint)
        {
           GameObject p =  Instantiate(Projectile, t.position, this.transform.rotation) as GameObject;
           p.GetComponent<Damage>().friendlyFire = false;
           p.GetComponent<Damage>().friendTag = this.gameObject.tag;
           p.SetActive(true);
          p.GetComponent<Rigidbody>().AddForce(this.transform.forward * 20, ForceMode.Impulse);
        }
    }
}
