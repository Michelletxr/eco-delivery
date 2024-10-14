# Sistema de Gestão e Controle para Entregas de Doações

Este é um sistema de gestão e controle para entregas de doações. O sistema visa permitir que entregadores (moto deliverys) possam acessar e gerenciar os locais, datas e recolhimento as doações realizadas por contribuintes.

## Front - End 
### Ferramentas
- Node.js (v18.20.4)
- Angular CLI (v18.2.8)
- Typescript (v5.5.4)
- NPM (v10.7.0)
### Interface e Componentes
- Angular/Material
#### Compilação e execução
- cd EcoDeliveryApp
- npm install
- ng serve

## Back - End
  ### Ferramentas
  - C#
  - .Net SDK
  ### Depências e Bibliotecas
  -  Entity Framework Core (SQL Server)
  -  Authentication JwtBearer
  - Pacote de Nível Superior
  - IdentityModel Tokens                                  
  ### Compilação e execução
  - cd EcoDeliveryApi
  - dotnet restore
  - dotnet build
  - dotnet run
- No Arquivo appsettings.js dentro do diretório principal, adicione as informações para conexão com seu banco de dados.
- - Exemplo:  "DefaultConnection": "Server=localhost;Database=eco_db;User Id=sa;Password=root;TrustServerCertificate=True;"


