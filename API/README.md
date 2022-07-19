## Possiveis erros no build da imagem:

<br/>

* Erro ao gerar a imagem da API

  ``` teste

  C:\Program Files\dotnet\sdk\3.1.302\NuGet.targets(128,5): error : Unable to load the service index for source https://api.nuget.org/v3/index.json. [C:\src\Template.Web\Template.Web.csproj]
  C:\Program Files\dotnet\sdk\3.1.302\NuGet.targets(128,5): error :   No such host is known. [C:\src\Template.Web\Template.Web.csproj]
  The command 'cmd /S /C dotnet restore "Template.Web/Template.Web.csproj"' returned a non-zero code: 1

  ```
    O contêiner não tem conectividade com a Internet, portanto, não pode derrubar os pacotes. Podemos ver isso claramente construindo este arquivo docker muito simples

    ## Solução

    O servidor DNS está errado no contêiner. Para corrigir, codifique o DNS no Docker, ou seja, coloque este JSON

    ``` json

    { "dns" : [ "10.1.2.3" , "8.8.8.8" ] }

    ```
      * sudo touch /etc/docker/daemon.json
      * sudo vim /etc/docker/daemon.json

    ## Referências

  * https://stackoverflow.com/questions/61889848/how-to-add-a-daemon-json-file-in-docker-ubuntu



<br/>

# Realizar a publição da API:


* Rodar o comando abaixo para subir a API e banco de dados juntos:


  ``` bash 
  docker-compose up -d
  ```
