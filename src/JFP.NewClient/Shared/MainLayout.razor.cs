namespace JFP.NewClient.Shared;

public partial class MainLayout
{
    private bool _open = false;

    private void ToggleDrawer()
    {
        _open = !_open;
    }
}