namespace ComPortSettings.ComPort
{
    public class MeterLib : CommandLib

    {
        public override void CreateCommands()
        {
            Add("Возвращает выходной ток(единица измерения: А)", ": chan1: curr? ");
            Add("Устанавливает выходной ток(единица измерения: А).", ": chan1: curr");
            Add("Возвращает выходное напряжение(единица измерения: В)", ":chan1:volt?");
            Add("Устанавливает выходное напряжение(единица измерения: В)", ":chan1:volt");
            Add("Возвращает фактический выходной ток нагрузки (единица измерения А", ":chan1:meas:curr ?");
            Add("Возвращает фактическое выходное напряжение нагрузки (единица измерения: В).", ":chan1:meas:volt ? ");
            Add("Output Load", "V00");
        }
    }
}