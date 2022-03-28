using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Events 
{
    public static readonly Evt onGameOver = new Evt();
    public static readonly Evt onBuyingAbility = new Evt();
    public static readonly Evt onStartWave = new Evt();
    public static readonly Evt onEnemySpawned = new Evt();
    public static readonly Evt onEnemyDied = new Evt();
    public static readonly Evt<float> onHealthChange = new Evt<float>();
    public static readonly Evt<float> onMaxHealthChange = new Evt<float>();
    public static readonly Evt<float> onCauseDamage = new Evt<float>();
}

public class Evt {
    private event Action _action = delegate { };

    public void Invoke() {
        _action.Invoke();
    }

    public void AddListener (Action listener) {
        _action -= listener;
        _action += listener;
    }

    public void RemoveListener(Action listener) {
        _action -= listener;
    }
}

public class Evt<T> {
    private event Action<T> _action = delegate { };

    public void Invoke(T param) {
        _action.Invoke(param);
    }

    public void AddListener (Action<T> listener) {
        _action -= listener;
        _action += listener;
    }

    public void RemoveListener(Action<T> listener) {
        _action -= listener;
    }
}
