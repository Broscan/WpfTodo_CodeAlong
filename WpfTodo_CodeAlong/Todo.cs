namespace WpfTodo_CodeAlong
{
    internal class Todo
    {
        public string Name { get; set; }

        public Priority Priority { get; set; }


        public string GetInfo()
        {
            return $"{Name} - Priority: {Priority}";
        }
    }
}
