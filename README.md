# ProjetoWeb: API de Carrinho
Projeto desenvolvido para a disciplina de Projetos Web da Uniftec. Período letivo 2/2026

## Objetivo
Desenvolver uma API para a exibição de um carrinho, contendo os pedidos dos usuários, implementando as definições REST, permitindo ser integrada com outras aplicações

## Desenvolvimento
API construída em C# com o framework .NET Core

### Entidades
- Pedido
  
| Cmpo  | Tipo | Descrição |
| ------------- | ------------- | ------------- |
| Id | Guid | Id do pedido |
| UsuarioId  | Guid  | Id do usuário que fez o pedido  |
| ProdutosModel  | Lista de produtos  | Lista de produtos contidos dentro do pedido. Apenas uma abstração dos produtos, com informações essênciais  |
| DataPedido  | DateTime  | Data em que o pedido foi atualizado pela última vez  |
| StatusPedido  | int  | Indica o status do pedido: Pendente pagamento (0), Concluído (1) e Cancelado (-1) |
| TextoStatusPedido  | string  | Descreve o status do pedido do campo "StatusPedido" |
| ValorTotal | decimal  | Calcula o valor total do pedido com seus itens |
| CEPEnderecoEntrega | string  | Descreve o CEP em que o pedido será entregue |
| NumeroEnderecoEntrega | string  | Descreve o número do endereço em que o pedido será entregue |

- Produto (Abstração)
  
| Cmpo  | Tipo | Descrição |
| ------------- | ------------- | ------------- |
| Id  | Guid  | Id do produto  |
| PedidoId | Guid | Id do pedido em que ele pertence |
| ProdutoId | Guid | Id do produto na tabela de produtos (consulta microsserviço) |
| Quantidade | int | Quantidade escolhida para o produto |
| Preco | decimal | Valor do produto unitário (consulta em microsserviço) |
| Disponivel | bool | Indica se o produto está disponível para compra ou não |

- Carrinho

| UsuarioId  | Guid  | Id do usuário atrelado aos pedidos  |
| PedidosModel  | Lista pedidos  | Lista contendo todos os pedidos do usuários  |
| ValorTotalCarrinho  | decimal  | Valor total do carrinho, somando todos os pedidos do usuário  |

- AtualizacaoPedido (entidade para atualizarmos algumas informações de um pedido através do carrinho)

| PedidoId  | Guid  | Id do pedido que será atualizado  |
| StatusPedido  | int  | Novo status do pedido que será atualizado  |
| CEPEnderecoEntrega | string  | Descreve o novo CEP do endereço de entrega do pedido que será atualizado |
| NumeroEnderecoEntrega | string  | Descreve o novo número do endereço de entrega do pedido que será atualizado |

### Endpoints

### Banco de dados
- PostgreSQL
- Scripts de criação de tabelas necessárias:
