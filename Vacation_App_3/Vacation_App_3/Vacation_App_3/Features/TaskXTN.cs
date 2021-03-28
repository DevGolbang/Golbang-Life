using System;
using System.Threading.Tasks;
namespace Vacation_App_3.Features
{
    public static class TaskXTN
    {
        public async static void SafeFireAndForget(this Task task,
            bool returnToCallingContext,
            Action<Exception> onException = null)
        {
            try
            {
                await task.ConfigureAwait(returnToCallingContext);
            }
            catch (Exception e) when (onException != null)
            {
                onException(e);
            }
        }
    }
}
