"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IClientes } from '../../Interfaces/interface.Clientes';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import RegimeTributacaoComboBox from '@/app/GerAdv_TS/RegimeTributacao/ComboBox/RegimeTributacao';
import EnquadramentoEmpresaComboBox from '@/app/GerAdv_TS/EnquadramentoEmpresa/ComboBox/EnquadramentoEmpresa';
import { RegimeTributacaoApi } from '@/app/GerAdv_TS/RegimeTributacao/Apis/ApiRegimeTributacao';
import { EnquadramentoEmpresaApi } from '@/app/GerAdv_TS/EnquadramentoEmpresa/Apis/ApiEnquadramentoEmpresa';
import InputCnpj from '@/app/components/Inputs/InputCnpj'
import InputCpf from '@/app/components/Inputs/InputCpf'
import InputCep from '@/app/components/Inputs/InputCep'

interface ClientesFormProps {
    clientesData: IClientes;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ClientesForm: React.FC<ClientesFormProps> = ({
    clientesData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeRegimeTributacao, setNomeRegimeTributacao] = useState('');
            const regimetributacaoApi = new RegimeTributacaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeEnquadramentoEmpresa, setNomeEnquadramentoEmpresa] = useState('');
            const enquadramentoempresaApi = new EnquadramentoEmpresaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("regimetributacao") > 0) {
  regimetributacaoApi
    .getById(getParamFromUrl("regimetributacao"))
    .then((response) => {
      setNomeRegimeTributacao(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (clientesData.id === 0) {
    clientesData.regimetributacao = getParamFromUrl("regimetributacao");
  }
}
 
if (getParamFromUrl("enquadramentoempresa") > 0) {
  enquadramentoempresaApi
    .getById(getParamFromUrl("enquadramentoempresa"))
    .then((response) => {
      setNomeEnquadramentoEmpresa(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (clientesData.id === 0) {
    clientesData.enquadramentoempresa = getParamFromUrl("enquadramentoempresa");
  }
}
 const addValorRegimeTributacao = (e: any) => {
                        if (e?.id>0)
                        clientesData.regimetributacao = e.id;
                      };
 const addValorEnquadramentoEmpresa = (e: any) => {
                        if (e?.id>0)
                        clientesData.enquadramentoempresa = e.id;
                      };

  const onConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    if (!isSubmitting) {
      setIsSubmitting(true);
      onSubmit(e);
    }
   };

  return (
  <>
  {nomeRegimeTributacao && (<h2>{nomeRegimeTributacao}</h2>)}
{nomeEnquadramentoEmpresa && (<h2>{nomeEnquadramentoEmpresa}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

    <Input
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={clientesData.nome}
            onChange={onChange}
            required
          />

<Input
type="text"
id="empresa"
label="Empresa"
className="inputIncNome"
name="empresa"
value={clientesData.empresa}
onChange={onChange}               
/>

<Input
type="text"
id="icone"
label="Icone"
className="inputIncNome"
name="icone"
value={clientesData.icone}
onChange={onChange}               
/>

<Input
type="text"
id="nomemae"
label="NomeMae"
className="inputIncNome"
name="nomemae"
value={clientesData.nomemae}
onChange={onChange}               
/>

<Input
type="text"
id="rgdataexp"
label="RGDataExp"
className="inputIncNome"
name="rgdataexp"
value={clientesData.rgdataexp}
onChange={onChange}               
/>

<Checkbox label="Inativo" name="inativo" checked={clientesData.inativo} onChange={onChange} />
        
<Input
type="text"
id="quemindicou"
label="QuemIndicou"
className="inputIncNome"
name="quemindicou"
value={clientesData.quemindicou}
onChange={onChange}               
/>

<Checkbox label="SendEMail" name="sendemail" checked={clientesData.sendemail} onChange={onChange} />
        
<Input
type="text"
id="adv"
label="Adv"
className="inputIncNome"
name="adv"
value={clientesData.adv}
onChange={onChange}               
/>

<Input
type="text"
id="idrep"
label="IDRep"
className="inputIncNome"
name="idrep"
value={clientesData.idrep}
onChange={onChange}               
/>

</div><div className="grid-container"><Checkbox label="Juridica" name="juridica" checked={clientesData.juridica} onChange={onChange} />
        
<Input
type="text"
id="nomefantasia"
label="NomeFantasia"
className="inputIncNome"
name="nomefantasia"
value={clientesData.nomefantasia}
onChange={onChange}               
/>

<Input
type="text"
id="class"
label="Class"
className="inputIncNome"
name="class"
value={clientesData.class}
onChange={onChange}               
/>

<Checkbox label="Tipo" name="tipo" checked={clientesData.tipo} onChange={onChange} />
        
<Input
type="text"
id="dtnasc"
label="DtNasc"
className="inputIncNome"
name="dtnasc"
value={clientesData.dtnasc}
onChange={onChange}               
/>

<Input
type="text"
id="inscest"
label="InscEst"
className="inputIncNome"
name="inscest"
value={clientesData.inscest}
onChange={onChange}               
/>

<Input
type="text"
id="qualificacao"
label="Qualificacao"
className="inputIncNome"
name="qualificacao"
value={clientesData.qualificacao}
onChange={onChange}               
/>

<Checkbox label="Sexo" name="sexo" checked={clientesData.sexo} onChange={onChange} />
        
<Input
type="text"
id="idade"
label="Idade"
className="inputIncNome"
name="idade"
value={clientesData.idade}
onChange={onChange}               
/>

<InputCnpj
type="text"
id="cnpj"
label="CNPJ"
className="inputIncNome"
name="cnpj"
value={clientesData.cnpj}
onChange={onChange}               
/>

</div><div className="grid-container">        
<InputCpf
type="text"
id="cpf"
label="CPF"
className="inputIncNome"
name="cpf"
value={clientesData.cpf}
onChange={onChange}               
/>

<Input
type="text"
id="rg"
label="RG"
className="inputIncNome"
name="rg"
value={clientesData.rg}
onChange={onChange}               
/>

<Checkbox label="TipoCaptacao" name="tipocaptacao" checked={clientesData.tipocaptacao} onChange={onChange} />
        
<Input
type="text"
id="observacao"
label="Observacao"
className="inputIncNome"
name="observacao"
value={clientesData.observacao}
onChange={onChange}               
/>

<Input
type="text"
id="endereco"
label="Endereco"
className="inputIncNome"
name="endereco"
value={clientesData.endereco}
onChange={onChange}               
/>

<Input
type="text"
id="bairro"
label="Bairro"
className="inputIncNome"
name="bairro"
value={clientesData.bairro}
onChange={onChange}               
/>

<Input
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={clientesData.cidade}
onChange={onChange}               
/>

<InputCep
type="text"
id="cep"
label="CEP"
className="inputIncNome"
name="cep"
value={clientesData.cep}
onChange={onChange}               
/>

<Input
type="text"
id="fax"
label="Fax"
className="inputIncNome"
name="fax"
value={clientesData.fax}
onChange={onChange}               
/>

<Input
type="text"
id="fone"
label="Fone"
className="inputIncNome"
name="fone"
value={clientesData.fone}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={clientesData.data}
onChange={onChange}               
/>

<Input
type="text"
id="homepage"
label="HomePage"
className="inputIncNome"
name="homepage"
value={clientesData.homepage}
onChange={onChange}               
/>

<Input
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={clientesData.email}
onChange={onChange}               
/>

<Checkbox label="Obito" name="obito" checked={clientesData.obito} onChange={onChange} />
        
<Input
type="text"
id="nomepai"
label="NomePai"
className="inputIncNome"
name="nomepai"
value={clientesData.nomepai}
onChange={onChange}               
/>

<Input
type="text"
id="rgoexpeditor"
label="RGOExpeditor"
className="inputIncNome"
name="rgoexpeditor"
value={clientesData.rgoexpeditor}
onChange={onChange}               
/>

            <RegimeTributacaoComboBox
            name={'regimetributacao'}
            value={clientesData.regimetributacao}
            setValue={addValorRegimeTributacao}
            label={'Regime Tributacao'}
            />

            <EnquadramentoEmpresaComboBox
            name={'enquadramentoempresa'}
            value={clientesData.enquadramentoempresa}
            setValue={addValorEnquadramentoEmpresa}
            label={'Enquadramento Empresa'}
            />

<Checkbox label="ReportECBOnly" name="reportecbonly" checked={clientesData.reportecbonly} onChange={onChange} />
<Checkbox label="ProBono" name="probono" checked={clientesData.probono} onChange={onChange} />
</div><div className="grid-container">        
<Input
type="text"
id="cnh"
label="CNH"
className="inputIncNome"
name="cnh"
value={clientesData.cnh}
onChange={onChange}               
/>

<Input
type="text"
id="pessoacontato"
label="PessoaContato"
className="inputIncNome"
name="pessoacontato"
value={clientesData.pessoacontato}
onChange={onChange}               
/>

<Checkbox label="Ani" name="ani" checked={clientesData.ani} onChange={onChange} />
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/agenda${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?clientes=${clientesData.id}`)}>Agenda</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/agendafinanceiro${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?clientes=${clientesData.id}`)}>Agenda Financeiro</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/agendarepetir${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?clientes=${clientesData.id}`)}>Agenda Repetir</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/anexamentoregistros${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?clientes=${clientesData.id}`)}>Anexamento Registros</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/clientessocios${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?clientes=${clientesData.id}`)}>Clientes Socios</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/colaboradores${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?clientes=${clientesData.id}`)}>Colaboradores</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/contacorrente${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?clientes=${clientesData.id}`)}>Conta Corrente</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/contatocrm${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?clientes=${clientesData.id}`)}>Contato C R M</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/contratos${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?clientes=${clientesData.id}`)}>Contratos</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/dadosprocuracao${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?clientes=${clientesData.id}`)}>Dados Procuracao</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/diario2${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?clientes=${clientesData.id}`)}>Diario2</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/gruposempresas${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?clientes=${clientesData.id}`)}>Grupos Empresas</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/gruposempresascli${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?clientes=${clientesData.id}`)}>Grupos Empresas Cli</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/honorariosdadoscontrato${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?clientes=${clientesData.id}`)}>Honorarios Dados Contrato</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/horastrab${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?clientes=${clientesData.id}`)}>Horas Trab</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/ligacoes${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?clientes=${clientesData.id}`)}>Ligacoes</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/livrocaixaclientes${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?clientes=${clientesData.id}`)}>Livro Caixa Clientes</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/operadores${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?clientes=${clientesData.id}`)}>Operadores</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/preclientes${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?clientes=${clientesData.id}`)}>Pre Clientes</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/processos${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?clientes=${clientesData.id}`)}>Processos</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/prodespesas${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?clientes=${clientesData.id}`)}>Pro Despesas</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/recados${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?clientes=${clientesData.id}`)}>Recados</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/reuniao${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?clientes=${clientesData.id}`)}>Reuniao</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/agendasemana${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?clientes=${clientesData.id}`)}>Agenda Semana</div>

          </div>
           <div className="buttons-container">
              <br />
              <Button type="button" className="buttonSair" onClick={onClose}>
                Cancelar
              </Button>
              &nbsp;&nbsp;
              <Button type="submit" themeColor="primary" className="buttonOk" disabled={isSubmitting}>
                Salvar
              </Button>
          </div>
        </form>
    </div>
    </>
     );
};
 