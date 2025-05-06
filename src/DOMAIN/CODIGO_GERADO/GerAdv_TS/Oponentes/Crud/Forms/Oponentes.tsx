// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IOponentes } from '@/app/GerAdv_TS/Oponentes/Interfaces/interface.Oponentes';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import InputName from '@/app/components/Inputs/InputName';
import InputCnpj from '@/app/components/Inputs/InputCnpj'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
import InputCpf from '@/app/components/Inputs/InputCpf'
import InputCep from '@/app/components/Inputs/InputCep'

interface OponentesFormProps {
    oponentesData: IOponentes;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const OponentesForm: React.FC<OponentesFormProps> = ({
    oponentesData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  
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
      const formElement = document.getElementById('OponentesForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container">
       
            <form id={`OponentesForm-${oponentesData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={oponentesData} isSubmitting={isSubmitting} onClose={onClose} formId={`OponentesForm-${oponentesData.id}`} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={oponentesData.nome}
            placeholder={`Digite nome oponentes`}
            onChange={onChange}
            required
          />

<Input
type="text"
id="empfuncao"
label="EMPFuncao"
className="inputIncNome"
name="empfuncao"
value={oponentesData.empfuncao}
onChange={onChange}               
/>

<Input
type="text"
id="ctpsnumero"
label="CTPSNumero"
className="inputIncNome"
name="ctpsnumero"
value={oponentesData.ctpsnumero}
onChange={onChange}               
/>

<Input
type="text"
id="site"
label="Site"
className="inputIncNome"
name="site"
value={oponentesData.site}
onChange={onChange}               
/>

<Input
type="text"
id="ctpsserie"
label="CTPSSerie"
className="inputIncNome"
name="ctpsserie"
value={oponentesData.ctpsserie}
onChange={onChange}               
/>

<Input
type="text"
id="adv"
label="Adv"
className="inputIncNome"
name="adv"
value={oponentesData.adv}
onChange={onChange}               
/>

<Input
type="text"
id="empcliente"
label="EMPCliente"
className="inputIncNome"
name="empcliente"
value={oponentesData.empcliente}
onChange={onChange}               
/>

<Input
type="text"
id="idrep"
label="IDRep"
className="inputIncNome"
name="idrep"
value={oponentesData.idrep}
onChange={onChange}               
/>

<Input
type="text"
id="pis"
label="PIS"
className="inputIncNome"
name="pis"
value={oponentesData.pis}
onChange={onChange}               
/>

<Input
type="text"
id="contato"
label="Contato"
className="inputIncNome"
name="contato"
value={oponentesData.contato}
onChange={onChange}               
/>

</div><div className="grid-container">        
<InputCnpj
type="text"
id="cnpj"
label="CNPJ"
className="inputIncNome"
name="cnpj"
value={oponentesData.cnpj}
onChange={onChange}               
/>

<Input
type="text"
id="rg"
label="RG"
className="inputIncNome"
name="rg"
value={oponentesData.rg}
onChange={onChange}               
/>

<InputCheckbox label="Juridica" name="juridica" checked={oponentesData.juridica} onChange={onChange} />
<InputCheckbox label="Tipo" name="tipo" checked={oponentesData.tipo} onChange={onChange} />
<InputCheckbox label="Sexo" name="sexo" checked={oponentesData.sexo} onChange={onChange} />
        
<InputCpf
type="text"
id="cpf"
label="CPF"
className="inputIncNome"
name="cpf"
value={oponentesData.cpf}
onChange={onChange}               
/>

<Input
type="text"
id="endereco"
label="Endereco"
className="inputIncNome"
name="endereco"
value={oponentesData.endereco}
onChange={onChange}               
/>

<Input
type="text"
id="fone"
label="Fone"
className="inputIncNome"
name="fone"
value={oponentesData.fone}
onChange={onChange}               
/>

<Input
type="text"
id="fax"
label="Fax"
className="inputIncNome"
name="fax"
value={oponentesData.fax}
onChange={onChange}               
/>

<Input
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={oponentesData.cidade}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="bairro"
label="Bairro"
className="inputIncNome"
name="bairro"
value={oponentesData.bairro}
onChange={onChange}               
/>

<InputCep
type="text"
id="cep"
label="CEP"
className="inputIncNome"
name="cep"
value={oponentesData.cep}
onChange={onChange}               
/>

<Input
type="text"
id="inscest"
label="InscEst"
className="inputIncNome"
name="inscest"
value={oponentesData.inscest}
onChange={onChange}               
/>

<Input
type="text"
id="observacao"
label="Observacao"
className="inputIncNome"
name="observacao"
value={oponentesData.observacao}
onChange={onChange}               
/>

<Input
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={oponentesData.email}
onChange={onChange}               
/>

<Input
type="text"
id="class"
label="Class"
className="inputIncNome"
name="class"
value={oponentesData.class}
onChange={onChange}               
/>

<InputCheckbox label="Top" name="top" checked={oponentesData.top} onChange={onChange} />

                </div>               
            </form>
        </div>
        
    </>
     );
};
 