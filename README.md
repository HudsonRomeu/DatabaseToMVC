# DatabaseToMVC
Permite a conversão de Tabelas em classes no padrão MVC.


Este projeto habilita ao usuário gerar 3 classes:

  * Persistencia
  * Modelo
  * Controle
  
#PERSISTÊNCIA
A classe persistência é quem faz todo o trabalho para comunicação com o banco de dados. Nela estão contidos os métodos 
necessários para a persistência de dados no banco de dados. 

#MODELO
A classe modelo é a estrutura da entidade. Nela existem as propriedades que correspondem aos campos na tabela selecionada.

#CONTROLE
A classe de controle é responsavel por fazer a comunicação entre o FrontEnd e o BackEnd. Ela é quem realiza todos os 
métodos resposáveis por popular a classe modelo, encapsulando métodos e centralizando a regra de negócio de sua aplicação.


O uso deste padrão MVC e a reusabilidade de código pode ser visualizado neste próprio projeto.
