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

# Projeto rodando (explicando como funciona as telas de forma simplificada)

- [ TELA INDEX ] Ao rodar o projeto, ele vai para a página de listagem de clientes:
  <a href="https://ibb.co/86tXBSp"><img src="https://i.ibb.co/BqFwPSx/imagem-2024-03-14-204710773.png" alt="imagem-2024-03-14-204710773" border="0"></a>
  *Nesta retorna todos os clientes cadastrados, `que não esteja bloqueado por default`, com as informações no grid e opções para `filtrar` `visualizar` e `editar`. *

- [ TELA FILTROS ] Pa tela de filtros é necessário escolher qualquer uma da opções, sendo `nome`, `e-mail`, `telefone`, `data de cadastro`, e se está com o status `bloqueado`.
 <a href="https://ibb.co/m5mzqKV"><img src="https://i.ibb.co/MkbNVHx/imagem-2024-03-14-205456599.png" alt="imagem-2024-03-14-205456599" border="0"></a>

 - [ TELA FILTROS ] Filtro utilizado será buscando pelo `nome / razão social`, vai retornar todos (neste caso 2) que contenham o valor buscado `Carol`.
<a href="https://ibb.co/MhYZcrV"><img src="https://i.ibb.co/6Z3rHzP/imagem-2024-03-14-210017898.png" alt="imagem-2024-03-14-210017898" border="0"></a>

- [ TELA CADASTRAR ]
<a href="https://ibb.co/BP28BPW"><img src="https://i.ibb.co/3smtcs6/imagem-2024-03-14-211843837.png" alt="imagem-2024-03-14-211843837" border="0"></a>

-> Importante: Para realizar o cadastro, é necessário que TODOS os itens abaixos estejam validados, senão o botão `CADASTRAR` não será habilitado.
** Email **
** CFP / CNPJ **
** Inscrição Estadual **
** Senha e Confirma Senha **

-- E-mail (valida se a sintaxe está correta, e sem uso)
  --- Na tela ao terminar de digitar o seu e-mail, será necessário validar o e-mail em questão, clicando no botão `validar`. Após a validação (Botão piscando = E-mail inválido / Botão não piscando = E-mail bom para uso).

  
-- CPF / CNPJ (valida se a sintaxe está correta, e sem uso)
  --- Na tela ao terminar de digitar o seu documento, será necessário validar o documento em questão, clicando no botão `validar`. Após a validação (Botão piscando = Documento inválido / Botão não piscando = Documento bom para uso).

  
-- Inscrição Estadual (somente se está sem uso, quando o cliente não for isento)
  --- Na tela ao terminar de digitar a inscrição estadual, será necessário validar o documento em questão, clicando no botão `validar`. Após a validação (Botão piscando = Inscrição estadual inválida / Botão não piscando = Inscrição estadual boa para uso).

  <a href="https://ibb.co/vVSNJYS"><img src="https://i.ibb.co/mb3nH83/imagem-2024-03-14-212333422.png" alt="imagem-2024-03-14-212333422" border="0"></a>
  *Validação de TODOS os itens realizada com sucesso.*

  <a href="https://ibb.co/0F97XTL"><img src="https://i.ibb.co/qWgSnK8/imagem-2024-03-14-213141213.png" alt="imagem-2024-03-14-213141213" border="0"></a>
  *Validação evidenciando os erros ao validar os dados.*

<a href="https://ibb.co/ZJwgCyC"><img src="https://i.ibb.co/n0V1ShS/imagem-2024-03-14-213555052.png" alt="imagem-2024-03-14-213555052" border="0"></a>
  *Validação das senhas quando elas não são iguais.*

<a href="https://ibb.co/BfhsR61"><img src="https://i.ibb.co/TwQh50C/imagem-2024-03-14-213851685.png" alt="imagem-2024-03-14-213851685" border="0"></a>
    *Tela com todos os dados validados, pronto para cadastrar.*

- Ao cadastrar com sucesso, será redirecionado para `[ TELA INDEX ]`.

- [ TELA DETALHES ]
  <a href="https://ibb.co/mTMvPr7"><img src="https://i.ibb.co/nm53KqS/imagem-2024-03-14-214515849.png" alt="imagem-2024-03-14-214515849" border="0"></a>

- [ TELA EDIÇÃO ]
  <a href="https://ibb.co/PGwDdXS"><img src="https://i.ibb.co/RTzjqr5/imagem-2024-03-14-214647532.png" alt="imagem-2024-03-14-214647532" border="0"></a>
  *Não será necessário validar os dados antes de enviar as edições.*
  
