// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IPreClientes } from '@/app/GerAdv_TS/PreClientes/Interfaces/interface.PreClientes';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import InputName from '@/app/components/Inputs/InputName';
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
import InputCnpj from '@/app/components/Inputs/InputCnpj'
import InputCpf from '@/app/components/Inputs/InputCpf'
import InputCep from '@/app/components/Inputs/InputCep'

interface PreClientesFormProps {
    preclientesData: IPreClientes;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const PreClientesForm: React.FC<PreClientesFormProps> = ({
    preclientesData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeClientes, setNomeClientes] = useState('');
            const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("clientes") > 0) {
  clientesApi
    .getById(getParamFromUrl("clientes"))
    .then((response) => {
      setNomeClientes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (preclientesData.id === 0) {
    preclientesData.idrep = getParamFromUrl("clientes");
  }
}
 const addValorIDRep = (e: any) => {
                        if (e?.id>0)
                        preclientesData.idrep = e.id;
                      };

  const onConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    if (!isSubmitting) {
      setIsSubmitting(true);
      onSubmit(e);
    }
   };

  const onPressSalvar = (e: any) => {
    e.preventDefault();
    if (!isSubmitting) {
      const formElement = document.getElementById('PreClientesForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container">
       
            <form id={`PreClientesForm-${preclientesData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={preclientesData} isSubmitting={isSubmitting} onClose={onClose} formId={`PreClientesForm-${preclientesData.id}`} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={preclientesData.nome}
            placeholder={`Digite nome pre clientes`}
            onChange={onChange}
            required
          />

                <InputCheckbox label="Inativo" name="inativo" checked={preclientesData.inativo} onChange={onChange} />
        
<Input
type="text"
id="quemindicou"
label="QuemIndicou"
className="inputIncNome"
name="quemindicou"
value={preclientesData.quemindicou}
onChange={onChange}               
/>

<Input
type="text"
id="adv"
label="Adv"
className="inputIncNome"
name="adv"
value={preclientesData.adv}
onChange={onChange}               
/>

            <ClientesComboBox
            name={'idrep'}
            value={preclientesData.idrep}
            setValue={addValorIDRep}
            label={'Clientes'}
            />

<InputCheckbox label="Juridica" name="juridica" checked={preclientesData.juridica} onChange={onChange} />
        
<Input
type="text"
id="nomefantasia"
label="NomeFantasia"
className="inputIncNome"
name="nomefantasia"
value={preclientesData.nomefantasia}
onChange={onChange}               
/>

<Input
type="text"
id="class"
label="Class"
className="inputIncNome"
name="class"
value={preclientesData.class}
onChange={onChange}               
/>

<InputCheckbox label="Tipo" name="tipo" checked={preclientesData.tipo} onChange={onChange} />
        
<Input
type="text"
id="dtnasc"
label="DtNasc"
className="inputIncNome"
name="dtnasc"
value={preclientesData.dtnasc}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="inscest"
label="InscEst"
className="inputIncNome"
name="inscest"
value={preclientesData.inscest}
onChange={onChange}               
/>

<Input
type="text"
id="qualificacao"
label="Qualificacao"
className="inputIncNome"
name="qualificacao"
value={preclientesData.qualificacao}
onChange={onChange}               
/>

<InputCheckbox label="Sexo" name="sexo" checked={preclientesData.sexo} onChange={onChange} />
        
<Input
type="text"
id="idade"
label="Idade"
className="inputIncNome"
name="idade"
value={preclientesData.idade}
onChange={onChange}               
/>

<InputCnpj
type="text"
id="cnpj"
label="CNPJ"
className="inputIncNome"
name="cnpj"
value={preclientesData.cnpj}
onChange={onChange}               
/>

<InputCpf
type="text"
id="cpf"
label="CPF"
className="inputIncNome"
name="cpf"
value={preclientesData.cpf}
onChange={onChange}               
/>

<Input
type="text"
id="rg"
label="RG"
className="inputIncNome"
name="rg"
value={preclientesData.rg}
onChange={onChange}               
/>

<InputCheckbox label="TipoCaptacao" name="tipocaptacao" checked={preclientesData.tipocaptacao} onChange={onChange} />
        
<Input
type="text"
id="observacao"
label="Observacao"
className="inputIncNome"
name="observacao"
value={preclientesData.observacao}
onChange={onChange}               
/>

<Input
type="text"
id="endereco"
label="Endereco"
className="inputIncNome"
name="endereco"
value={preclientesData.endereco}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="bairro"
label="Bairro"
className="inputIncNome"
name="bairro"
value={preclientesData.bairro}
onChange={onChange}               
/>

<Input
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={preclientesData.cidade}
onChange={onChange}               
/>

<InputCep
type="text"
id="cep"
label="CEP"
className="inputIncNome"
name="cep"
value={preclientesData.cep}
onChange={onChange}               
/>

<Input
type="text"
id="fax"
label="Fax"
className="inputIncNome"
name="fax"
value={preclientesData.fax}
onChange={onChange}               
/>

<Input
type="text"
id="fone"
label="Fone"
className="inputIncNome"
name="fone"
value={preclientesData.fone}
onChange={onChange}               
/>

<Input
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={preclientesData.data}
onChange={onChange}               
/>

<Input
type="text"
id="homepage"
label="HomePage"
className="inputIncNome"
name="homepage"
value={preclientesData.homepage}
onChange={onChange}               
/>

<Input
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={preclientesData.email}
onChange={onChange}               
/>

<Input
type="text"
id="assistido"
label="Assistido"
className="inputIncNome"
name="assistido"
value={preclientesData.assistido}
onChange={onChange}               
/>

<Input
type="text"
id="assrg"
label="AssRG"
className="inputIncNome"
name="assrg"
value={preclientesData.assrg}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="asscpf"
label="AssCPF"
className="inputIncNome"
name="asscpf"
value={preclientesData.asscpf}
onChange={onChange}               
/>

<Input
type="text"
id="assendereco"
label="AssEndereco"
className="inputIncNome"
name="assendereco"
value={preclientesData.assendereco}
onChange={onChange}               
/>

<Input
type="text"
id="cnh"
label="CNH"
className="inputIncNome"
name="cnh"
value={preclientesData.cnh}
onChange={onChange}               
/>

<InputCheckbox label="Ani" name="ani" checked={preclientesData.ani} onChange={onChange} />

                </div>               
            </form>
        </div>
        
    </>
     );
};
 