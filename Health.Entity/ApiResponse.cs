using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health.Entity
{
    public class ApiResponse
    {
        private Boolean success;
        private String message;
        private Object data;
        private int count;

        public ApiResponse(Boolean success, String message)
        {
            this.success = success;
            this.message = message;
        }


        public ApiResponse(Boolean success, String message, Object data)
        {
            this.success = success;
            this.message = message;
            this.data = data;
        }

        public ApiResponse(Boolean success, String message, Object data, int count)
        {
            this.success = success;
            this.message = message;
            this.data = data;
            this.count = count;
        }

    }
}
