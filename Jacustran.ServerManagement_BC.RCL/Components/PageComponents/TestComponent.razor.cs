namespace Jacustran.ServerManagement_BC.RCL.Components.PageComponents;

public partial class TestComponent
{
    public int myNum { get; set; } = 0;

    public void ClickHandler()
    {
        myNum = myNum + 1;
    }


}
