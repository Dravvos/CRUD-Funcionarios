create database AulaDB
go
use AulaDB

Create table Funcionarios( 
	func_id int primary key, 
	func_nome varchar(max), 
	func_tipo char(1), 
	func_ativo bit)