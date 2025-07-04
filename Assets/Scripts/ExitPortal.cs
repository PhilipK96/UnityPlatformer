public class ExitPortal : Portal
{
    void Start()
    {
        ActivatePortal();
    }

    private void ActivatePortal()
    {
        isActive = true;
        endpoint_portal_name = "Portal_In";
    }
}
