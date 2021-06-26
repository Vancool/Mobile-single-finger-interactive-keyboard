using UnityEngine;

using System.Collections;

using UnityEngine.UI;

using UnityEngine.EventSystems;

 

public class
NewBehaviourScript : MonoBehaviour, ISelectHandler

{

    void ISelectHandler.OnSelect(BaseEventData eventData)

    {

        StartCoroutine(MoveTextEnd());

    }

 

    IEnumerator MoveTextEnd()

{

    yield return null;

    this.GetComponent<InputField>().MoveTextEnd(false);

}

}
