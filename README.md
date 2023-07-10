# Fiap Tech Challenge - Sistema de Totem
Esta API em .NET Core fornece funcionalidades para um sistema de lanchonete utilizando um totem. 
O sistema permite a realiza��o de pedidos de alimentos e bebidas e o gerenciamento dos produtos dispon�veis.

## Configura��o e Uso

1. Certifique-se de ter o Docker instalado em sua m�quina. Caso contr�rio, fa�a o download e instale a vers�o mais recente do Docker no site oficial.

2. Clone este reposit�rio para o seu ambiente local.

3. Navegue at� o diret�rio raiz do projeto.

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

## Observa�oes

Essa api n�o tem implementacao de sistema de pagamento.
Foi utilizado apenas um fake Service retornando true, sempre que tiver um novo pedido.

