// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IEnderecos } from '@/app/GerAdv_TS/Enderecos/Interfaces/interface.Enderecos';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import InputDescription from '@/app/components/Inputs/InputDescription';
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
import InputCep from '@/app/components/Inputs/InputCep'

interface EnderecosFormProps {
    enderecosData: IEnderecos;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const EnderecosForm: React.FC<EnderecosFormProps> = ({
    enderecosData,
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
      const formElement = document.getElementById('EnderecosForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container">
       
            <form id={`EnderecosForm-${enderecosData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={enderecosData} isSubmitting={isSubmitting} onClose={onClose} formId={`EnderecosForm-${enderecosData.id}`} />

                <div className="grid-container">

    <InputDescription
            type="text"            
            id="descricao"
            label="descricao"
            className="inputIncNome"
            name="descricao"
            value={enderecosData.descricao}
            placeholder={`Digite nome endereço`}
            onChange={onChange}
            required
            disabled={enderecosData.id > 0}
          />

                <InputCheckbox label="TopIndex" name="topindex" checked={enderecosData.topindex} onChange={onChange} />
        
<Input
type="text"
id="contato"
label="Contato"
className="inputIncNome"
name="contato"
value={enderecosData.contato}
onChange={onChange}               
/>

<Input
type="text"
id="dtnasc"
label="DtNasc"
className="inputIncNome"
name="dtnasc"
value={enderecosData.dtnasc}
onChange={onChange}               
/>

<Input
type="text"
id="endereco"
label="Endereco"
className="inputIncNome"
name="endereco"
value={enderecosData.endereco}
onChange={onChange}               
/>

<Input
type="text"
id="bairro"
label="Bairro"
className="inputIncNome"
name="bairro"
value={enderecosData.bairro}
onChange={onChange}               
/>

<InputCheckbox label="Privativo" name="privativo" checked={enderecosData.privativo} onChange={onChange} />
<InputCheckbox label="AddContato" name="addcontato" checked={enderecosData.addcontato} onChange={onChange} />
        
<InputCep
type="text"
id="cep"
label="CEP"
className="inputIncNome"
name="cep"
value={enderecosData.cep}
onChange={onChange}               
/>

<Input
type="text"
id="oab"
label="OAB"
className="inputIncNome"
name="oab"
value={enderecosData.oab}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="obs"
label="OBS"
className="inputIncNome"
name="obs"
value={enderecosData.obs}
onChange={onChange}               
/>

<Input
type="text"
id="fone"
label="Fone"
className="inputIncNome"
name="fone"
value={enderecosData.fone}
onChange={onChange}               
/>

<Input
type="text"
id="fax"
label="Fax"
className="inputIncNome"
name="fax"
value={enderecosData.fax}
onChange={onChange}               
/>

<Input
type="text"
id="tratamento"
label="Tratamento"
className="inputIncNome"
name="tratamento"
value={enderecosData.tratamento}
onChange={onChange}               
/>

<Input
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={enderecosData.cidade}
onChange={onChange}               
/>

<Input
type="text"
id="site"
label="Site"
className="inputIncNome"
name="site"
value={enderecosData.site}
onChange={onChange}               
/>

<Input
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={enderecosData.email}
onChange={onChange}               
/>

<Input
type="text"
id="quem"
label="Quem"
className="inputIncNome"
name="quem"
value={enderecosData.quem}
onChange={onChange}               
/>

<Input
type="text"
id="quemindicou"
label="QuemIndicou"
className="inputIncNome"
name="quemindicou"
value={enderecosData.quemindicou}
onChange={onChange}               
/>

<InputCheckbox label="ReportECBOnly" name="reportecbonly" checked={enderecosData.reportecbonly} onChange={onChange} />
</div><div className="grid-container"><InputCheckbox label="Ani" name="ani" checked={enderecosData.ani} onChange={onChange} />

                </div>               
            </form>
        </div>
        
    </>
     );
};
 