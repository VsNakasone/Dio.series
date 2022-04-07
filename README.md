# Dio.series
 Software de cadastro de séries

 Utilizei com base no projeto desenvolvido pelo mentor no bootcamp e acrescentei algumas melhorias.

 Melhorias acrescentadas:
 - Mudaei a nomenclatura do Folder Enum para Enumerator pois o código estava dando conflito com o namespace do "System.Enum".

 - No método listar séries coloquei a condição "if" para indicar uma mensagem quando não houver séries cadastradas ele não poderá listar. Também acrescentei na forma de listar uma indicação boolena para status da série ( indicar se ela foi excluída ou não).

 - No método inserir série coloquei uma condição "if" para que quando digite o Genero abranger somente os generos existentes.

 - No método atualizar séries coloquei a condição "if" para avisar se não houver nenhuma série cadastrada para ser atualizada e também coloquei um condição "do" para que só seja possível atualizar uma série que esteja cadastrada.

 - No método excluir série também coloquei a condição "if" para verificar se existe alguma série cadastrada para ser excluida.

 - No método visualizar série segui com a mesma linha que fiz com o método excluir série 
