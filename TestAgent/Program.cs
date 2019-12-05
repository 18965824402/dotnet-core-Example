using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NewLife.Agent;

namespace TestAgent
{
    //https://www.cnblogs.com/yilezhu/p/10380887.html
    public class Program
    {
        protected static string[] _args;
        public static void Main(string[] args)
        {
            _args = args;
            TestAgentServices.ServiceMain();

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseUrls("http://*:8008")
                .UseStartup<Startup>();

        public class TestAgentServices : AgentServiceBase<TestAgentServices>
        {
            #region ����

            /// <summary>��ʾ��</summary>
            public override string DisplayName => "Agent���Է���2";

            /// <summary>����</summary>
            public override string Description => "Agent���Է����������Ϣ��2";
            #endregion

            #region ���캯��
            /// <summary>ʵ����һ���������</summary>
            public TestAgentServices()
            {
                // һ���ڹ��캯������ָ��������
                ServiceName = "TestAgent2";
            }
            #endregion

            #region ִ������
            protected override void StartWork(string reason)
            {

                CreateWebHostBuilder(_args).Build().Run();
                WriteLog("��ǰʱ��{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                base.StartWork(reason);
            }
            #endregion
        }
    }
}
