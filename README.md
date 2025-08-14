# Mecanica Automotiva

> API REST para oficinas mecânicas, gerenciando veículos, diagnósticos, agendamentos e peças.

![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![Git](https://img.shields.io/badge/git-%23F05033.svg?style=for-the-badge&logo=git&logoColor=white)

---

## Indice

- [📋 Descrição](#-descrição)
- [🎯 Objetivo](#-objetivo)
- [🛠️ Funcionalidades](#️-funcionalidades)
- [💻 Tecnologias Utilizadas](#-tecnologias-utilizadas)
- [✅ Pré-requisitos](#-pré-requisitos)
- [📦 Pacotes Usados](#-pacotes-usados)
- [🧰 Instruções de Instalação](#-instruções-de-instalação)
- [▶️ Instruções de Uso](#️-instruções-de-uso)
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

<!-- markdownlint-disable MD033 -->
<details><summary><h3>📂Visualizar metodos</h3></summary>

- **Nota:** O modelo `Cliente` não inclui endereço por padrão. Endereços são adicionados separadamente, e uma vez vinculados a um cliente, o modelo `Endereco` retorna os dados do cliente relacionado.

#### 🔹 GET `/api/Cliente`

Descrição: Retorna uma lista de clientes.

- **Parametro (request):** Sem parametro
- **Ex de rota:** <https://localhost:7190/api/Cliente>
- **Entrada (request):**  Sem corpo
- **Saída (response):**

<details><summary>Visualizar saída</summary>

```json
{
  [
    {
      "id": "08ddcbd0-ab70-495d-8ecc-601def1584e4",
      "nome": "string",
      "cpf": "string"
    }
  ]
}
```

</details>

#### 🔹 GET `/api/Cliente/cpf/{cpf}`

Descrição: Retorna um Cliente apartir de um cpf.

**Parametro de rota:** cpf

- **Ex de rota:** <https://localhost:7190/api/Cliente/cpf/000.000.000-00>

 **Entrada (request):** Sem corpo

 **Saída (response):**

 <details><summary>Visualizar saída teste</summary>

```json
{
  {
    "id": "08ddcbd0-ab70-495d-8ecc-601def1584e4",
    "nome": "string",
    "cpf": "string"
  }
}
```

</details>

#### 🔹 POST `/api/Cliente`

Descrição:Adiciona um Cliente.

- **Parametro (request):** Sem parametro
- **Ex de rota:** <https://localhost:7190/api/Cliente>

- **Entrada (request):**

 <details><summary>Visualizar Entrada</summary>

```json
{
  "nome": "string",
  "cpf": "string"
}
```

</details>

**Saída (response):**

 <details>
 <summary>Visualizar saída</summary>

```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "nome": "string",
  "cpf": "string",
}
```

</details>
```

#### 🔹 PUT `/api/Cliente/cpf/{cpf}`

Descrição: atualiza um Cliente apartir de um cpf

**Parametro de rota:** cpf

- **Ex de rota:** <https://localhost:7190/api/Cliente/cpf/000.000.000-00>

- **Entrada (request):**

 <details><summary>Visualizar Entrada</summary>

```json
{
  "nome": "string",
  "cpf": "string"
}
```

</details>

**Saída (response):**

 <details>
 <summary>Visualizar saída</summary>

```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "nome": "string",
  "cpf": "string",
}
```

</details>

#### 🔹 DELETE `/api/Cliente/cpf/{cpf}`

Descrição: Deleta um Cliente apartir de um cpf

**Parametro de rota:** cpf

- **Ex de rota:** <https://localhost:7190/api/Cliente/cpf/000.000.000-00>
- **Entrada (request):** Sem corpo

- **Saída (response):**

<details><summary>📤 Visualizar saída</summary>

```json
{
  true
}
```

</details>

</details> <!-- markdownlint-enable MD033 --> ``

### Endereco `/api/Endereco`

<!-- markdownlint-disable MD033 -->
<details><summary><h3>📂Visualizar metodos</h3></summary>

- **Nota:** É necessario haver um `Cliente` cadastrado para poder gerar um `Endereco`.

#### 🔹 GET `/api/Endereco/cpf/{cpf}`

Descrição: Retorna todos os enderecos de um cliente apartir de um cpf.

**Parametro de rota:** cpf

- **Ex de rota:** <https://localhost:7190/api/Endereco/cpf/00000000000>

**Entrada (request):** Sem corpo

**Saída (response):**

<details><summary>Visualizar saída</summary>

```json
{
  [
  {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "cep": "string",
    "estado": "string",
    "cidade": "string",
    "bairro": "string",
    "rua": "string",
    "numero": "string",
    "complemento": "string",
    "cliente": {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "nome": "string",
      "cpf": "string"
    }
  }
]
}

```

</details>

#### 🔹 POST `/api/Endereco`

Descrição:Adiciona um Endereco.

- **Parametro (request):** Sem parametro
- **Ex de rota:** <https://localhost:7190/api/Endereco>

- **Entrada (request):**

 <details><summary>Visualizar Entrada</summary>

```json
{
  "cep": "string",
  "estado": "string",
  "cidade": "string",
  "bairro": "string",
  "rua": "string",
  "numero": "string",
  "complemento": "string",
  "clienteCpf": "string"
}
```

</details>

**Saída (response):**

 <details><summary>Visualizar saída teste</summary>

```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "cep": "string",
  "estado": "string",
  "cidade": "string",
  "bairro": "string",
  "rua": "string",
  "numero": "string",
  "complemento": "string"
}
```

</details>

#### 🔹 PUT `/api/Endereco/{id}`

Descrição: atualiza um Endereco apartir de um id

**Parametro de rota:** id

- **Ex de rota:** <https://localhost:7190/api/Endereco/3fa85f64-5717-4562-b3fc-2c963f66afa6>

- **Entrada (request):**

 <details><summary>Visualizar Entrada</summary>

```json
{
  "cep": "string",
  "estado": "string",
  "cidade": "string",
  "bairro": "string",
  "rua": "string",
  "numero": "string",
  "complemento": "string",
  "clienteCpf": "string"
}
```

</details>

**Saída (response):**

 <details><summary>Visualizar saída</summary>

```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "cep": "string",
  "estado": "string",
  "cidade": "string",
  "bairro": "string",
  "rua": "string",
  "numero": "string",
  "complemento": "string"
}
```

</details>

#### 🔹 DELETE `/api/Endereco/{id}`

Descrição: Deleta um Endereco apartir de um id

**Parametro de rota:** id

- **Ex de rota:** <https://localhost:7190/api/Endereco/3fa85f64-5717-4562-b3fc-2c963f66afa6>
- **Entrada (request):** Sem corpo

- **Saída (response):**

<details><summary>Visualizar saída</summary>

```json
{
  true
}
```

</details>

</details> <!-- markdownlint-enable MD033 --> ``

### MarcaProduto `/api/MarcaProduto`

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

**Parametro de rota:** id

- **Ex de rota:** <https://localhost:7190/api/MarcaProduto/3fa85f64-5717-4562-b3fc-2c963f66afa6>
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

### CategoriaProduto `/api/CategoriaProduto`

#### 🔹 GET `/api/CategoriaProduto`

Descrição: Retorna uma lista de Categorias de Produtos.

- **Parametro (request):** Sem parametro
- **Ex de rota:** <https://localhost:7190/api/CategoriaProduto>
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

#### 🔹 GET `/api/CategoriaProduto/{id}`

Descrição: Retorna uma Categoria de Produto apartir de um id.

**Parametro de rota:** id

- **Ex de rota:** <https://localhost:7190/api/CategoriaProduto/3fa85f64-5717-4562-b3fc-2c963f66afa6>

 **Entrada (request):** Sem corpo

 **Saída (response):**

<!-- markdownlint-disable MD033 -->
 <details><summary>Visualizar saída</summary>

```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "nome": "string"
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 POST `/api/CategoriaProduto`

Descrição:Adiciona uma Categoria de Produto

- **Parametro (request):** Sem parametro
- **Ex de rota:** <https://localhost:7190/api/CategoriaProduto>

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

#### 🔹 PUT `/api/CategoriaProduto/{id}`

Descrição: atualiza uma Categoria de Produtoe apartir de um id

**Parametro de rota:** id

- **Ex de rota:** <https://localhost:7190/api/CategoriaProduto/3fa85f64-5717-4562-b3fc-2c963f66afa6>

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

#### 🔹 DELETE `/api/CategoriaProduto/{id}`

Descrição: Deleta uma Categoria de Produto apartir de um id

**Parametro de rota:** id

- **Ex de rota:** <https://localhost:7190/api/CategoriaProduto/3fa85f64-5717-4562-b3fc-2c963f66afa6>
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

### SubCategoriaProduto `/api/SubCategoriaProduto`

- **Nota:** É necessario haver uma `CategoriaProduto` cadastrada para poder gerar uma `SubCategoriaProduto`.

#### 🔹 GET `/api/SubCategoriaProduto`

Descrição: Retorna uma lista de SubCategorias de Produtos.

- **Parametro (request):** Sem parametro
- **Ex de rota:** <https://localhost:7190/api/SubCategoriaProduto>
- **Entrada (request):**  Sem corpo
- **Saída (response):**

<!-- markdownlint-disable MD033 -->
<details><summary>Visualizar saída</summary>

```json
{
  [
    {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "nome": "string",
      "categoriaProduto": {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "nome": "string"
      }
    }
  ]
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 GET `/api/SubCategoriaProduto/{id}`

Descrição: Retorna uma SubCategoria de Produto apartir de um id.

**Parametro de rota:** id

- **Ex de rota:** <https://localhost:7190/api/SubCategoriaProduto/3fa85f64-5717-4562-b3fc-2c963f66afa6>

 **Entrada (request):** Sem corpo

 **Saída (response):**

<!-- markdownlint-disable MD033 -->
 <details><summary>Visualizar saída</summary>

```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "nome": "string",
  "categoriaProduto": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "nome": "string"
  }
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 POST `/api/SubCategoriaProduto`

Descrição:Adiciona uma SubCategoria de Produto

- **Parametro (request):** Sem parametro
- **Ex de rota:** <https://localhost:7190/api/SubCategoriaProduto>

- **Entrada (request):**

<!-- markdownlint-disable MD033 -->
 <details>
 <summary>Visualizar Entrada</summary>

```json
{
  "nome": "string",
  "categoriaId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
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
  "categoriaProduto": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "nome": "string"
  }
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 PUT `/api/SubCategoriaProduto/{id}`

Descrição: atualiza uma SubCategoria de Produto apartir de um id

**Parametro de rota:** id

- **Ex de rota:** <https://localhost:7190/api/SubCategoriaProduto/3fa85f64-5717-4562-b3fc-2c963f66afa6>

- **Entrada (request):**

<!-- markdownlint-disable MD033 -->
 <details>
 <summary>Visualizar Entrada</summary>

```json
{
  "nome": "string",
  "categoriaId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
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
  "categoriaProduto": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "nome": "string"
  }
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 DELETE `/api/SubCategoriaProduto/{id}`

Descrição: Deleta uma SubCategoria de Produto apartir de um id

**Parametro de rota:** id

- **Ex de rota:** <https://localhost:7190/api/SubCategoriaProduto/3fa85f64-5717-4562-b3fc-2c963f66afa6>
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

#### 🔹 GET `/FiltroPorCategoria/{id}`

Descrição: Retorna todas as subcategorias pertencentes a categoria do id enviada no parametro.

**Parametro de rota:** id

- **Ex de rota:** <https://localhost:7190/FiltroPorCategoria/08ddce32-dbae-4985-807a-2ebf4772c5c0>

 **Entrada (request):** Sem corpo

 **Saída (response):**

<!-- markdownlint-disable MD033 -->
 <details><summary>Visualizar saída</summary>

```json
[
  {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "nome": "string",
    "categoriaProduto": {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "nome": "string"
    }
  }
]
```

</details> <!-- markdownlint-enable MD033 --> ``

### MarcaVeiculo `/api/MarcaVeiculo`

#### 🔹 GET `/api/MarcaVeiculo`

Descrição: Retorna uma lista de Marcas de Veiculo.

- **Parametro (request):** Sem parametro
- **Ex de rota:** <https://localhost:7190/api/MarcaVeiculo>
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

#### 🔹 GET `/api/MarcaVeiculo/{id}`

Descrição: Retorna uma Marca de Veiculo apartir de um id.

**Parametro de rota:** id

- **Ex de rota:** <https://localhost:7190/api/MarcaVeiculo/3fa85f64-5717-4562-b3fc-2c963f66afa6>

 **Entrada (request):** Sem corpo

 **Saída (response):**

<!-- markdownlint-disable MD033 -->
 <details><summary>Visualizar saída</summary>

```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "nome": "string"
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 POST `/api/MarcaVeiculo`

Descrição:Adiciona uma Marca de Veiculo

- **Parametro (request):** Sem parametro
- **Ex de rota:** <https://localhost:7190/api/MarcaVeiculo>

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

#### 🔹 PUT `/api/MarcaVeiculo/{id}`

Descrição: atualiza uma Marca de Veiculo apartir de um id

**Parametro de rota:** id

- **Ex de rota:** <https://localhost:7190/api/MarcaVeiculo/3fa85f64-5717-4562-b3fc-2c963f66afa6>

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

#### 🔹 DELETE `/api/MarcaVeiculo/{id}`

Descrição: Deleta uma Marca de Veiculo apartir de um id

**Parametro de rota:** id

- **Ex de rota:** <https://localhost:7190/api/MarcaVeiculo/3fa85f64-5717-4562-b3fc-2c963f66afa6>
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

### ModeloVeiculo `/api/ModeloVeiculo`

- **Nota:** É necessario haver uma `MarcaVeiculo` cadastrada para poder gerar um `ModeloVeiculo`.
- Categorias de Veículo

| Código | Categoria      |
|--------|----------------|
| 0      | Todas          |
| 1      | Hatch          |
| 2      | Sedan          |
| 3      | SUV            |
| 4      | Pickup         |
| 5      | Crossover      |
| 6      | Perua          |
| 7      | Cupê           |
| 8      | Conversível    |
| 9      | Roadster       |
| 10     | Minivan        |
| 11     | Van            |
| 12     | Buggy          |

#### 🔹 GET `/api/ModeloVeiculo`

Descrição: Retorna uma lista de Modelos de Veiculo.

- **Parametro (request):** Sem parametro
- **Ex de rota:** <https://localhost:7190/api/ModeloVeiculo>
- **Entrada (request):**  Sem corpo
- **Saída (response):**

<!-- markdownlint-disable MD033 -->
<details><summary>Visualizar saída</summary>

```json
{
  [
    {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "nome": "string",
      "marcaVeiculo": {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "nome": "string"
      },
      "categoriaVeiculo": 0
    }
  ]
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 GET `/api/ModeloVeiculo/{id}`

Descrição: Retorna um Modelo de Veiculo apartir de um id.

**Parametro de rota:** id

- **Ex de rota:** <https://localhost:7190/api/ModeloVeiculo/3fa85f64-5717-4562-b3fc-2c963f66afa6>

 **Entrada (request):** Sem corpo

 **Saída (response):**

<!-- markdownlint-disable MD033 -->
 <details><summary>Visualizar saída</summary>

```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "nome": "string",
  "marcaVeiculo": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "nome": "string"
  },
  "categoriaVeiculo": 0
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 POST `/api/ModeloVeiculo`

Descrição:Adiciona um Modelo de Veiculo

- **Parametro (request):** Sem parametro
- **Ex de rota:** <https://localhost:7190/api/ModeloVeiculo>

- **Entrada (request):**

<!-- markdownlint-disable MD033 -->
 <details>
 <summary>Visualizar Entrada</summary>

```json
{
  "nome": "string",
  "marcaId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "categoriaVeiculo": 0
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
  "marcaVeiculo": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "nome": "string"
  },
  "categoriaVeiculo": 0
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 PUT `/api/ModeloVeiculo/{id}`

Descrição: atualiza um Modelo de Veiculo apartir de um id

**Parametro de rota:** id

- **Ex de rota:** <https://localhost:7190/api/ModeloVeiculo/3fa85f64-5717-4562-b3fc-2c963f66afa6>

- **Entrada (request):**

<!-- markdownlint-disable MD033 -->
 <details>
 <summary>Visualizar Entrada</summary>

```json
{
  "nome": "string",
  "marcaId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "categoriaVeiculo": 0
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
  "marcaVeiculo": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "nome": "string"
  },
  "categoriaVeiculo": 0
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 DELETE `/api/ModeloVeiculo/{id}`

Descrição: Deleta um Modelo de Veiculo apartir de um id

**Parametro de rota:** id

- **Ex de rota:** <https://localhost:7190/api/ModeloVeiculo/3fa85f64-5717-4562-b3fc-2c963f66afa6>
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

### Veiculo `/api/Veiculo`

- **Nota:** É necessario haver uma `ModeloVeiculo` cadastrado para poder gerar um `Veiculo`.

#### 🔹 GET `/api/Veiculo`

Descrição: Retorna uma lista de Veiculos.

- **Parametro (request):** Sem parametro
- **Ex de rota:** <https://localhost:7190/api/Veiculo>
- **Entrada (request):**  Sem corpo
- **Saída (response):**

<!-- markdownlint-disable MD033 -->
<details><summary>Visualizar saída</summary>

```json
{
  [
    {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "placa": "string",
      "modelo": {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "nome": "string",
        "marcaVeiculo": {
          "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          "nome": "string"
        },
        "categoriaVeiculo": 0
      },
      "ano": 0
    }
  ]
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 GET `/api/Veiculo/{id}`

Descrição: Retorna um agendamento apartir de um id.

**Parametro de rota:** id

- **Ex de rota:** <https://localhost:7190/api/Veiculo/3fa85f64-5717-4562-b3fc-2c963f66afa6>

 **Entrada (request):** Sem corpo

 **Saída (response):**

<!-- markdownlint-disable MD033 -->
 <details><summary>Visualizar saída</summary>

```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "placa": "string",
  "modelo": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "nome": "string",
    "marcaVeiculo": {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "nome": "string"
    },
    "categoriaVeiculo": 0
  },
  "ano": 0
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 POST `/api/Veiculo`

Descrição:Adiciona um Veiculo

- **Parametro (request):** Sem parametro
- **Ex de rota:** <https://localhost:7190/api/Veiculo>

- **Entrada (request):**

<!-- markdownlint-disable MD033 -->
 <details>
 <summary>Visualizar Entrada</summary>

```json
{
  "placa": "string",
  "modeloId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "ano": 0
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
  "placa": "string",
  "modelo": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "nome": "string",
    "marcaVeiculo": {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "nome": "string"
    },
    "categoriaVeiculo": 0
  },
  "ano": 0
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 PUT `/api/Veiculo/{id}`

Descrição: atualiza um Veiculo apartir de um id

**Parametro de rota:** id

- **Ex de rota:** <https://localhost:7190/api/Veiculo/3fa85f64-5717-4562-b3fc-2c963f66afa6>

- **Entrada (request):**

<!-- markdownlint-disable MD033 -->
 <details>
 <summary>Visualizar Entrada</summary>

```json
{
  "placa": "string",
  "modeloId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "ano": 0
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
  "placa": "string",
  "modelo": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "nome": "string",
    "marcaVeiculo": {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "nome": "string"
    },
    "categoriaVeiculo": 0
  },
  "ano": 0
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 DELETE `/api/Veiculo/{id}`

Descrição: Deleta uma Veiculo apartir de um id

**Parametro de rota:** id

- **Ex de rota:** <https://localhost:7190/api/Veiculo/3fa85f64-5717-4562-b3fc-2c963f66afa6>
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

### Produto `/api/Produto`

- **Nota:** É necessario haver uma `subCategoriaProduto` uma `marcaProduto` e um `modeloVeiculo` cadastrado para poder gerar um `Produto`.

#### 🔹 GET `/api/Produto`

Descrição: Retorna uma lista de Produtos.

- **Parametro (request):** Sem parametro
- **Ex de rota:** <https://localhost:7190/api/Produto>
- **Entrada (request):**  Sem corpo
- **Saída (response):**

<!-- markdownlint-disable MD033 -->
<details><summary>Visualizar saída</summary>

```json
{
  [
    {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "img": "string",
      "nome": "string",
      "preco": "string",
      "subCategoriaProduto": {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "nome": "string",
        "categoriaProduto": {
          "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          "nome": "string"
        }
      },
      "marcaProduto": {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "nome": "string"
      },
      "qtdEstoque": 0,
      "marcasVeiculos": [
        {
          "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          "nome": "string"
        }
      ],
      "modelosVeiculos": [
        {
          "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          "nome": "string",
          "marcaVeiculo": {
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "nome": "string"
          },
          "categoriaVeiculo": 0
        }
      ]
    }
  ]
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 GET `/api/Produto/{id}`

Descrição: Retorna um Produto apartir de um id.

**Parametro de rota:** id

- **Ex de rota:** <https://localhost:7190/api/Produto/3fa85f64-5717-4562-b3fc-2c963f66afa6>

 **Entrada (request):** Sem corpo

 **Saída (response):**

<!-- markdownlint-disable MD033 -->
 <details><summary>Visualizar saída</summary>

```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "img": "string",
  "nome": "string",
  "preco": "string",
  "subCategoriaProduto": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "nome": "string",
    "categoriaProduto": {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "nome": "string"
    }
  },
  "marcaProduto": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "nome": "string"
  },
  "qtdEstoque": 0,
  "marcasVeiculos": [
    {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "nome": "string"
    }
  ],
  "modelosVeiculos": [
    {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "nome": "string",
      "marcaVeiculo": {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "nome": "string"
      },
      "categoriaVeiculo": 0
    }
  ]
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 POST `/api/Produto`

Descrição:Adiciona um Produto

- **Parametro (request):** Sem parametro
- **Ex de rota:** <https://localhost:7190/api/Produto>

- **Entrada (request):**

<!-- markdownlint-disable MD033 -->
 <details>
 <summary>Visualizar Entrada</summary>

```json
{
  "img": "string",
  "nome": "string",
  "preco": "string",
  "qtdEstoque": 0,
  "subCategoriaProdutoId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "marcaProdutoId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "modelosVeiculosIds": [
    "3fa85f64-5717-4562-b3fc-2c963f66afa6"
  ]
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
  "img": "string",
  "nome": "string",
  "preco": "string",
  "subCategoriaProduto": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "nome": "string",
    "categoriaProduto": {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "nome": "string"
    }
  },
  "marcaProduto": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "nome": "string"
  },
  "qtdEstoque": 0,
  "marcasVeiculos": [
    {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "nome": "string"
    }
  ],
  "modelosVeiculos": [
    {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "nome": "string",
      "marcaVeiculo": {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "nome": "string"
      },
      "categoriaVeiculo": 0
    }
  ]
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 PUT `/api/Produto/{id}`

Descrição: atualiza um Produto apartir de um id

**Parametro de rota:** id

- **Ex de rota:** <https://localhost:7190/api/Produto/3fa85f64-5717-4562-b3fc-2c963f66afa6>

- **Entrada (request):**

<!-- markdownlint-disable MD033 -->
 <details>
 <summary>Visualizar Entrada</summary>

```json
{
  "img": "string",
  "nome": "string",
  "preco": "string",
  "qtdEstoque": 0,
  "subCategoriaProdutoId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "marcaProdutoId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "modelosVeiculosIds": [
    "3fa85f64-5717-4562-b3fc-2c963f66afa6"
  ]
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
  "img": "string",
  "nome": "string",
  "preco": "string",
  "subCategoriaProduto": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "nome": "string",
    "categoriaProduto": {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "nome": "string"
    }
  },
  "marcaProduto": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "nome": "string"
  },
  "qtdEstoque": 0,
  "marcasVeiculos": [
    {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "nome": "string"
    }
  ],
  "modelosVeiculos": [
    {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "nome": "string",
      "marcaVeiculo": {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "nome": "string"
      },
      "categoriaVeiculo": 0
    }
  ]
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 DELETE `/api/Produto/{id}`

Descrição: Deleta uma Produto apartir de um id

**Parametro de rota:** id

- **Ex de rota:** <https://localhost:7190/api/Produto/3fa85f64-5717-4562-b3fc-2c963f66afa6>
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

### Servico `/api/Servico`

- **Nota:** É necessario haver uma `Produto` cadastrado para poder gerar um `Servico`.

#### 🔹 GET `/api/Servico`

Descrição: Retorna uma de Servicos de ex.

- **Parametro (request):** Sem parametro
- **Ex de rota:** <https://localhost:7190/api/Servico>
- **Entrada (request):**  Sem corpo
- **Saída (response):**

<!-- markdownlint-disable MD033 -->
<details><summary>Visualizar saída</summary>

```json
{
  [
    {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "nome": "string",
      "descricao": "string",
      "valor": 0,
      "duracao": "string",
      "produtos": [
        {
          "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          "img": "string",
          "nome": "string",
          "preco": "string",
          "subCategoriaProduto": {
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "nome": "string",
            "categoriaProduto": {
              "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
              "nome": "string"
            }
          },
          "marcaProduto": {
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "nome": "string"
          },
          "qtdEstoque": 0,
          "marcasVeiculos": [
            {
              "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
              "nome": "string"
            }
          ],
          "modelosVeiculos": [
            {
              "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
              "nome": "string",
              "marcaVeiculo": {
                "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                "nome": "string"
              },
              "categoriaVeiculo": 0
            }
          ]
        }
      ]
    }
  ]
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 GET `/api/Servico/{id}`

Descrição: Retorna um Servico apartir de um id.

**Parametro de rota:** id

- **Ex de rota:** <https://localhost:7190/api/Servico/3fa85f64-5717-4562-b3fc-2c963f66afa6>

 **Entrada (request):** Sem corpo

 **Saída (response):**

<!-- markdownlint-disable MD033 -->
 <details><summary>Visualizar saída</summary>

```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "nome": "string",
  "descricao": "string",
  "valor": 0,
  "duracao": "string",
  "produtos": [
    {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "img": "string",
      "nome": "string",
      "preco": "string",
      "subCategoriaProduto": {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "nome": "string",
        "categoriaProduto": {
          "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          "nome": "string"
        }
      },
      "marcaProduto": {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "nome": "string"
      },
      "qtdEstoque": 0,
      "marcasVeiculos": [
        {
          "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          "nome": "string"
        }
      ],
      "modelosVeiculos": [
        {
          "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          "nome": "string",
          "marcaVeiculo": {
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "nome": "string"
          },
          "categoriaVeiculo": 0
        }
      ]
    }
  ]
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 POST `/api/Servico`

Descrição:Adiciona um Servico

- **Parametro (request):** Sem parametro
- **Ex de rota:** <https://localhost:7190/api/Servico>

- **Entrada (request):**

<!-- markdownlint-disable MD033 -->
 <details>
 <summary>Visualizar Entrada</summary>

```json
{
  "nome": "string",
  "descricao": "string",
  "valor": 0,
  "duracao": "string",
  "produtosId": [
    "3fa85f64-5717-4562-b3fc-2c963f66afa6"
  ]
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
  "descricao": "string",
  "valor": 0,
  "duracao": "string",
  "produtos": [
    {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "img": "string",
      "nome": "string",
      "preco": "string",
      "subCategoriaProduto": {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "nome": "string",
        "categoriaProduto": {
          "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          "nome": "string"
        }
      },
      "marcaProduto": {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "nome": "string"
      },
      "qtdEstoque": 0,
      "marcasVeiculos": [
        {
          "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          "nome": "string"
        }
      ],
      "modelosVeiculos": [
        {
          "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          "nome": "string",
          "marcaVeiculo": {
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "nome": "string"
          },
          "categoriaVeiculo": 0
        }
      ]
    }
  ]
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 PUT `/api/Servico/{id}`

Descrição: atualiza um Servico apartir de um id

**Parametro de rota:** id

- **Ex de rota:** <https://localhost:7190/api/Servico/3fa85f64-5717-4562-b3fc-2c963f66afa6>

- **Entrada (request):**

<!-- markdownlint-disable MD033 -->
 <details>
 <summary>Visualizar Entrada</summary>

```json
{
  "nome": "string",
  "descricao": "string",
  "valor": 0,
  "duracao": "string",
  "produtosId": [
    "3fa85f64-5717-4562-b3fc-2c963f66afa6"
  ]
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
  "descricao": "string",
  "valor": 0,
  "duracao": "string",
  "produtos": [
    {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "img": "string",
      "nome": "string",
      "preco": "string",
      "subCategoriaProduto": {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "nome": "string",
        "categoriaProduto": {
          "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          "nome": "string"
        }
      },
      "marcaProduto": {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "nome": "string"
      },
      "qtdEstoque": 0,
      "marcasVeiculos": [
        {
          "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          "nome": "string"
        }
      ],
      "modelosVeiculos": [
        {
          "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          "nome": "string",
          "marcaVeiculo": {
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "nome": "string"
          },
          "categoriaVeiculo": 0
        }
      ]
    }
  ]
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 DELETE `/api/Servico/{id}`

Descrição: Deleta uma Servico apartir de um id

**Parametro de rota:** id

- **Ex de rota:** <https://localhost:7190/api/Servico/3fa85f64-5717-4562-b3fc-2c963f66afa6>
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

### Agendar `/api/Agendar`

#### 🔹 GET `/api/Agendar`

Descrição: Retorna uma lista de Agendamentos.

- **Parametro (request):** Sem parametro
- **Ex de rota:** <https://localhost:7190/api/Agendar>
- **Entrada (request):**  Sem corpo
- **Saída (response):**

<!-- markdownlint-disable MD033 -->
<details><summary>Visualizar saída</summary>

```json
{
  [
    {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "data": "2025-07-29",
      "hora": "string",
      "queixa": "string",
      "tempoServiçoTotal": "string",
      "valorTotal": 0,
      "servicos": [
        {
          "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          "nome": "string",
          "descricao": "string",
          "valor": 0,
          "duracao": "string",
          "produtos": [
            {
              "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
              "img": "string",
              "nome": "string",
              "preco": "string",
              "subCategoriaProduto": {
                "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                "nome": "string",
                "categoriaProduto": {
                  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                  "nome": "string"
                }
              },
              "marcaProduto": {
                "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                "nome": "string"
              },
              "qtdEstoque": 0,
              "marcasVeiculos": [
                {
                  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                  "nome": "string"
                }
              ],
              "modelosVeiculos": [
                {
                  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                  "nome": "string",
                  "marcaVeiculo": {
                    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                    "nome": "string"
                  },
                  "categoriaVeiculo": 0
                }
              ]
            }
          ]
        }
      ],
      "cliente": {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "nome": "string",
        "cpf": "string",
        "endereco": [
          {
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "cep": "string",
            "estado": "string",
            "cidade": "string",
            "bairro": "string",
            "rua": "string",
            "numero": "string"
          }
        ]
      },
      "veiculo": {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "placa": "string",
        "modelo": {
          "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          "nome": "string",
          "marcaVeiculo": {
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "nome": "string"
          },
          "categoriaVeiculo": 0
        },
        "ano": 0
      }
    }
  ]
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 GET `/api/Agendar/{id}`

Descrição: Retorna um agendamento apartir de um id.

**Parametro de rota:** id

- **Ex de rota:** <https://localhost:7190/api/Agendar/3fa85f64-5717-4562-b3fc-2c963f66afa6>

 **Entrada (request):** Sem corpo

 **Saída (response):**

<!-- markdownlint-disable MD033 -->
 <details><summary>Visualizar saída</summary>

```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "data": "2025-07-29",
  "hora": "string",
  "queixa": "string",
  "tempoServiçoTotal": "string",
  "valorTotal": 0,
  "servicos": [
    {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "nome": "string",
      "descricao": "string",
      "valor": 0,
      "duracao": "string",
      "produtos": [
        {
          "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          "img": "string",
          "nome": "string",
          "preco": "string",
          "subCategoriaProduto": {
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "nome": "string",
            "categoriaProduto": {
              "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
              "nome": "string"
            }
          },
          "marcaProduto": {
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "nome": "string"
          },
          "qtdEstoque": 0,
          "marcasVeiculos": [
            {
              "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
              "nome": "string"
            }
          ],
          "modelosVeiculos": [
            {
              "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
              "nome": "string",
              "marcaVeiculo": {
                "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                "nome": "string"
              },
              "categoriaVeiculo": 0
            }
          ]
        }
      ]
    }
  ],
  "cliente": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "nome": "string",
    "cpf": "string",
    "endereco": [
      {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "cep": "string",
        "estado": "string",
        "cidade": "string",
        "bairro": "string",
        "rua": "string",
        "numero": "string"
      }
    ]
  },
  "veiculo": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "placa": "string",
    "modelo": {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "nome": "string",
      "marcaVeiculo": {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "nome": "string"
      },
      "categoriaVeiculo": 0
    },
    "ano": 0
  }
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 POST `/api/Agendar`

Descrição:Adiciona um Agendamento

- **Parametro (request):** Sem parametro
- **Ex de rota:** <https://localhost:7190/api/Agendar>

- **Entrada (request):**

<!-- markdownlint-disable MD033 -->
 <details>
 <summary>Visualizar Entrada</summary>

```json
{
  "data": "2025-07-29",
  "hora": "string",
  "queixa": "string",
  "servicosId": [
    "3fa85f64-5717-4562-b3fc-2c963f66afa6"
  ],
  "clienteId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "veiculoId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
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
  "data": "2025-07-29",
  "hora": "string",
  "queixa": "string",
  "tempoServiçoTotal": "string",
  "valorTotal": 0,
  "servicos": [
    {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "nome": "string",
      "descricao": "string",
      "valor": 0,
      "duracao": "string",
      "produtos": [
        {
          "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          "img": "string",
          "nome": "string",
          "preco": "string",
          "subCategoriaProduto": {
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "nome": "string",
            "categoriaProduto": {
              "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
              "nome": "string"
            }
          },
          "marcaProduto": {
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "nome": "string"
          },
          "qtdEstoque": 0,
          "marcasVeiculos": [
            {
              "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
              "nome": "string"
            }
          ],
          "modelosVeiculos": [
            {
              "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
              "nome": "string",
              "marcaVeiculo": {
                "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                "nome": "string"
              },
              "categoriaVeiculo": 0
            }
          ]
        }
      ]
    }
  ],
  "cliente": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "nome": "string",
    "cpf": "string",
    "endereco": [
      {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "cep": "string",
        "estado": "string",
        "cidade": "string",
        "bairro": "string",
        "rua": "string",
        "numero": "string"
      }
    ]
  },
  "veiculo": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "placa": "string",
    "modelo": {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "nome": "string",
      "marcaVeiculo": {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "nome": "string"
      },
      "categoriaVeiculo": 0
    },
    "ano": 0
  }
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 PUT `/api/Agendar/{id}`

Descrição: atualiza um Agendamento apartir de um id

**Parametro de rota:** id

- **Ex de rota:** <https://localhost:7190/api/Agendar/3fa85f64-5717-4562-b3fc-2c963f66afa6>

- **Entrada (request):**

<!-- markdownlint-disable MD033 -->
 <details>
 <summary>Visualizar Entrada</summary>

```json
{
  "data": "2025-07-29",
  "hora": "string",
  "queixa": "string",
  "servicosId": [
    "3fa85f64-5717-4562-b3fc-2c963f66afa6"
  ],
  "clienteId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "veiculoId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
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
  "data": "2025-07-29",
  "hora": "string",
  "queixa": "string",
  "tempoServiçoTotal": "string",
  "valorTotal": 0,
  "servicos": [
    {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "nome": "string",
      "descricao": "string",
      "valor": 0,
      "duracao": "string",
      "produtos": [
        {
          "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          "img": "string",
          "nome": "string",
          "preco": "string",
          "subCategoriaProduto": {
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "nome": "string",
            "categoriaProduto": {
              "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
              "nome": "string"
            }
          },
          "marcaProduto": {
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "nome": "string"
          },
          "qtdEstoque": 0,
          "marcasVeiculos": [
            {
              "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
              "nome": "string"
            }
          ],
          "modelosVeiculos": [
            {
              "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
              "nome": "string",
              "marcaVeiculo": {
                "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                "nome": "string"
              },
              "categoriaVeiculo": 0
            }
          ]
        }
      ]
    }
  ],
  "cliente": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "nome": "string",
    "cpf": "string",
    "endereco": [
      {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "cep": "string",
        "estado": "string",
        "cidade": "string",
        "bairro": "string",
        "rua": "string",
        "numero": "string"
      }
    ]
  },
  "veiculo": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "placa": "string",
    "modelo": {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "nome": "string",
      "marcaVeiculo": {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "nome": "string"
      },
      "categoriaVeiculo": 0
    },
    "ano": 0
  }
}
```

</details> <!-- markdownlint-enable MD033 --> ``

#### 🔹 DELETE `/api/Agendar/{id}`

Descrição: Deleta uma Agendamento apartir de um id

**Parametro de rota:** id

- **Ex de rota:** <https://localhost:7190/api/Agendar/3fa85f64-5717-4562-b3fc-2c963f66afa6>
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
