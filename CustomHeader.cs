namespace CustomHttpHeaders
{
    public class CustomHeader
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public CustomHeader(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string GetName()
        {
            return Name;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public string GetValue()
        {
            return Value;
        }

        public void SetValue(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"{Name}: {Value}";
        }
    }
}