using UnityEngine;

public class Parallax : MonoBehaviour
{
    private const string MainText = "_MainTex";

    [SerializeField] private float _speed = 0.2f; 

    private Material _material;
    private float _distance;

    private void Start()
    {
        _material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        _distance += Time.deltaTime * _speed;
        _material.SetTextureOffset(MainText, Vector2.right * _distance);
    }
}