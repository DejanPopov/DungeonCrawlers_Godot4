using Godot;
using System;

public partial class StateMachine : Node
{
    [Export] private Node currentState;
    [Export] private Node[] states;

}
