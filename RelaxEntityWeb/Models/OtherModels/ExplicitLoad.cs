namespace RelaxEntityWeb.Models.OtherModels
{
    public static class ExplicitLoad
    {
        public static void Load(this RelaxEntityContext context)
        {
            foreach (var item in context.Events) { }
            foreach (var item in context.Clients) { }
            foreach (var item in context.ProjectManagers) { }
            foreach (var item in context.Organizations) { }
            foreach (var item in context.Orders) { }
            foreach (var item in context.Locations) { }
            foreach (var item in context.Programms) { }
        }
    }
}
