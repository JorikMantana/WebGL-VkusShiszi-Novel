using Naninovel;
using UnityEngine;

public class LoadOnStart : MonoBehaviour
{
    //�������� ��������� ����������� ������ ��� ������ �����
    private void Start()
    {
        var scripts = Engine.GetService<IScriptManager>();
        var states = Engine.GetService<IStateManager>();
        if (states.QuickLoadAvailable)
        {
            states.QuickLoadAsync();
        }
    }
}
