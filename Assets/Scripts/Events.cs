using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Events 
{
    public static readonly Evt onGameOver = new Evt();
    public static readonly Evt newWave = new Evt();
    public static readonly Evt<Card> onCardSelected = new Evt<Card>();
    public static readonly Evt<SkillSlot> onSlotSelected = new Evt<SkillSlot>();
    public static readonly Evt<Ability> onDragingAbility = new Evt<Ability>();

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
