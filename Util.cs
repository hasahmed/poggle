using Godot;
using System;
using System.Collections.Generic;

public class Util : Node
{

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        
    }
    public static T[] GetChildrenOfType<T>(Node childrenOf)
    {
        object[] allChildren = childrenOf.GetChildren();
        List<T> allChildrenOfTypeT = new List<T>();
        foreach (object node in allChildren)
        {
            if (node is T){
                allChildrenOfTypeT.Add((T)node);
            }
        }
        return allChildrenOfTypeT.ToArray();
    }
    public static T GetNode<T>(string pathToNode, Node nodeFrom) where T : Node
    {
        return nodeFrom.GetNode(pathToNode) as T;
    }
}
