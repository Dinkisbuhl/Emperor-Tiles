using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : Photon.MonoBehaviour
{
    public int teamMember = 0;
    public int damage = 5;
    public float damageTimer = 0f;

    void Start()
    {
        damageTimer = 0f;
    }


    void Update()
    {
        if (damageTimer > 0)
        {
            damageTimer -= Time.deltaTime;
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "ControlPoint" && damageTimer <= 0)
        {
            var capBuildScript = col.gameObject.transform.parent.gameObject.GetComponent<CapitolBuilding>();
            var BuildScript = col.gameObject.transform.parent.gameObject.GetComponent<Building>();
            if (capBuildScript && BuildScript)
            {
                int teamOfBase = BuildScript.getTeamOwner();
                if (teamMember != teamOfBase)
                {
                    capBuildScript.takeDamage(damage);
                    damageTimer = 1.12f;
                }
            }
        }
    }
}
