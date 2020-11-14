using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class JointIt : MonoBehaviour
{
    Vector3 offset1 = new Vector3(0.3f,0,0);
    Vector3 offset2 = new Vector3(-0.3f, 0, 0);
    float distance = 0.8f;
    public float time = 0.2f;
    public bool fallen;
    //public float angle = 10;
    public float breakForce;
    private void OnCollisionEnter(Collision collision)
    {
        if(exploded <=0 )
            if(collision.gameObject.tag == "Joint" && !collision.gameObject.GetComponent<HingeJoint>())
            {
                HingeJoint joint = collision.gameObject.AddComponent(typeof(HingeJoint)) as HingeJoint;
                joint.connectedBody = GetComponent<Rigidbody>();

                var audio = collision.gameObject.GetComponent<AudioSource>();
                if (audio) if(audio.isActiveAndEnabled) audio.Play();
                //var jointit = collision.gameObject.GetComponent<JointIt>();
                //if (jointit) jointit.angle = angle > 0.5f ? angle - 0.1f : angle;

            }
    }
    private void Update()
    {
        exploded -= exploded > 0 ? Time.deltaTime : 0;
    }
    public bool ray;
    private void FixedUpdate()
    {

        var hinge = GetComponent<HingeJoint>();
        if (hinge)
        {
            ray = RayCast(this.transform.position + offset1, transform.TransformDirection(Vector3.down), distance);
            if(ray)
                ray = RayCast(this.transform.position + offset2, transform.TransformDirection(Vector3.down), distance);


            breakForce = hinge.breakForce;
            //if (hinge.angle > angle | hinge.angle < angle * -1 | ray)
            if(!ray)
                time -= Time.deltaTime;
            else
                time = 0.5f;
            if (time <= 0)
                Destroy(hinge);//.breakForce = 100;

        }
        if(fallen && !cantfall)
        {
            //TODO desaparicion suave
            Destroy(this.gameObject);
        }
    }
    public float exploded = 0;
    private bool RayCast(Vector3 from,Vector3 to,float distance)
    {
        RaycastHit hit;
        Ray ray = new Ray(from, to);

        if (Physics.Raycast(ray, out hit, distance))
        {
            //Debug.DrawRay(hit.point, hit.normal,Color.green);
            if (hit.collider != null)
                if(hit.collider.tag == "Player" | hit.collider.tag == "Joint" | hit.collider.tag == "PlayerSon")
                    return true;
            else
                return false;
        }
        return false;
    }
    public bool cantfall = false;
}
