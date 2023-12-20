using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public bool IsNPC;
    public Dialogue Dialogue;
    public GameObject DialogueIndicator;
    public float IndicatorCooldown = 5f;
    public Color HoverColor;

    private Color OriginalColor;
    private bool InDialogue;
    private void Start()
    {
        OriginalColor = GetComponent<SpriteRenderer>().color;
        if (IsNPC)
        {
            Debug.LogFormat("Make sure that the object has a Dialogue Indicator");
            DialogueIndicator.SetActive(false);
            StartCoroutine(WaitToTalk());
        }
    }

    private void Update()
    {
        if (IsNPC)
        {
            if (MouseHover() && !Input.GetKey(KeyCode.Mouse1) && !Input.GetKey(KeyCode.Mouse2))
            {
                GetComponent<SpriteRenderer>().color = HoverColor;
                if (Input.GetKey(KeyCode.Mouse0) && DialogueIndicator.activeSelf)
                {
                    TriggerDialogue();
                    InDialogue = true;
                    FindObjectOfType<DialogueManager>().TriggerAdded = false;
                }
            }
            else GetComponent<SpriteRenderer>().color = OriginalColor;
        }
    }
    bool MouseHover()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        return Physics.Raycast(ray, out hit) && hit.collider.name == name;
    }

    IEnumerator WaitToTalk()
    {
        yield return new WaitForSecondsRealtime(IndicatorCooldown);
        DialogueIndicator.SetActive(true);
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(Dialogue);
    }

    public void IndicatorOff()
    {
        if (InDialogue)
        {
            DialogueIndicator.SetActive(false);
        }
    }
}