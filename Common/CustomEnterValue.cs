namespace Common
{
    public class CustomEnterValue
    {
        public dynamic Value { get; set; }
        public string? Message { get; set; }

        public CustomEnterValue()
        {
            Message = ConstantInputs.ERROR_MESSAGE;
        }

        public CustomEnterValue(dynamic value)
        {
            Value = value;
        }
    }
}