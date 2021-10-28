using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARAnimatedContent : ARContent
{
    private Animator myAnimatorController = new Animator();
    public List<GameObject> animatedObjects;
    public float time;
    public float angle = 150f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator coroutine;
    override protected void SetState(ARState state, float timeElapsed)
    {
        switch (state)
        {
            case ARState.Finish:
                animatedObjects[0].SetActive(false);
                break;
            case ARState.State1:
                animatedObjects[0].SetActive(true);
                break;
            default:
                break;
        }
    }

    void TurnOnTrigger(string triggerName)
	{
        myAnimatorController.SetTrigger(triggerName);
	}
    IEnumerator sunCourutine(GameObject gameObject) 
    {
        while (true) 
        {
            float yPosition = Mathf.Cos(angle) * 600;
            float zPosition = Mathf.Sin(angle) * 600;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, yPosition, -zPosition);
            angle = angle - (60 / time); 
            yield return new WaitForSeconds(0.1F);
        }
    
    }
}
