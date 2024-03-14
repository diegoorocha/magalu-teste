# Projeto C# / Web - Teste Magalu

[![forthebadge](http://forthebadge.com/images/badges/built-with-love.svg)](http://forthebadge.com)

[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=shields)](http://makeapullrequest.com)

### - >  Qual é a missão deste protejo ? Criar um `CRUD` de Clientes, com listagem, filtros, validações, toaster e paginação.

Projeto criado em `.NET 7`, utilizando `MVC` com design patterns de `três camadas`.
Utilizado banco de dados `MYSql`, com o ORM `entity framework core 7`.

# Requisitos
- Visual Studio instalado e funcionando;
- Bando de dados MYSql instalado e funcionando;

# Instalação 

1 - Configurar a connection string na sua máquina, a default do projeto é : `server=127.0.0.1;uid=root;pwd=root;database=magalu`.
-- *Recomendo em seu banco de dados MY SQL em localhost, crie um banco chamado `magalu`, para não editar os scripts.*

2 - Em seu banco de dados MY SQL, será necessário executar os scrips que estão na pasta do projeto chamado `scripts`.
-- *Executar o primeiro script chamado: `CREATE TABLE - CLIENTE.sql` para criar a tabela `cliente`.*
-- *Executar o segundo script chamado: `INSERT TABLE - CLIENTE.sql` para inserir dados a tabela.*

3 - Executar o projeto WEB chamado `DSR-MAGALU-WEB`, necessário defini-lo como projeto de inicialização !

# Projeto rodando

- Ao rodar o projeto, ele vai para a página de listagem de clientes:
  <a href="https://ibb.co/86tXBSp"><img src="https://i.ibb.co/BqFwPSx/imagem-2024-03-14-204710773.png" alt="imagem-2024-03-14-204710773" border="0"></a>



