# Controle de Fluxo de Caixa

## Como Utilizar a aplicação

- Toda a aplicação está em container. Para realizar a instalação da aplicação use [Docker](https://www.docker.com/) e digite dentro da pasta raiz do projeto onde está o arquivo **docker-compose.yml** o seguinte comando:

  > docker compose up

- A aplicação terá a interface do swagger, onde você pode mandar as requisições de operações. Acessível na url: http://localhost/swagger
- Para os relatorios você pode acessar pelo grafana e montar um dashboard utilizando a metrica **transacoes_totais** na url: localhost:3000
- Um endpoint de historico das transações também está disponivel no swagger, além de um consolidado do saldo final

## Tecnologias envolvidas

- .NET 7
- SQL Server
- Prometheus
- Grafana

## Considerações

Abaixo algumas considerações sobre a aplicação e cenário:

- A aplicação foi implementada utilizando os conceitos de Clean Arquitecture e CQRS, onde a principal preocupação foi começar simples mas deixar a aplicação preparada para evoluir e crescer.
- Em um primeiro momento essa aplicação rodando em ambiente **on-premise**. Porém com alguns ajustes na camada de infra é possível se tornar um cloud-based system.
- Eu presumi que a aplicação estaria dentro de ecossistema já consolidado, por isso não implementei autenticação diretamente, mas tanto a implementação de uma autenticação e autorização nela própria ou usando algum servidor de identidade, como o [KeyCloak](https://www.keycloak.org/) seria possível sem mudar a estrutura.
- Dependendo do cenario onde essa aplicação rode, pode ser necessário trazer mais resiliência. Eu faria isso introduzindo mensageria e deixando assincrono o processamento das transações.
- A aplicação está toda em container. O que já facilitaria caso fosse necessário escalar verticalmente e horizontalmente. Para realizar essa tarefa um caminho seria utilizar o kubernets para orquestrar e gerenciar os containers, além de um application load balancer e talvez implementar bases de dados para leitura e gravação. Como já utilizamos CQRS a aplicação está preparada para crescer para esse cenário.
- Um ponto de já melhoria, seria pós entender um pouco melhor a necessidade do négocio já configurar o Grafana com os boards direto por arquivos para já deixar preparado no warm-up da aplicação. Um outro ponto importante de eu estar usando o prometheus e grafana é para implementar observabilidade e monitoramento da aplicação, o que nessa versão do código ainda não está configurado.
- A aplicação possui testes unitários mas precisa aumentar o coverage.

## Desenho Big Picture

![BigPicture](./docs/imgs/big-picture.png)
