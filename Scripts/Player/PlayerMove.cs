using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed; // 現在のスピード

    [SerializeField] private float[] clamp;
    
    private void Start()
    {
        // UniRX 移動処理を実施
        this.UpdateAsObservable()
            .Where(_ =>
                    (Input.GetAxis("Horizontal") != 0) ||
                    (Input.GetAxis("Vertical") != 0)
            )
            .Subscribe(_ => Move());
    }

    void Move () {

        var x = Input.GetAxis("Horizontal") * moveSpeed;
        var z = Input.GetAxis("Vertical") * moveSpeed;
        
        if (x != 0 || z != 0)
        {
            var direction = new Vector3(x, 0, z);
            transform.position += new Vector3(x * Time.deltaTime,0, z * Time.deltaTime);
            transform.localRotation = Quaternion.LookRotation(direction);
            Clamp();
        }
        
    }

    void Clamp()
    {
        var player_pos_x = Mathf.Clamp(transform.position.x, clamp[0], clamp[1]);
        var player_pos_z = Mathf.Clamp(transform.position.z, clamp[2], clamp[3]);
        transform.position = new Vector3(player_pos_x, transform.position.y, player_pos_z);
    }

}
