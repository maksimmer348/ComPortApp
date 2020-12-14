namespace ComPortSettings.ComPort
{
    public class SupplyLib : CommandLib

    {
        public override void CreateCommands()
        {
            Add("Set voltage", ":chan1:volt");
            Add("Return voltage", ":chan1:meas:volt ?");
            Add("Return set voltage", ":chan1:volt ?");

            Add("Set current", ":chan1: curr");
            Add("Return current", ":chan1:meas:curr ?");
            Add("Return set current", ":chan1:curr ?");

            Add("Output", ":outp:stat");
            Add("Get Output", ":outp:stat?");
        }
    }
}