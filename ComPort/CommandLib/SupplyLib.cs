namespace ComPortSettings.ComPort
{
    public class SupplyLib : CommandLib

    {
        public override void CreateCommands()
        {
            Add("Return current", ":chan1:meas:curr ?");
            Add("Set current", ":chan1: curr");
            Add("Return voltage", ":chan1:meas:volt ?");
            Add("Устанавливает выходное напряжение(единица измерения: В)", ":chan1:volt ");
            Add("Возвращает фактический выходной ток нагрузки (единица измерения А", ":chan1:meas:curr ? ");
            Add("Возвращает фактическое выходное напряжение нагрузки (единица измерения: В).", ":chan1:meas:volt ? ");
            Add("Output", ":outp:stat");
            Add("Get Output", ":outp:stat?");
        }
    }
}