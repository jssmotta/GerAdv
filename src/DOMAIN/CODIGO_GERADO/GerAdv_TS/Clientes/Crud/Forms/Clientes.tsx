// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IClientes } from '@/app/GerAdv_TS/Clientes/Interfaces/interface.Clientes';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/CrudFormsMobile.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import RegimeTributacaoComboBox from '@/app/GerAdv_TS/RegimeTributacao/ComboBox/RegimeTributacao';
import EnquadramentoEmpresaComboBox from '@/app/GerAdv_TS/EnquadramentoEmpresa/ComboBox/EnquadramentoEmpresa';
import { RegimeTributacaoApi } from '@/app/GerAdv_TS/RegimeTributacao/Apis/ApiRegimeTributacao';
import { EnquadramentoEmpresaApi } from '@/app/GerAdv_TS/EnquadramentoEmpresa/Apis/ApiEnquadramentoEmpresa';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
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
  const isMobile = useIsMobile();
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
    // Importante: prevenir comportamento padrão e propagação
    e.preventDefault();
    if (e.stopPropagation) e.stopPropagation();
    
    // Evitar múltiplos envios
    if (!isSubmitting) {
      setIsSubmitting(true);
      
      // Chamar onSubmit com o evento
      try {
        onSubmit(e);
      } catch (error) {
        console.error("Erro ao submeter formulário de Clientes:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  // Handler para submissão direta via ButtonsCrud
  const handleDirectSave = () => {
    if (!isSubmitting) {
      setIsSubmitting(true);
      
      try {
        // Criar um evento sintético básico para manter compatibilidade
        const syntheticEvent = {
          preventDefault: () => { },
          target: document.getElementById(`ClientesForm-${clientesData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar Clientes diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-Clientes' : 'form-container form-container-Clientes'}>
       
            <form className='formInputCadInc' id={`ClientesForm-${clientesData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={clientesData} isSubmitting={isSubmitting} onClose={onClose} formId={`ClientesForm-${clientesData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="Nome"
            className="inputIncNome"
            name="nome"
            value={clientesData.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
          />

<InputInput
type="text"
id="empresa"
label="Empresa"
className="inputIncNome"
name="empresa"
value={clientesData.empresa}
onChange={onChange}               
/>

<InputInput
type="text"
id="icone"
label="Icone"
className="inputIncNome"
name="icone"
value={clientesData.icone}
onChange={onChange}               
/>

<InputInput
type="text"
id="nomemae"
label="NomeMae"
className="inputIncNome"
name="nomemae"
value={clientesData.nomemae}
onChange={onChange}               
/>

<InputInput
type="text"
id="rgdataexp"
label="RGDataExp"
className="inputIncNome"
name="rgdataexp"
value={clientesData.rgdataexp}
onChange={onChange}               
/>

<InputCheckbox label="Inativo" name="inativo" checked={clientesData.inativo} onChange={onChange} />
        
<InputInput
type="text"
id="quemindicou"
label="QuemIndicou"
className="inputIncNome"
name="quemindicou"
value={clientesData.quemindicou}
onChange={onChange}               
/>

<InputCheckbox label="SendEMail" name="sendemail" checked={clientesData.sendemail} onChange={onChange} />
        
<InputInput
type="text"
id="adv"
label="Adv"
className="inputIncNome"
name="adv"
value={clientesData.adv}
onChange={onChange}               
/>

<InputInput
type="text"
id="idrep"
label="IDRep"
className="inputIncNome"
name="idrep"
value={clientesData.idrep}
onChange={onChange}               
/>

</div><div className="grid-container"><InputCheckbox label="Juridica" name="juridica" checked={clientesData.juridica} onChange={onChange} />
        
<InputInput
type="text"
id="nomefantasia"
label="NomeFantasia"
className="inputIncNome"
name="nomefantasia"
value={clientesData.nomefantasia}
onChange={onChange}               
/>

<InputInput
type="text"
id="class"
label="Class"
className="inputIncNome"
name="class"
value={clientesData.class}
onChange={onChange}               
/>

<InputCheckbox label="Tipo" name="tipo" checked={clientesData.tipo} onChange={onChange} />
        
<InputInput
type="text"
id="dtnasc"
label="DtNasc"
className="inputIncNome"
name="dtnasc"
value={clientesData.dtnasc}
onChange={onChange}               
/>

<InputInput
type="text"
id="inscest"
label="InscEst"
className="inputIncNome"
name="inscest"
value={clientesData.inscest}
onChange={onChange}               
/>

<InputInput
type="text"
id="qualificacao"
label="Qualificacao"
className="inputIncNome"
name="qualificacao"
value={clientesData.qualificacao}
onChange={onChange}               
/>

<InputCheckbox label="Sexo" name="sexo" checked={clientesData.sexo} onChange={onChange} />
        
<InputInput
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

<InputInput
type="text"
id="rg"
label="RG"
className="inputIncNome"
name="rg"
value={clientesData.rg}
onChange={onChange}               
/>

<InputCheckbox label="TipoCaptacao" name="tipocaptacao" checked={clientesData.tipocaptacao} onChange={onChange} />
        
<InputInput
type="text"
id="observacao"
label="Observacao"
className="inputIncNome"
name="observacao"
value={clientesData.observacao}
onChange={onChange}               
/>

<InputInput
type="text"
id="endereco"
label="Endereco"
className="inputIncNome"
name="endereco"
value={clientesData.endereco}
onChange={onChange}               
/>

<InputInput
type="text"
id="bairro"
label="Bairro"
className="inputIncNome"
name="bairro"
value={clientesData.bairro}
onChange={onChange}               
/>

<InputInput
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

<InputInput
type="text"
id="fax"
label="Fax"
className="inputIncNome"
name="fax"
value={clientesData.fax}
onChange={onChange}               
/>

<InputInput
type="text"
id="fone"
label="Fone"
className="inputIncNome"
name="fone"
value={clientesData.fone}
onChange={onChange}               
/>

</div><div className="grid-container">        
<InputInput
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={clientesData.data}
onChange={onChange}               
/>

<InputInput
type="text"
id="homepage"
label="HomePage"
className="inputIncNome"
name="homepage"
value={clientesData.homepage}
onChange={onChange}               
/>

<InputInput
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={clientesData.email}
onChange={onChange}               
/>

<InputCheckbox label="Obito" name="obito" checked={clientesData.obito} onChange={onChange} />
        
<InputInput
type="text"
id="nomepai"
label="NomePai"
className="inputIncNome"
name="nomepai"
value={clientesData.nomepai}
onChange={onChange}               
/>

<InputInput
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

<InputCheckbox label="ReportECBOnly" name="reportecbonly" checked={clientesData.reportecbonly} onChange={onChange} />
<InputCheckbox label="ProBono" name="probono" checked={clientesData.probono} onChange={onChange} />
</div><div className="grid-container">        
<InputInput
type="text"
id="cnh"
label="CNH"
className="inputIncNome"
name="cnh"
value={clientesData.cnh}
onChange={onChange}               
/>

<InputInput
type="text"
id="pessoacontato"
label="PessoaContato"
className="inputIncNome"
name="pessoacontato"
value={clientesData.pessoacontato}
onChange={onChange}               
/>

<InputCheckbox label="Ani" name="ani" checked={clientesData.ani} onChange={onChange} />

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 