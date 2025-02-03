using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using monogamer.classes;
using monogamer.classes.components;
using monogamer.classes.objects;
using System;
using System.Collections.Generic;
using MonoGame.ImGuiNet;
using ImGuiNET;

namespace monogamer.classes
{

    public enum DebugTypes
    {
        OBJECTS,
        COMPONENTS,
        ICHARS,
        EXTRAS,
        ALL
    }

    public class Debug
    {
        public void startDebugging(DebugTypes type, ICharacter[] sceneObjects)
        {
            switch (type)
            {
                case DebugTypes.OBJECTS:

                    if (ImGui.TreeNode("Objects"))
                    {

                        for (int i = 0; i < sceneObjects.Length; i++)
                        {


                            if (ImGui.TreeNode(sceneObjects[i].Name))
                            {
                                ImGui.Text($"Position: ({sceneObjects[i].Position.X}, {sceneObjects[i].Position.Y})");

                                // Convert Microsoft.Xna.Framework.Vector2 to System.Numerics.Vector2
                                System.Numerics.Vector2 position = new System.Numerics.Vector2(sceneObjects[i].Position.X, sceneObjects[i].Position.Y);

                                // Use ImGui.DragFloat2 to modify the position values
                                if (ImGui.DragFloat2("Position", ref position))
                                {
                                    // Convert back to Microsoft.Xna.Framework.Vector2 and assign the modified values
                                    sceneObjects[i].Position = new Microsoft.Xna.Framework.Vector2(position.X, position.Y);
                                }

                                ImGui.Text($"Number of Colliders: {sceneObjects[i].Colliders.Count}");

                                if (ImGui.TreeNode("components"))
                                {

                                    for (int j = 0; j < sceneObjects[i].components.Length; j++)
                                    {
                                        ImGui.Text(sceneObjects[i].components[j]);
                                    }
                                    ImGui.TreePop();


                                    


                                }

                                ImGui.Text("Sprite:" + sceneObjects[i].Sprite);

                                ImGui.TreePop();
                            }



                        }

                        ImGui.TreePop();
                    }
                    break;



                case DebugTypes.EXTRAS:
                    ImGui.Text("Extras");
                    ImGui.Text("Fps: " + ImGui.GetIO().Framerate);
                    break;
            }
        }
    }
}
