using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class UIControler : Control
{
    private Dictionary<ContainerType,UIContainer> containers;

    public override void _Ready()
    {
        containers = GetChildren().Where((element) => element is UIContainer).Cast<UIContainer>().ToDictionary((element) => element.container);

        containers[ContainerType.Start].Visible = true;

        containers[ContainerType.Start].ButtonNode.Pressed += HandleStartPressed;

        GameEvents.onEndGame += HandleEndGame;
    }

    private void HandleEndGame()
    {
        containers[ContainerType.Stats].Visible = false;
        containers[ContainerType.defeat].Visible = true;
    }

    private void HandleStartPressed()
    {
        GetTree().Paused = false;

        containers[ContainerType.Start].Visible = false;
        containers[ContainerType.Stats].Visible = true;

        GameEvents.RaiseStartGame();
    }
}