# Sistema de Gestão e Controle para Entregas de Doações

Este é um sistema de gestão e controle para entregas de doações. O sistema visa permitir que entregadores (moto deliverys) possam acessar e gerenciar os locais, datas e recolhimento as doações realizadas por contribuintes.

## Front - End 
A aplicação front-end se encontra no diretório principal do projeto em EcoDeliveryApp
### Ferramentas
- Node.js (v18.20.4)
- Angular CLI (v18.2.8)
- Typescript (v5.5.4)
- NPM (v10.7.0)
### Interface e Componentes
- Angular/Material
### Compilação e execução
- cd EcoDeliveryApp
- npm install
- ng serve

## Back - End
A aplicação back-end se encontra no diretório principal do projeto em EcoDeliveryApi
  ### Ferramentas
  - C# (v9.^)
  - .Net SDK (v9.0.100)
  ### Dependências e Bibliotecas
  -  Entity Framework Core (SQL Server)
  -  Authentication JwtBearer
  - Pacote de Nível Superior
  - IdentityModel Tokens                                  
  ### Compilação e execução
  - cd EcoDeliveryApi
  - dotnet restore
  - dotnet build
  - dotnet run
* No Arquivo appsettings.js dentro do diretório principal, adicione as informações para conexão com seu banco de dados.
-- Exemplo:  "DefaultConnection": "Server=localhost;Database=eco_db;User Id=sa;Password=root;TrustServerCertificate=True;"

## Banco de dados
### Ferramenta
- SQL Server (v19.1)
### Migrações
* Após criar seu banco de dados localmente com as informações de usuário e senha execute as migrações para criar as tabelas do banco, você pode aplicar as migrações ao banco de dados usando o seguinte comando:
- dotnet ef database update



