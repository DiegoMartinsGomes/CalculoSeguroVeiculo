# Calculo Seguro Veiculo

	1. Ambiente de Execução
		1.1. Ambiente de Execução Desejável
• Visual Studio 2017. Framework 4.7. IIS 7.5 ou maior. • Oracle Database 11g. Caso não tenha o Oracle baixe a versão Oracle Database Express Edition (XE) Release 11.2.0.2.0 (11gR2) no link: https://www.oracle.com/database/technologies/xe-prior-releases.html

	2. Questões Práticas
		2.1. Descrição do Exame
Você irá construir um serviço que registre o Cálculo de Seguro de Veículos. Deve ser calculado como mostrado abaixo:

Variáveis do Cálculo: Valor do Veículo, Taxa de Risco, Prêmio de Risco, Prêmio Puro, Prêmio Comercial.

Cálculo: Variável Estática 1: MARGEM_SEGURANÇA = 3% Variável Estática 2: LUCRO = 5%

Taxa de Risco = (Valor do Veículo * 5) /(2 x Valor do Veículo) Prêmio de Risco = Taxa de Risco* Valor do Veículo Prêmio Puro = Prêmio de Risco * (1 + MARGEM_SEGURANÇA) Prêmio Comercial = LUCRO * Prêmio Puro

Exemplo: Valor do Veículo = R$ 10.000,00 Taxa de Risco = 50.000/(2 x 10.000) = 2,5 % Prêmio de Risco = 2,5% x 10.000 = R$ 250,00 Prêmio Puro = 250 x (1 + 0,03) = R$ 257,50 Prêmio Comercial = 5% x 257,50= R$ 270,37

Valor do Seguro é R$ 270,37 Obs: Este cálculo é hipotético e didático.

Seu serviço deve:

		• Calcular o Valor do Seguro de Veículos. 
		• Gravar os dados de um Seguro em banco de dados Oracle (Ou equivalente). Um seguro possui um Veículo {Valor do Veículo, Marca/Modelo Veiculo} e um Segurado {Nome, CPF, idade}. 
		• Pesquisar os dados de um Seguro. 
		• Desejável: Gerar um relatório com as médias aritmética dos Seguros. A saída desse relatório deve ser em JSON.

Requisitos não-funcionais:

		• Uso de tecnologia .NET | MVC | Web API. 
		• Organização do domínio com uso de arquitetura limpa (Clean Architecture). 
		• Testes de unidade automatizado do cálculo do seguro. 
		• Desejável: Dados do Segurado vem de um serviço REST. (Você pode criar um mock com o JSON Server para simular).

Recursos de apoio

		• Clean Architecture em .NET - https://github.com/ivanpaulovich/clean-architecture-manga

	2.2. Critérios de avaliação
		• Código Limpo. 
		• Automação de testes de unidade. 
		• Clean Architecture.

	2.3. Entregáveis
		• Código Fonte em repositório Git (GitHub ou qualquer outro que possa compartilhar o projeto.)
		
		
• Durante o desenvolvimento do projeto foi identificado problemas de compatibilidade entre pacotes Oracle.EntityFrameworkCore e Microsoft.EntityFrameworkCore.Relational, que ocasionou a não utilização do banco de dados Oracle, para poder minimizar o problema o projeto foi desenvolvido utilizando o banco de dados SQL Server. 		
		
#	***Melhorias Feitas Após a Entrega***
	Após a entrega foram desenvolvidas algumas melhorias tais como?
		• Incorporação de Unit Of Work;
		• Isolamento da Injecão de Dependência;
		• Objeto padrão para respostas da API;
		• Organização dos projetos em pastas na solution.
		• Atualização do pacote Oracle.EntityFrameworkCore, foi liberado uma nova versão no dia 08/09/2020 que solucionou o problema mensionado à cima.
		
	Essa melhorias podem ser vizualizadas na branch develop.		
		
