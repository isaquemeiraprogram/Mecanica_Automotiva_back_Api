# Mecanica Automotiva

> API REST para oficinas mecânicas, gerenciando veículos, diagnósticos, agendamentos e peças.

![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![Git](https://img.shields.io/badge/git-%23F05033.svg?style=for-the-badge&logo=git&logoColor=white)

---

## Indice

- [📌 API Endpoints](#-endpoints)

## 📋 Descrição

API desenvolvida para gestão de serviços em oficinas mecânicas.

### 🎯 Objetivo

Facilitar o fluxo de trabalho entre mecânicos, atendentes e clientes, organizando diagnósticos, agendamentos e escolha de peças.

---

## 🛠️ Funcionalidades

- Registro de veículos e diagnóstico de serviços
- Agendamento de reparos e upgrades
- Escolha de peças e marcas conforme o orçamento do cliente

---

## 💻 Tecnologias Utilizadas

- C#
- ASP.NET Core
- Entity Framework Core
- MySQL 8.0 CE

---

## ✅ Pré-requisitos

- Conexão com internet
- Git
- MySQL Workbench

---

## 📦 Pacotes Usados

- **AutoMapper.Extensions.Microsoft.DependencyInjection** (v12.0.0)  
  Mapeamento automático de objetos (DTOs ↔ entidades)

- **Microsoft.EntityFrameworkCore** (v8.0.13)  
  ORM para comunicação com o banco de dados

- **Microsoft.EntityFrameworkCore.Design** (v8.0.13)  
  Suporte a comandos de scaffolding e migrations

- **Microsoft.EntityFrameworkCore.Relational** (v8.0.13)  
  Recursos de banco de dados relacional

- **Microsoft.EntityFrameworkCore.Tools** (v8.0.13)  
  Ferramentas de linha de comando para EF Core

- **Pomelo.EntityFrameworkCore.MySql** (v8.0.3)  
  Provider MySQL para Entity Framework Core

- **Swashbuckle.AspNetCore** (v6.6.2)  
  Geração automática de documentação Swagger/OpenAPI

---

## 🧰 Instruções de Instalação

1. Crie uma pasta para guardar o projeto
1. Clique com o botão direito na pasta e selecione **Open Git Bash Here**
1. No terminal, execute:

    ```bash
    git clone https://github.com/isaquemeiraprogram/Mecanica_Automotiva_back_Api.git
    ```

1. Abra o MySQL Workbench e execute:

    ```sql
    CREATE DATABASE mecanica;
    ```

1. Abra o arquivo `Mecanica_Automotiva.sln` na IDE (Visual Studio)
1. Vá em **Ferramentas > Gerenciador de Pacotes NuGet > Console do Gerenciador de Pacotes**
1. No terminal após `PM>`, execute:

```bash
update-database
```

---

## ▶️ Instruções de Uso

- Execute o projeto na IDE.
- Acesse: `https://localhost:7190/swagger/index.html`

### Exemplos de Ações

- **Verificar os endpoints disponíveis na interface Swagger**
- **Cadastrar:**

    veículos

    Agendamentos

    Categorias para Produto

    Clientes

    Enderecos

    Marcas de Produto

    Marcas de Veiculo

    Modelos de Veiculo

    Produtos

    Servicos

    SubCategorias para Produto

    Veiculos
- **Requisitar os dados cadastrados**

---

## 🔗 Endpoints

- Todos os IDs utilizados estão no formato GUID (UUID v4, com 36 caracteres).

- Entrada e saída de dados seguem o padrão JSON.

- Observação: Os IDs fornecidos nos exemplos são genéricos e não correspondem a objetos reais do sistema — são utilizados apenas para fins demonstrativos.

### Cliente `/api/Cliente`

- **Nota:** O modelo `Cliente` não inclui endereço por padrão. Endereços são adicionados separadamente, e uma vez vinculados a um cliente, o modelo `Endereco` retorna os dados do cliente relacionado.

#### 🔹 GET `/api/Cliente`

Descrição: Retorna uma lista de clientes.

- **Parametro (request):** Sem parametro
- **Ex de rota:** <https://localhost:7190/api/Cliente>
- **Entrada (request):**  Sem corpo
- **Saída (response):**

<!-- markdownlint-disable MD033 -->
<details><summary>Visualizar saída</summary>

```json
{
  [
    {
      "id": "08ddcbd0-ab70-495d-8ecc-601def1584e4",
      "nome": "joca",
      "cpf": "82525895665",
      "endereco": []
    },
    {
      "id": "08ddcd71-b582-4bae-87a6-b8ffad550391",
      "nome": "marcelo",
      "cpf": "49845154187",
      "endereco": []
    }
  ]
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 GET `/api/Cliente/{id}`

Descrição: Retorna um Cliente apartir de um id.

**Parametro de rota:** id

- **Ex de rota:** <https://localhost:7190/api/Cliente/08ddcbd0-ab70-495d-8ecc-601def1584e4>

 **Entrada (request):** Sem corpo

 **Saída (response):**

<!-- markdownlint-disable MD033 -->
 <details><summary>Visualizar saída teste</summary>

```json
{
  {
    "id": "08ddcbd0-ab70-495d-8ecc-601def1584e4",
    "nome": "string",
    "cpf": "string",
    "endereco": []
  }
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 POST `/api/Cliente`

Descrição:Adiciona um Cliente.

- **Parametro (request):** Sem parametro
- **Ex de rota:** <https://localhost:7190/api/Cliente>

- **Entrada (request):**

<!-- markdownlint-disable MD033 -->
 <details>
 <summary>Visualizar Entrada</summary>

```json
{
  "nome": "string",
  "cpf": "string"
}
```

</details> <!-- markdownlint-enable MD033 --> ``

**Saída (response):**

<!-- markdownlint-disable MD033 -->
 <details>
 <summary>Visualizar saída</summary>

```json
{
  "id": "08ddcd71-b582-4bae-87a6-b8ffad550391",
  "nome": "marcelo",
  "cpf": "49845154187",
  "endereco": []
}
```

</details> <!-- markdownlint-enable MD033 --> ``
```

#### 🔹 PUT `/api/Cliente/{id}`

Descrição: atualiza um Cliente apartir de um id

**Parametro de rota:** id

- **Ex de rota:** <https://localhost:7190/api/Cliente/3fa85f64-5717-4562-b3fc-2c963f66afa6>

- **Entrada (request):**

<!-- markdownlint-disable MD033 -->
 <details>
 <summary>Visualizar Entrada</summary>

```json
{
  "nome": "string",
  "cpf": "string"
}
```

</details> <!-- markdownlint-enable MD033 --> ``

**Saída (response):**

<!-- markdownlint-disable MD033 -->
 <details>
 <summary>Visualizar saída</summary>

```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "nome": "string",
  "cpf": "string",
  "endereco": []
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 DELETE `/api/Cliente/{id}`

Descrição: Deleta um Cliente apartir de um id

- **Parametro (request):** Sem parametro
- **Ex de rota:** <https://localhost:7190/api/Cliente>
- **Entrada (request):** Sem corpo

</details> <!-- markdownlint-enable MD033 --> ``

- **Saída (response):**

<!-- markdownlint-disable MD033 -->
<details><summary>Visualizar saída</summary>

```json
{
  true
}
```

</details> <!-- markdownlint-enable MD033 --> ``

### Endereco `/api/Endereco`

- **Nota:** É necessario haver um `Cliente` para poder gerar um `Endereco`.

#### 🔹 POST `/api/Endereco`

Descrição:Adiciona um Endereco.

- **Parametro (request):** Sem parametro
- **Ex de rota:** <https://localhost:7190/api/Endereco>

- **Entrada (request):**

<!-- markdownlint-disable MD033 -->
 <details>
 <summary>Visualizar Entrada</summary>

```json
{
  "cep": "string",
  "estado": "string",
  "cidade": "string",
  "bairro": "string",
  "rua": "string",
  "numero": "string",
  "clienteId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
}
```

</details> <!-- markdownlint-enable MD033 --> ``

**Saída (response):**

<!-- markdownlint-disable MD033 -->
 <details>
 <summary>Visualizar saída teste</summary>

```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "cep": "string",
  "estado": "string",
  "cidade": "string",
  "bairro": "string",
  "rua": "string",
  "numero": "string"
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 PUT `/api/Endereco/{id}`

Descrição: atualiza um Endereco apartir de um id

**Parametro de rota:** id

- **Ex de rota:** <https://localhost:7190/api/Endereco/3fa85f64-5717-4562-b3fc-2c963f66afa6>

- **Entrada (request):**

<!-- markdownlint-disable MD033 -->
 <details>
 <summary>Visualizar Entrada</summary>

```json
{
  "cep": "string",
  "estado": "string",
  "cidade": "string",
  "bairro": "string",
  "rua": "string",
  "numero": "string",
  "clienteId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
}
```

</details> <!-- markdownlint-enable MD033 --> ``

**Saída (response):**

<!-- markdownlint-disable MD033 -->
 <details>
 <summary>Visualizar saída</summary>

```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "cep": "string",
  "estado": "string",
  "cidade": "string",
  "bairro": "string",
  "rua": "string",
  "numero": "string"
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 DELETE `/api/Endereco/{id}`

Descrição: Deleta um Endereco apartir de um id

- **Parametro (request):** Sem parametro
- **Ex de rota:** <https://localhost:7190/api/Endereco>
- **Entrada (request):** Sem corpo

- **Saída (response):**

<!-- markdownlint-disable MD033 -->
<details><summary>Visualizar saída</summary>

```json
{
  true
}
```

</details> <!-- markdownlint-enable MD033 --> ``

### 📂 EmxemploDocumentacao `/api/MarcaProduto`

#### 🔹 GET `/api/MarcaProduto`

Descrição: Retorna uma lista de Marcas de Produtos.

- **Parametro (request):** Sem parametro
- **Ex de rota:** <https://localhost:7190/api/MarcaProduto>
- **Entrada (request):**  Sem corpo
- **Saída (response):**

<!-- markdownlint-disable MD033 -->
<details><summary>Visualizar saída</summary>

```json
{
  [
    {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "nome": "string"
    }
  ]
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 GET `/api/MarcaProduto/{id}`

Descrição: Retorna uma Marca de um Produto apartir de um id.

**Parametro de rota:** id

- **Ex de rota:** <https://localhost:7190/api/teste/3fa85f64-5717-4562-b3fc-2c963f66afa6>

 **Entrada (request):** Sem corpo

 **Saída (response):**

<!-- markdownlint-disable MD033 -->
 <details><summary>Visualizar saída teste</summary>

```json
  {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "nome": "string"
  }
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 POST `/api/MarcaProduto`

Descrição:Adiciona uma Marca de Produto

- **Parametro (request):** Sem parametro
- **Ex de rota:** <https://localhost:7190/api/MarcaProduto>

- **Entrada (request):**

<!-- markdownlint-disable MD033 -->
 <details>
 <summary>Visualizar Entrada</summary>

```json
{
  "nome": "string"
}
```

</details> <!-- markdownlint-enable MD033 --> ``

**Saída (response):**

<!-- markdownlint-disable MD033 -->
 <details>
 <summary>Visualizar saída</summary>

```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "nome": "string"
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 PUT `/api/MarcaProduto/{id}`

Descrição: atualiza uma Marca de Produto apartir de um id

**Parametro de rota:** id

- **Ex de rota:** <https://localhost:7190/api/MarcaProduto/3fa85f64-5717-4562-b3fc-2c963f66afa6>

- **Entrada (request):**

<!-- markdownlint-disable MD033 -->
 <details>
 <summary>Visualizar Entrada</summary>

```json
{
  "nome": "string"
}
```

</details> <!-- markdownlint-enable MD033 --> ``

**Saída (response):**

<!-- markdownlint-disable MD033 -->
 <details>
 <summary>Visualizar saída</summary>

```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "nome": "string"
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 DELETE `/api/MarcaProduto/{id}`

Descrição: Deleta uma Marca de Produto apartir de um id

- **Parametro (request):** Sem parametro
- **Ex de rota:** <https://localhost:7190/api/MarcaProduto>
- **Entrada (request):** Sem corpo

- **Saída (response):**

<!-- markdownlint-disable MD033 -->
<details><summary>Visualizar saída</summary>

```json
{
  true
}
```

</details> <!-- markdownlint-enable MD033 --> ``

## 📄 Licença

Licença em definição. O uso pessoal e acadêmico está liberado.

---

## 🙋‍♂️ Autor

Isaque Anacleto de Meira  
Desenvolvedor Back-End .NET  
[GitHub](https://github.com/isaquemeiraprogram) | [LinkedIn](https://www.linkedin.com/in/isaque-adm)
