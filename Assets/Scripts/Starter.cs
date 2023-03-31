using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Cinemachine;

public class Starter : MonoBehaviour
{
    public GameObject Cube;

    [SerializeField] [Range(0, 50)] private int CoinNumber;
    [SerializeField] [Range(0, 50)] private int SpikeNumber;

    [SerializeField] private GameObject EnvironmentPrefab;
    [SerializeField] private Spike SpikePrefab;
    [SerializeField] private Coin CoinPrefab;
    [SerializeField] private PlayerMovement BallPrefab;
    [SerializeField] private CinemachineVirtualCamera VCam;
    private InputController _input;
    private GameLoopController _game;


    private PlayerMovement _ball;
    private Transform _ground;
    private Transform _coins;

    private const float _angle = 60;

    private void Awake()
    {
        _input = GetComponent<InputController>();
        _game = GetComponent<GameLoopController>();

        var environment = Instantiate(EnvironmentPrefab, Vector3.zero, Quaternion.identity).transform;
        _ground = FindObjectOfType<GravityAttractor>().transform;
        GameComponent.SpawnRadius = _ground.localScale.x / 2;


        //var spawnHeight = math.sqrt(math.pow(GameComponent.SpawnRadius, 2) * (5 / 4 - math.cos(_angle)));
        var ballSpawnPosition = new Vector3(0f, 0f, -GameComponent.SpawnRadius);//GameComponent.GetRandomPosition();
        var cameraSpawnPosition = new Vector3(0f, 0f, -GameComponent.SpawnRadius - 3f);//GameComponent.GetRandomPosition();
        Debug.Log(cameraSpawnPosition);

        //Instantiate(Cube, ballSpawnPosition, Quaternion.identity);//.GetComponent<Movement>();


        //GameComponent.ReservedPosition = ballSpawnPosition;
        _ball = Instantiate(BallPrefab, ballSpawnPosition, Quaternion.identity).GetComponent<PlayerMovement>();
        _ball.Attractor = _ground.GetComponent<GravityAttractor>();
        //_camera.SetAttractor(_ground.GetComponent<GravityAttractor>());
        //_camera.gameObject.transform.position = cameraSpawnPosition;

        VCam.Follow = _ball.transform;
        VCam.LookAt = _ball.transform;
        //_ball.Attractor = _ground.GetComponent<GravityAttractor>();
        //Debug.Log(_ground.GetComponent<GravityAttractor>());
        //_camera.position = ballSpawnPosition + Vector3.forward;

        /*var spikes = new GameObject(ETags.Spike.ToString()).transform;
        spikes.SetParent(_environment);
        for (uint iterator = 0; iterator < SpikeNumber; ++iterator)
            Instantiate(SpikePrefab, Vector3.zero, Quaternion.identity).transform.SetParent(spikes);

        _coins = new GameObject(ETags.Coin.ToString()).transform;
        _coins.SetParent(_environment);*/
        //for (uint iterator = 0; iterator < CoinNumber; ++iterator)
        //Instantiate(CoinPrefab, Vector3.zero, Quaternion.identity).transform.SetParent(_coins);
    }

    private void Start()
    {
        _input.ChangedPosition += _ball.MoveTo;
        _input.ChangedRotation += _ball.Rotate;

        _input.ChangedRotation += VCam.GetComponent<CameraMovement>().Rotate;
        //_ball.ChangedPosition += _camera.MoveTo;
    }

    private void Update()
    {
        
    }
}
