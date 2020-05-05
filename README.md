# Introduction 
TODO: Give a short introduction of your project. Let this section explain the objectives or the motivation behind this project. 

# Getting Started
TODO: Guide users through getting your code up and running on their own system. In this section you can talk about:
1.	Installation process
2.	Software dependencies
3.	Latest releases
4.	API references

# Build and Test
TODO: Describe and show how to build your code and run the tests. 

# Contribute
TODO: Explain how other users and developers can contribute to make your code better. 

If you want to learn more about creating good readme files then refer the following [guidelines](https://www.visualstudio.com/en-us/docs/git/create-a-readme). You can also seek inspiration from the below readme files:
- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)
- [Chakra Core](https://github.com/Microsoft/ChakraCore)


# Realizar a publição da API e Banco de dados no docker


``` bash
# Baixar a imagem do postgres
docker pull postgres

# Criando uma network para execução dos containers
docker network create --driver bridge postgres-network

#Criando um container para executar uma instância do PosgreSQL
docker run --network=postgres-network --name server-postgres  -p 5432:5432 -v postgres-data:/var/lib/postgresql/data -e POSTGRES_PASSWORD=bullapp@2020 -d postgres
```

## Em que:
* O atributo **name** especifica o nome do container a ser gerado (**server-postgres**);
* Para o atributo **network** foi definido o valor da rede criada na seção anterior (**postgres-network**);
* No atributo POSTGRES_PASSWORD foi indicada a senha do administrador (para o usuário default **bullapp@2020**);

``` bash
# Gerar uma imagem apartir do DockerFile
docker build -t bullapp:1 .

# verify that the project is OK
dotnet build

# run the project
dotnet run

```