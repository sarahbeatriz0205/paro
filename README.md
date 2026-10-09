<div align="center">
<img src="frontend/imgs/marca.png" width="150px" height="150px" />

  # Parô! Jogo de adedonha
  
</div>


Inspirado na plataforma de jogo de adedonha [**Stopots**](https://stopots.com/pt), este projeto acadêmico construído na disciplina de Desenvolvimento de Sistemas Distribuídos do curso de Análise e Desenvolvimento de Sistemas (IFRN) é uma aplicação web desenvolvida com o framework **ASP.NET Core** utilizando o conceito de **API REST**, tendo como objetivo a aplicação prática dos conhecimentos adquiridos na disciplina.

## Tecnologias utilizadas
- **Linguagem C#**
- **ASP.NET Core**
- **SQLite**
- **HTML, CSS e Javascript**

## O que contém no projeto:
- **Autenticação via token JWT para o criador de uma sala**
- **Cliente web que realiza as requisições (HTML + CSS + Javascript puros)**
- **API Gateway que intercepta a requisição vinda do cliente web**
- **Implementação de duas APIs que simulam dois microsserviços (```Auth``` e ```Paro```)**
- **Documentação das APIs ```Auth``` e ```Paro``` via Swagger**
- **Implementação do conceito de HATEOAS**

## Principais _endpoints_
### Autenticação (Auth)
~~~
http://localhost:5288/api/auth/criar
http://localhost:5288/api/auth/login
~~~

### Jogo (Paro)
~~~
http://localhost:5288/api/sala/criar-sala
http://localhost:5288/api/sala/entrar
http://localhost:5288/api/rodada/criar-rodada
~~~

## Como acessar
### Frontend
http://localhost:5500
### Documentação (Swagger)
http://localhost:5288/swagger
### Gateway
http://localhost:5288
### Auth
http://localhost:5253
### Paro
http://localhost:5204
