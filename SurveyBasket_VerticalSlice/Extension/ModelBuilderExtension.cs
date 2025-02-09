namespace SurveyBasket_VerticalSlice.Extension
{
    public static class ModelBuilderExtension
    {
        public static void ApplyCascadeRestrictionsConfigration(this ModelBuilder modelBuilder)
        {
            var cascadeFks = modelBuilder.Model.GetEntityTypes()
                                                         .SelectMany(type => type.GetForeignKeys())
                                                         .Where(fk => fk.DeleteBehavior == DeleteBehavior.Cascade && !fk.IsOwnership);

            foreach (var fk in cascadeFks)
                fk.DeleteBehavior = DeleteBehavior.Restrict;


            var decimalType = modelBuilder.Model.GetEntityTypes()
                                                           .SelectMany(type => type.GetProperties())
                                                           .Where(prop => prop.ClrType == typeof(decimal) || prop.ClrType == typeof(decimal?));


            modelBuilder.ApplyDecimalTypeConfigration();
        }


        private static void ApplyDecimalTypeConfigration(this ModelBuilder modelBuilder)
        {
            var decimalType = modelBuilder.Model.GetEntityTypes()
                                                           .SelectMany(type => type.GetProperties())
                                                           .Where(prop => prop.ClrType == typeof(decimal) || prop.ClrType == typeof(decimal?));

            foreach (var prop in decimalType)
                prop.SetColumnType("decimal(18,2)");


        }
    }
}
