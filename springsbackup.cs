using UnityEngine;

public class spring : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    public GameObject myNode;
    [SerializeField]
    public GameObject otherNode;
    [SerializeField]
    public GameObject otherNode2;
    Rigidbody2D rigidbody2D;
    public Vector2 vec;
    GameObject[] connectedNodes;
    public global global;
    float springten = global.springTen;
    float equil = global.equilibrium;
    void Start()
    {
        connectedNodes = new GameObject[] { otherNode, otherNode2 };
        rigidbody2D = GetComponent<Rigidbody2D>();
        if (rigidbody2D == null) { 
            Debug.LogError("Rigidbody2D is not assigned."); return; 
        } 
        if (myNode == null) {
            Debug.LogError("MyNode is not assigned."); return;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < connectedNodes.Length; i++){
            if(connectedNodes[i] != null){
                Vector2 direction = connectedNodes[i].transform.position - myNode.transform.position;
                float distance = direction.magnitude;
                float displacement = distance - equil;
                direction.Normalize();
                vec = direction * springten * displacement;
                rigidbody2D.AddForce(vec);
            }
        }
        
    }
}
