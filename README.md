# ValoReal.Comuns

**ValoReal.Comuns** é uma API desenvolvida para fornecer endpoints comuns que serão consumidos por outras duas APIs principais. Seu objetivo é centralizar funcionalidades compartilhadas, promovendo consistência, manutenção centralizada e melhor governança de código.

## 🏗️ Arquitetura

Este projeto segue os princípios da **Clean Architecture**, separando responsabilidades de forma clara entre as camadas:

- **API (Apresentação)** — Interface pública da aplicação.
- **Application (Casos de Uso)** — Regras de negócio e orquestração de serviços.
- **Domain (Domínio)** — Entidades e contratos de domínio.
- **Infrastructure (Infraestrutura)** — Implementações de repositórios e integrações.

Além disso, utiliza o **Repository Pattern**, permitindo um acesso a dados desacoplado e testável.

## 💻 Tecnologias Utilizadas

- **.NET 8** — Framework principal de desenvolvimento da API.
- **MySQL** — Banco de dados relacional para persistência de dados.
- **Serilog** — Logging estruturado para rastreabilidade e monitoramento.
- **Scalar.NET** — Geração de documentação da API.

## 📂 Estrutura do Projeto

```plaintext
ValoReal.Comuns/
│
├── ValoReal.Comuns.API/            # Camada de Apresentação
│
├── ValoReal.Comuns.Application/    # Casos de uso, DTOs, interfaces de serviços
│
├── ValoReal.Comuns.Domain/         # Entidades e interfaces de domínio
│
├── ValoReal.Comuns.Infrastructure/ # Acesso ao banco de dados, implementações de repositórios
│
└── ValoReal.Comuns.Tests/          # Testes unitários e de integração
```
---

## 🔗 Documentação da API

A documentação da API está disponível via **Scalar.NET**, permitindo que desenvolvedores explorem os endpoints e compreendam os contratos da API de forma clara e interativa.

---

## 🔒 Segurança

O projeto segue boas práticas de segurança, alinhadas às recomendações da Microsoft e do OWASP. A autenticação e a autorização podem ser integradas de acordo com as necessidades das APIs consumidoras.

---

## 🚀 Como Executar

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/seu-usuario/ValoReal.Comuns.git
   
2. **Configure o MySQL:**
   Crie o banco de dados e configure a string de conexão no arquivo appsettings.json.

3. **Rode a aplicação:**
   ```bash
   cd ValoReal.Comuns.API
   dotnet run

4. **Acesse a documentação da API (Scalar.NET):**
   Por padrão, a documentação estará disponível em:
   http://localhost:{porta}/scalar

## 🔧 Configuração de Logs
A configuração do Serilog está definida no arquivo appsettings.json. É possível customizar a saída de logs para o console, arquivos ou outros destinos (como Elasticsearch ou Seq) de acordo com a necessidade.

## 📌 Contribuição
Contribuições são bem-vindas! Sinta-se à vontade para abrir uma issue ou enviar um pull request para propor melhorias, correções ou novos recursos.

## 📜 Licença
Este projeto é licenciado sob a MIT License.
