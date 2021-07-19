# TesteLabLuby

Olá boa tarde.

Este é o repositório do meu teste para o LabLuby

A branch master contém 3 diretórios. Um para cada desafio do teste.

## Lógica de Programação

O teste de Lógica de Programação foi escrito numa aplicação Console em C#. Adaptei os testes solicitados para que retornassem na tela a resposta esperada.

A lógica em si está na classe Functions.cs que escolhi transformá-la em uma partial class devido ao tamanho do código. Portanto, a classe Functios está
divida em três cujo os nomes sugerem qual questão está sendo resolvida nela.

## SQL

O teste de SQL está em um arquivo de texto simples. Para seguir um padrão, procurei adaptar sempre para SQLServer.

## Desafio de Orientação a Objetos

A solução que criei é super intuitiva. Se você quiser efetuar uma compra basta seguir as próprias telas da Console. 
Porém reservei duas funcionalidades específicas para um usuário administrador. São elas: a listagem de vendas com valor de faturamento, e
encerramento da aplicação por Environment.Exit.

Para este usuário é necessário informar uma senha que é esta aqui: admSENHA123.

Fiz algumas adaptações no teste proposto para facilitar a utilização de POO. Como por exemplo: inserir outro tipo de produto(Chocolate) para utilizar
uma classe abstrata Produto, e fazer com que as classes Chocolate e Refrigerante herdassem de Produto. Ao criar um List para utilizar como estoque, utilizei
polimorfismo para não precisar especificar o tipo de produto. Também utilizei encapsulamento para proteger o Set de propriedades e o construtor de Produto.

Sei que preciso evoluir mas conheço meu potencial de crescimento. Portanto, peço que independente da aprovação ou não, eu possa ter um feedback de vocês para entender em que pontos preciso melhorar.

Desde já fico grato pela compreensão
