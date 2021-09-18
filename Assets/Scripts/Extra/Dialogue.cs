using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogue;
    [SerializeField] private LayerMask props;

    private void Update()
    {
        //Interact();
    }

    private void Interact()
    {
        RaycastHit hit;
        Ray ray;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000f, props))
        {
            switch (hit.collider.name)
            {
                case "Crate":
                    dialogue.text = "A strange smell eminates from this crate...";
                    break;
                default:
                    dialogue.text = "";
                    break;
            }
        }
    }
}
