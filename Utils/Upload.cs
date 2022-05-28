using Azure.Storage.Blobs;

using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Net.Http.Headers;

namespace SenaiRH_G1.Utils
{
    public static class Upload
    {
        private const string STRING_DE_CONEXAO = "DefaultEndpointsProtocol=https;AccountName=armazenamentogrupo3;AccountKey=Y4K/lMSydo5BhOrGW1NdiyLYWJdqHsm6ohUG9SWvEGJeZmxWPbmjy6DrGYlJgIqn6ADyIH/gAfaKF1NgTQ391Q==;EndpointSuffix=core.windows.net";
        private const string BLOB_CONTAINER_NAME = "amazenamento-simples-grp1";

        private static BlobContainerClient BlobContainerClient { get; set; }

        static Upload()
        {
            //Permite que manipulemos um container
            BlobContainerClient = new BlobContainerClient(STRING_DE_CONEXAO, BLOB_CONTAINER_NAME);
        }

        /// <summary>
        /// Faz o upload do arquivo para o servidor
        /// </summary>
        /// <param name="arquivo">Arquivo vindo de um formulário</param>
        /// <returns>Nome do arquivo salvo</returns>
        public static string UploadFile(IFormFile arquivo)
        {
            string[] extensoesPermitidas = { "jpg", "png", "jpeg", "pdf", "JPG", "PNG", "JPEG", "PDF" };
            try
            {
                var pasta = Path.Combine("StaticFiles", "Images");
                var caminho = Path.Combine(Directory.GetCurrentDirectory(), pasta);

                if (arquivo.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(arquivo.ContentDisposition).FileName.Trim('"');

                    if (ValidarExtensao(extensoesPermitidas, fileName))
                    {
                        var extensao = RetornarExtensao(fileName);
                        var novoNome = $"{Guid.NewGuid()}.{extensao}";
                        var caminhoCompleto = Path.Combine(caminho, novoNome);

                        BlobClient blobClient = BlobContainerClient.GetBlobClient(novoNome);

                        //Cria um novo block blob (arquivo)
                        blobClient.Upload(arquivo.OpenReadStream());

                        return novoNome;
                    }
                    return "Extensão não permitida";
                }
                return "";
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
        }

        /// <summary>
        /// Valida o uso de enxtensões permitidas apenas
        /// </summary>
        /// <param name="extensoes">Array de extensões permitidas</param>
        /// <param name="nomeDoArquivo">Nome do arquivo</param>
        /// <returns>Verdadeiro/Falso</returns>
        public static bool ValidarExtensao(string[] extensoes, string nomeDoArquivo)
        {

            string[] dados = nomeDoArquivo.Split(".");
            string extensao = dados[dados.Length - 1];

            foreach (var item in extensoes)
            {
                if (extensao == item)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Remove um arquivo do servidor
        /// </summary>
        /// <param name="nomeDoArquivo">Nome do Arquivo</param>
        public static void RemoverArquivo(string nomeDoArquivo)
        {
            BlobClient blobClient = BlobContainerClient.GetBlobClient(nomeDoArquivo);

            blobClient.Delete();
        }

        /// <summary>
        /// Atualiza a foto de perfil
        /// </summary>
        /// <param name="nomeFotoAntiga">Nome da foto antiga</param>
        /// <param name="novaFoto">Arquivo da nova foto</param>
        /// <returns>O nome da nova foto</returns>
        public static string AtualizarFoto(string nomeFotoAntiga, IFormFile novaFoto)
        {

            try
            {
                //Remove a foto antiga
                RemoverArquivo(nomeFotoAntiga);

                //Coloca a nova foto que foi inserida
                string nomeFotoAtualizada = UploadFile(novaFoto);

                // retorna o nome da foto com a guid
                return nomeFotoAtualizada;
            }
            catch (Azure.RequestFailedException azureExecp)
            {
                //Pega o status code da requisição
                string statusCode = azureExecp.Status.ToString();

                if (statusCode == "404")
                {
                    string nomeFotoAtualizada = UploadFile(novaFoto);

                    return nomeFotoAtualizada;
                }

                // Retorna o erro.
                return azureExecp.ToString();
            }
            catch (Exception exp)
            {
                return exp.ToString();
            }
        }

        /// <summary>
        /// Retorna a extensão de um arquivo
        /// </summary>
        /// <param name="nomeDoArquivo">Nome do Arquivo</param>
        /// <returns>Retorna a extensão de um arquivo</returns>
        public static string RetornarExtensao(string nomeDoArquivo)
        {
            string[] dados = nomeDoArquivo.Split('.');
            return dados[dados.Length - 1]; 
        }
    }
}
