using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Mecanica_Automotiva.Exception
{
    // IExceptionFilter interface interna que aplica essa classe filtro toda vez que captura uma exception
    public class HttpExceptionFilter : IExceptionFilter 
    {
        //captura as mensagens das exception pra poder mostrar no front
        public void OnException(ExceptionContext context)
        {
            //parametro recebe a exception chamada context 
            // if context.exception acessa a excessao que veio no context
            //is notfound verfica se e do tipo notfoundexception com valor notfoundex(valor do notfound)
            if (context.Exception is NotFoundException NotFoundEx)
            {
                // context.Result define o que vai ser retornado
                //new NotFoundObjectResult - produz uma resposta do tipo http notfound 
                //(new { message = NotFoundEx.Message }) cria a mensagem do http usando a mensagem que vem do notfound ex
                context.Result = new NotFoundObjectResult(new { message = NotFoundEx.Message });
                    context.ExceptionHandled = true; //indica que a exception foi tratada (da um save na saida pra envio)

            }
        }
    }
}
