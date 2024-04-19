using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cooldown 
{
     private float CooldownTime;
    private float NextDash;
    float dashingTime = 1f;

    public bool IsCoolingDown => Time.time < NextDash;
    public void StartCooldown()=> NextDash = Time.time + CooldownTime;

    public IEnumerator dashTime(){
        yield return new WaitForSeconds(dashingTime);
    }
    


}
