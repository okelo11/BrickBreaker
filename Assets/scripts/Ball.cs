using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
   public float speed;
   public float paddleLeftSideEndPoint,paddleLeftSideStartPoint;
   public  Rigidbody rb;
   public  Vector3 velocity;
   public Player playerComponent;
    void Start()
    {

        rb = transform.GetComponent<Rigidbody>();

        rb.velocity = Vector3.down* speed;
    }

    void Update()
    {

        velocity = rb.velocity;

    }
    private void OnCollisionEnter(Collision other)//top ve paddle arasindaki iliski(topun paddle'dan sekmesi durumlari)//the relationship between ball and paddle
    {
        if (other.transform.tag == "Paddle")
        {
            if(rb.velocity.x>0)//eger top x ekseninde saga hareket ediyorsa(top paddle'a soldan gelip carptiysa)//if the ball moves on the x-axis
            { 
                paddleLeftSideStartPoint = other.transform.position.x - other.transform.lossyScale.x / 2f; //paddle'ýn soldan %25 lik bölümünün baslangici//start point of the %25 of the paddle from the left side
                paddleLeftSideEndPoint = other.transform.position.x - other.transform.lossyScale.x / 4f;  //paddle'ýn soldan %25 lik bölümünün bitisi//end point of the %25 of the paddle from the left side
                if (other.GetContact(0).point.x>=paddleLeftSideStartPoint&& other.GetContact(0).point.x<=paddleLeftSideEndPoint)//eger top paddle'ýn soldan %25lik kýsmýna degdiyse//if the ball hits the left side that 
                {
                    rb.velocity = velocity * -1;//topun hiz vektorunun dogrulutsunu tersine cevir
                    
                }
                else //top paddle'ýn orta ve sag tarafýna degdiyse//if the ball hits the rest of the paddle -not left side
                {
                    rb.velocity = Vector3.Reflect(velocity, other.GetContact(0).normal);//reflection of the vector
                    
                }
            }else if(rb.velocity.x < 0) //eger top x ekseninde sola hareket ediyorsa(top paddle'a sagdan gelip carptiysa)
            {
                paddleLeftSideStartPoint = other.transform.position.x + other.transform.lossyScale.x / 2f; //paddle'ýn sagdan %25 lik bölümünün baslangici(soldan carpmanin aksine cikartma degil toplama yapiliyor.)
                paddleLeftSideEndPoint = other.transform.position.x + other.transform.lossyScale.x / 4f;  //paddle'ýn sagdan %25 lik bölümünün bitisi(soldan carpmanin aksine cikartma degil toplama yapiliyor.)
                if (other.GetContact(0).point.x <= paddleLeftSideStartPoint && other.GetContact(0).point.x >= paddleLeftSideEndPoint)//eger top paddle'in sagdan %25lik kismina degdiyse
                {
                    rb.velocity = velocity * -1;//topun hiz vektorunun dogrulutsunu tersine cevir  //invert the vector

                }
                else //top paddle'ýn orta ve sag tarafýna degdiyse
                {
                    rb.velocity = Vector3.Reflect(velocity, other.GetContact(0).normal);

                }

            }else// top sadece y ekseninde hareket ederse,topun sadece yukari asagi hareket yapmasini onlemek ve  oynanabilirligi dusurmemek adina 3 farkli durum.//if the ball moves only on the y-axis,there are 3 options to avoid only up and down movement 
            {
                if (playerComponent.lastPositionOfX - playerComponent.beforeOneFrameFromLastPositionOfX > 0)//top sadece y  ekseninde hareket ederken,paddle saga gidiyorsa top sag ust capraza gider.//if the paddle moves right while the ball moves only on the y-axis 
                {

                    rb.velocity = new Vector3(15, 20, 0);//
                   
                }
                else if (playerComponent.lastPositionOfX - playerComponent.beforeOneFrameFromLastPositionOfX < 0)//top sadece y  ekseninde hareket ederken,paddle sola gidiyorsa top sol ust capraza gider.//if the paddle moves left while the ball moves only on the y-axis 
                {
                    rb.velocity = new Vector3(-15, 20, 0);
                }
                else///top sadece y  ekseninde hareket ederken,paddle hareket ettirilmez ise,top sadece yukari asagi hareket yapar//if the paddle does not  move any direction while the ball moves only on the y-axis.just do reflection until the paddle moves
                {
                    rb.velocity = Vector3.Reflect(velocity, other.GetContact(0).normal);

                }

            }
      


        }
        else//top duvarlara veya bloklara carparsa hiz vektoru direkt yansima yapsin
        {
            rb.velocity = Vector3.Reflect(velocity, other.GetContact(0).normal);


        }



    }
    
}
