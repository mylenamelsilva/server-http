<h1 align="center"> Servidor HTTP </h1>
<p align="center"> Servidor criado com o objetivo de praticar e fixar mais os conceitos sobre HTTP. </p>
<table align="center">
  <tbody>
    <tr>
      <td>C# 11</td>
      <td>.NET 7</td>
    </tr>
  </tbody>
</table>
</br></br></br>

**O servidor tem o objetivo de lidar com requisições feitas pelo [Client HTTP](https://github.com/mylenamelsilva/client-http) para cadastro de produtos via terminal.**
<table >
  <thead>
    <tr>
      <th>Endpoints</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>GET</td>
      <td>POST</td>
      <td>PUT</td>
      <td>DELETE</td>
    </tr>
  </tbody>
</table>

* Todo o desenvolvimento foi feito com auxílio das classes HttpListener e HttpClient para administrar as requisições e as respostas entre client-server.
* O servidor não lida com banco de dados. Toda a inclusão, alteração e exclusão é feita manipulando um `List<>`.

## Como rodar

* `git clone` para fazer uma cópia do repositório (Faça o clone do repositório do client para rodar em conjunto: [Client HTTP](https://github.com/mylenamelsilva/client-http))
* Abra o terminal dentro da pasta da aplicação
* `dotnet run Server` para iniciar o servidor
* **Observação:** Para fazer a alteração e exclusão de um produto, é necessário ter o id, então liste os produtos antes para saber qual id do respectivo produto
