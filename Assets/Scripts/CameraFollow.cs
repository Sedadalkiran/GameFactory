using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    public float _smoothnes;
    public Vector3 _offset;

    private void Update()
    {
        if (_target == null)
        {
            return;
        }

        transform.position = Vector3.Lerp(transform.position, _target.position + _offset, Time.deltaTime * _smoothnes);

    }




}
