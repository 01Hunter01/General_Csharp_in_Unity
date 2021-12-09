using UnityEditor;

namespace MyGame
{
    public class MenuItems
    {
        [MenuItem("OwnWindow/Create traps %y")]
        private static void CreateTraps()
        {
            EditorWindow.GetWindow(typeof(MyWindow), false, "Create traps");
        } 
    }
}
