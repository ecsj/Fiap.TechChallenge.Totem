# Fiap Tech Challenge - Sistema de Totem
Esta API em .NET Core fornece funcionalidades para um sistema de lanchonete utilizando um totem. 
O sistema permite a realização de pedidos de alimentos e bebidas e o gerenciamento dos produtos disponíveis.

## Configuração e Uso

1. Certifique-se de ter o Docker instalado em sua máquina. Caso contrário, faça o download e instale a versão mais recente do Docker no site oficial.

2. Clone este repositório para o seu ambiente local.

3. Navegue até o diretório raiz do projeto.

4. No terminal, execute o seguinte comando para construir a imagem Docker da API:

 ```sh
 docker-compose up
 ```

5. No terminal, ou no Docker Desktop verificar qual a Porta do container
Ou executar o comando abaixo:

```sh
docker ps | grep totem-api
```

6. De acordo com a porta do container, abrir no navegador a seguinte url http://localhost:porta/swagger/index.html:

http://localhost:5000/swagger/index.html



## Event Storming

Link do event Storming: 
https://miro.com/app/board/uXjVM4DojyY=/?share_link_id=539839995200

## Observaçoes

Essa api não tem implementacao de sistema de pagamento.
Foi utilizado apenas um fake Service retornando true, sempre que tiver um novo pedido.

