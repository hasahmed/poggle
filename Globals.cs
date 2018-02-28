using Godot;
using System;
using System.Collections.Generic;

public class Globals : Node
{
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        
    }

//    public override void _Process(float delta)
//    {
//        // Called every frame. Delta is time since last frame.
//        // Update game logic here.
//        
//    }

    // public T[] GetChildrenOfType<T>(Node childrenOf)
    static public T[] GetChildrenOfType<T>(Node childrenOf)
    {
        // using System;
        // GD.Print(childrenOf.GetChildren() as T[]);
        object[] allChildren = childrenOf.GetChildren();
        // T[] allChildrenOfTypeT = new T[allChildren.Length];
        List<T> allChildrenOfTypeT = new List<T>();
        foreach (object node in allChildren)
        {
            if (node is T){
                allChildrenOfTypeT.Add((T)node);
            }
        }
        return allChildrenOfTypeT.ToArray();
    }
}
