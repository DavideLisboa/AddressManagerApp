public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
        {
            if (!context.Usuarios.Any())
            {
                context.Usuarios.AddRange(
                    new Usuario
                    {
                        Nome = "Admin User",
                        Usuario = "admin",
                        Senha = "admin"
                    }
                );
                context.SaveChanges();
            }

            if (!context.Enderecos.Any())
            {
                context.Enderecos.AddRange(
                    new Endereco
                    {
                        Cep = "12345-678",
                        Logradouro = "Rua Teste",
                        Bairro = "Bairro Teste",
                        Cidade = "Cidade Teste",
                        Uf = "SP",
                        Numero = "123",
                        UsuarioId = 1
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
