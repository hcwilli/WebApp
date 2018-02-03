Google
bash
ssh-keygen
cloud compute --project=sanguine-line-170304 firewall-rules create sqlserver --direction=INGRESS --priority=1000 --network=default --action=ALLOW --rules=tcp:1433
ssh <IP>
sudo rpm --import https://packages.microsoft.com/keys/microsoft.asc
sudo sh -c 'echo -e "[packages-microsoft-com-prod]\nname=packages-microsoft-com-prod \nbaseurl=https://packages.microsoft.com/yumrepos/microsoft-rhel7.3-prod\nenabled=1\ngpgcheck=1\ngpgkey=https://packages.microsoft.com/keys/microsoft.asc" > /etc/yum.repos.d/dotnetdev.repo'
sudo yum install libunwind libicu
sudo yum install dotnet-sdk-2.0.3
export PATH=$PATH:$HOME/dotnet
sudo curl -o /etc/yum.repos.d/mssql-server.repo https://packages.microsoft.com/config/rhel/7/mssql-server-2017.repo
sudo yum install -y mssql-server
sudo /opt/mssql/bin/mssql-conf setup
Express
English
systemctl status mssql-server
GitHub
WebApp
MIT
git clone https://github.com/hcwilli/WebApp.git
cd Webapp
dotnet new mvc --auth Individual
git add *
git commit -m "."
git push
set "ConnectionStrings__DefaultConnection=<IP>;Database=WebApp;User Id=sa;Password=<Password>;"
export "ConnectionStrings__DefaultConnection=<IP>;Database=WebApp;User Id=sa;Password=<Password>;"
dotnet ef dbcontext scaffold ConnectionStrings__DefaultConnection Microsoft.EntityFrameworkCore.SqlServer -o Model
sudo dotnet add package Microsoft.VisualStudio.Web.CodeGenerators.Mvc 
for f in Model/*.cs; do \
  model=`basename ${f%%.*}`; \
  if [ "$model" != "WebAppContext" ]; then \
     sudo dotnet aspnet-codegenerator --project . controller --relativeFolderPath Controllers --controllerName ${model}Controller --model ${model} --dataContext ApplicationDbContext --useDefaultLayout --force; \
     # do something \
  fi; \
done 
sudo ASPNETCORE_URLS="http://*:80" dotnet run
http://<IP>