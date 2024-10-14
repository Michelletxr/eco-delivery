# Sistema de Gestão e Controle para Entregas de Doações 

Este sistema é uma plataforma de gestão e controle para entregas de doações, projetada para facilitar o trabalho de entregadores (motoboys). Através deste sistema, os entregadores podem acessar e gerenciar informações sobre locais de coleta, datas e registros das doações feitas pelos contribuintes. O sistema visa otimizar a logística das entregas e auxiliar o processo de doação.

## Front - End :computer:
A aplicação front-end se encontra no diretório principal do projeto em EcoDeliveryApp
### Ferramentas
- Node.js (v18.20.4)
- Angular CLI (v18.2.8)
- Typescript (v5.5.4)
- NPM (v10.7.0)
### Interface e Componentes
- Angular/Material
### Compilação e execução
Siga os passos abaixo para compilar e executar a aplicação front-end:
```bash
$ cd EcoDeliveryApp
$ npm install
$ ng serve
```
## Back - End :wrench:
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
  ```bash
  $ cd EcoDeliveryApi
  $ dotnet restore
  $ dotnet build
  $ dotnet run
  ```
No Arquivo appsettings.js dentro do diretório principal, adicione as informações para conexão com seu banco de dados.
- Exemplo:  "DefaultConnection": "Server=localhost;Database=eco_db;User Id=sa;Password=root;TrustServerCertificate=True;"

## Banco de dados :bank:
### Ferramenta
- SQL Server (v19.1)
### Migrações
Após criar seu banco de dados localmente com as informações de usuário e senha execute as migrações para criar as tabelas do banco, você pode aplicar as migrações ao banco de dados usando o seguinte comando:
- dotnet ef database update

  



