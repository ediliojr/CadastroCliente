# CadastroCliente

<h4>ConnectionString:</h4>

 { "ConnectionStrings": {
    "CadastroClienteContext": "Server=localhost;Port=3306;Database=cadastro;Uid=root;Pwd=1234",
    "CadastroClienteDbContextConnection": "Server=(localdb)\\mssqllocaldb;Database=CadastroCliente;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}

<h4>Pacotes necessários para o projeto, copiar e colar no Package Manager Console:</h4>

Update-Package Microsoft.AspNetCore.Identity.EntityFrameworkCore -Version 6.0.20
Update-Package Microsoft.AspNetCore.Identity.UI -Version 6.0.20
Update-Package Microsoft.EntityFrameworkCore.Design -Version 7.0.9
Update-Package Microsoft.EntityFrameworkCore.SqlServer -Version 6.0.20
Update-Package Microsoft.EntityFrameworkCore.Tools -Version 6.0.20
Update-Package Microsoft.VisualStudio.Web.CodeGeneration.Design -Version 6.0.15
Update-Package Pomelo.EntityFrameworkCore.MySql -Version 7.0.0

<h4>Para Criação das tabelas Seguem comandos no Package Manager console:</h4>

Add-Migration Initial -context CadastroClienteContext
Add-Migration Users -context AppDbContext
Update-Database  -context CadastroClienteContext
Update-Database  -context AppDbContext
