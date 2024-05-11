namespace Assignment_1
{
    public class CustomEnterValue
    {
        public dynamic Value { get; set; }
        public string? Message { get; set; }

        public CustomEnterValue()
        {
            Message = Constants.ERROR_MESSAGE;
        }

        public CustomEnterValue(dynamic value)
        {
            Value = value;
        }
    }
}