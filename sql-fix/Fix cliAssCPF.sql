alter table PreClientes ADD cliAssCPF2[nvarchar](11) NULL;
update PreClientes Set cliAssCPF=cliAssCPF2;
alter table PreClientes drop column cliAssCPF;
alter table PreClientes ADD cliAssCPF[nvarchar](11) NULL;
update PreClientes Set cliAssCPF=cliAssCPF2;
alter table PreClientes drop column cliAssCPF2;