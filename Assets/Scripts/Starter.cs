using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    [SerializeField] [Range(0, 50)] private int CoinNumber;
    [SerializeField] [Range(0, 50)] private int SpikeNumber;

    [SerializeField] private GameObject EnvironmentPrefab;
    [SerializeField] private Spike SpikePrefab;
    [SerializeField] private Coin CoinPrefab;
    [SerializeField] private Ball BallPrefab;

    private InputController _input;
    private GameLoopController _game;

    private Ball _ball;
    private Transform _environment;
    private Transform _coins;

    private void Awake()
    {
        _input = GetComponent<InputController>();
        _game = GetComponent<GameLoopController>();

        _environment = Instantiate(EnvironmentPrefab, Vector3.zero, Quaternion.identity).transform;
        GameComponent.SpawnRadius = _environment.GetChild(0).localScale.x / 2;

        var ballSpawnPosition = new Vector3(0f, 0f, -GameComponent.SpawnRadius);
        GameComponent.ReservedPosition = ballSpawnPosition;
        _ball = Instantiate(BallPrefab, ballSpawnPosition, Quaternion.identity).GetComponent<Ball>();

        var spikes = new GameObject(ETags.Spike.ToString()).transform;
        spikes.SetParent(_environment);
        for (uint iterator = 0; iterator < SpikeNumber; ++iterator)
            Instantiate(SpikePrefab, Vector3.zero, Quaternion.identity).transform.SetParent(spikes);

        _coins = new GameObject(ETags.Coin.ToString()).transform;
        _coins.SetParent(_environment);
        //for (uint iterator = 0; iterator < CoinNumber; ++iterator)
            //Instantiate(CoinPrefab, Vector3.zero, Quaternion.identity).transform.SetParent(_coins);
    }

    private void Start()
    {
        //_input.ChangedPosition += _ground.Rotate;
    }

    private void Update()
    {
        
    }
}
