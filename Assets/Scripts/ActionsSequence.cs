public static class ActionsSequence
{
    public struct Action
    {
        public Action(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name;
        public string Description;
    }

    public static Action[] Actions =
    {
        new Action("Button1Pressed", "Нажми 'Button 1'"),
        new Action("Button2Pressed", "Теперь нажми 'Button 2'"),
        new Action("Button3Pressed", "Молодец! А теперь нажми 'Button 3'"),
        new Action("Button4Pressed", "И, наконец, нажми 'Button 4'")
    };
}