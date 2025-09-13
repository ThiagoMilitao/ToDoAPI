# API de Tarefas com .NET Minimal APIs

Este é um projeto simples que desenvolvi há algum tempo para fins de aprendizado, focado nos conceitos fundamentais da criação de APIs utilizando o template de **Minimal APIs** do .NET.

A aplicação consiste em um CRUD (`Create`, `Read`, `Update`, `Delete`) completo para o gerenciamento de uma lista de tarefas (To-Do), utilizando uma lista em memória como "banco de dados" para simplificar o foco na estrutura da API.

## Tecnologias Utilizadas

* **.NET 8**
* **C#**
* **Minimal APIs**
* **Swagger / OpenAPI** para documentação e testes interativos
  
## Como Executar o Projeto

1.  **Clone o repositório:**
    ```bash
    git clone [https://github.com/seu-usuario/nome-do-seu-repositorio.git](https://github.com/seu-usuario/nome-do-seu-repositorio.git)
    ```

2.  **Navegue até a pasta do projeto:**
    ```bash
    cd nome-do-seu-repositorio
    ```

3.  **Execute a aplicação:**
    ```bash
    dotnet run
    ```

Após executar o comando, a API estará rodando em `http://localhost:XXXX` e `https://localhost:YYYY`.

Para testar os endpoints de forma interativa, acesse a documentação do Swagger em **`http://localhost:XXXX/swagger`**.

## Endpoints da API

A API fornece os seguintes endpoints para gerenciar as tarefas:

| Verbo HTTP | Rota              | Ação                       | Exemplo de Corpo (Body) da Requisição                               |
| :--------- | :---------------- | :------------------------- | :------------------------------------------------------------------ |
| `GET`      | `/tarefas`        | Lista todas as tarefas.    | N/A                                                                 |
| `GET`      | `/tarefas/{id}`   | Obtém uma tarefa por ID.   | N/A                                                                 |
| `POST`     | `/tarefas`        | Cria uma nova tarefa.      | `{ "nome": "Comprar pão", "descricao": "Ir à padaria." }`             |
| `PUT`      | `/tarefas/{id}`   | Atualiza uma tarefa.       | `{ "nome": "Estudar .NET", "descricao": "Focar em Minimal APIs", "concluido": true }` |
| `DELETE`   | `/tarefas/{id}`   | Deleta uma tarefa por ID.  | N/A                                                                 |

