using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constructor : MonoBehaviour
{
    [SerializeField] GameObject[] pieces;
    GameObject addedPiece;

    private void Start()
    {
        addedPiece = pieces[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                var clone = Instantiate(addedPiece, hit.transform.position, hit.transform.rotation);
                clone.transform.Translate((clone.transform.up / 2) * (1 / hit.transform.parent.transform.localScale.y), Space.World);
            }
        }
    }

    public void SetPiece(int arrayIndex) => addedPiece = pieces[arrayIndex];


}
