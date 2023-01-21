public class Program
{
	public static void Main()
	{
		Configuration.SetPinFunction(21, DeviceFunction.I2C1_DATA);
		Configuration.SetPinFunction(22, DeviceFunction.I2C1_CLOCK);

		I2cDevice arduino = I2cDevice.Create(new I2cConnectionSettings(1, 0x08));
		var msg = System.Text.Encoding.UTF8.GetBytes("Hello from NodeMCU!");
		var result = arduino.Write(msg);

		DelayHelper.DelayMilliseconds(250, true);
		var buffer = new byte[13];
		var span = new SpanByte(buffer);

		result = arduino.Read(span);
	}
}