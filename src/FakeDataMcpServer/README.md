# MCP Server de Geração de Dados Fake

Servidor MCP (Model Context Protocol) implementado em C# .NET 10 para gerar dados fictícios (fake data) de forma automatizada. Este servidor é ideal para testes, prototipagem e demonstrações de aplicações que necessitam de dados realistas.

## 📋 Visão Geral

O **FakeDataMcpServer** é um servidor MCP construído como uma aplicação autossuficiente que fornece ferramentas para gerar dados fake em português brasileiro, utilizando a biblioteca [Bogus](https://github.com/bchavez/Bogus).

### Plataformas Suportadas

O servidor é compilado como self-contained para múltiplas plataformas:
* `win-x64` (Windows 64-bit)
* `win-arm64` (Windows ARM64)
* `osx-arm64` (macOS ARM64)
* `linux-x64` (Linux 64-bit)
* `linux-arm64` (Linux ARM64)
* `linux-musl-x64` (Linux musl)

## 🔧 Ferramentas Disponíveis

O servidor implementa as seguintes ferramentas MCP para geração de dados fake:

### 1. **GerarDadosContatosFake** (`ContatosFakeDataTool`)
Gera uma lista com dados fictícios de contatos em português brasileiro.
- **Parâmetro**: `numberOfRecords` (quantidade de registros a gerar)
- **Retorno**: Lista de objetos `Contato` com Nome e Telefone

### 2. **GerarDadosEmpresasFake** (`EmpresasFakeDataTool`)
Gera uma lista com dados fictícios de empresas.
- **Parâmetro**: `numberOfRecords` (quantidade de registros a gerar)
- **Retorno**: Lista de objetos `Empresa`

### 3. **GerarDadosProdutosFake** (`ProdutosFakeDataTool`)
Gera uma lista com dados fictícios de produtos.
- **Parâmetro**: `numberOfRecords` (quantidade de registros a gerar)
- **Retorno**: Lista de objetos `Produto`

### 4. **GerarDadosMensagensFake** (`MensagensFakeDataTool`)
Gera uma lista com dados fictícios de mensagens.
- **Parâmetro**: `numberOfRecords` (quantidade de registros a gerar)
- **Retorno**: Lista de objetos `Mensagem`

## 📁 Estrutura do Projeto

```
FakeDataMcpServer/
├── Program.cs                    # Configuração e inicialização do servidor
├── FakeDataMcpServer.csproj      # Arquivo de projeto .NET
├── README.md                     # Este arquivo
│
├── Models/                       # Modelos de dados
│   ├── Contato.cs               # Modelo de contato
│   ├── Empresa.cs               # Modelo de empresa
│   ├── Produto.cs               # Modelo de produto
│   ├── Mensagem.cs              # Modelo de mensagem
│   └── Result.cs                # Modelo genérico para respostas
│
├── Tools/                        # Implementação das ferramentas MCP
│   ├── ContatosFakeDataTool.cs   # Ferramenta de geração de contatos
│   ├── EmpresasFakeDataTool.cs   # Ferramenta de geração de empresas
│   ├── ProdutosFakeDataTool.cs   # Ferramenta de geração de produtos
│   └── MensagensFakeDataTool.cs  # Ferramenta de geração de mensagens
│
└── Validators/                   # Validadores
    └── NumberOfRecordsValidator.cs  # Validador de quantidade de registros
```

## 🚀 Desenvolvimento Local

Para testar o servidor MCP diretamente a partir do código-fonte, configure sua IDE para executar o projeto utilizando `dotnet run`.

### Configuração para VS Code

Crie um arquivo `.vscode/mcp.json` com a seguinte configuração:

```json
{
  "servers": {
    "FakeDataMcpServer": {
      "type": "stdio",
      "command": "dotnet",
      "args": [
        "run",
        "--project",
        "<CAMINHO_DO_DIRETÓRIO_DO_PROJETO>"
      ]
    }
  }
}
```

### Configuração para Visual Studio

Crie um arquivo `.mcp.json` na raiz da solução com a configuração acima.

## 🧪 Testando o Servidor

Após configurar o servidor em sua IDE, você pode utilizar o Copilot Chat para solicitar a geração de dados fake. Exemplos:

- `Gere 5 contatos fake`
- `Crie 10 produtos fictícios`
- `Gere dados de 20 empresas fake`
- `Crie 15 mensagens fictícias`

O Copilot irá reconhecer as ferramentas disponíveis e executá-las, retornando os dados gerados.

## 📦 Publicação no NuGet.org

### Checklist antes de publicar

- ✅ Testar o servidor MCP localmente
- ✅ Atualizar metadados do pacote no arquivo `.csproj`, especialmente o `<PackageId>`
- ✅ Configurar os inputs do servidor em `.mcp/server.json`
- ✅ Revisar a versão do pacote (`<Version>`)

### Passos para publicar

1. Criar o pacote NuGet:
   ```bash
   dotnet pack -c Release
   ```

2. Publicar no NuGet.org:
   ```bash
   dotnet nuget push bin/Release/*.nupkg --api-key <sua-api-key> --source https://api.nuget.org/v3/index.json
   ```

O arquivo `.nupkg` será gerado no diretório `bin/Release`.

## 🔌 Usando o Servidor a partir do NuGet.org

Uma vez publicado, o servidor pode ser configurado em VS Code ou Visual Studio utilizando o comando `dnx`.

### Configuração em VS Code

```json
{
  "servers": {
    "FakeDataMcpServer": {
      "type": "stdio",
      "command": "dnx",
      "args": [
        "<seu-id-de-pacote>",
        "--version",
        "<versão-do-pacote>",
        "--yes"
      ]
    }
  }
}
```

### Configuração em Visual Studio

Crie um arquivo `.mcp.json` na raiz da solução com a mesma configuração acima.

## 📚 Referências

- [Documentação Oficial MCP](https://modelcontextprotocol.io/)
- [Especificação do Protocolo MCP](https://spec.modelcontextprotocol.io/)
- [GitHub - Model Context Protocol](https://github.com/modelcontextprotocol)
- [SDK C# para MCP](https://modelcontextprotocol.github.io/csharp-sdk)
- [Biblioteca Bogus - Geração de Dados Fake](https://github.com/bchavez/Bogus)

## 📋 Dependências Principais

- **.NET 10**: Runtime e framework
- **ModelContextProtocol**: SDK C# para implementação do protocolo MCP
- **Bogus**: Biblioteca para geração de dados fictícios realistas

## 🤝 Contribuições

Sugestões de melhorias, novas ferramentas de geração de dados ou correções são bem-vindas!
