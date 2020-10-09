using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLife : MonoBehaviour {

    bool butWorks = false;
    // Update is called once per every day
    private IEnumerator DiaryCycle(){
        yield return new WaitForSeconds(300);
        Eat();
        WriteCode();
        HateTheCode();

        if (butWorks)
        {
            yield return new WaitForSeconds(200);
            Eat();
            PlayVideoGames(10);
        }
        else
            yield return null; 
	}
    void PlayVideoGames(int hours)
    {
        bool myEyesBleed = false;
        if (myEyesBleed)
            StopAllCoroutines();
    }




    void Eat()
    { }
    void WriteCode()
    { }
    void SeeTheCode()
    { }
    void HateTheCode()
    { }
}
