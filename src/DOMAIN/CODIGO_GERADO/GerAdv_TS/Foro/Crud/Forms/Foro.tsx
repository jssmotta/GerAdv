// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IForo } from '@/app/GerAdv_TS/Foro/Interfaces/interface.Foro';
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
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
import InputCep from '@/app/components/Inputs/InputCep'

interface ForoFormProps {
    foroData: IForo;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ForoForm: React.FC<ForoFormProps> = ({
    foroData,
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
      const formElement = document.getElementById('ForoForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container">
       
            <form id={`ForoForm-${foroData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={foroData} isSubmitting={isSubmitting} onClose={onClose} formId={`ForoForm-${foroData.id}`} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={foroData.nome}
            placeholder={`Digite nome foro`}
            onChange={onChange}
            required
          />

<Input
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={foroData.email}
onChange={onChange}               
/>

<InputCheckbox label="Unico" name="unico" checked={foroData.unico} onChange={onChange} />
        
<Input
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={foroData.cidade}
onChange={onChange}               
/>

<Input
type="text"
id="site"
label="Site"
className="inputIncNome"
name="site"
value={foroData.site}
onChange={onChange}               
/>

<Input
type="text"
id="endereco"
label="Endereco"
className="inputIncNome"
name="endereco"
value={foroData.endereco}
onChange={onChange}               
/>

<Input
type="text"
id="bairro"
label="Bairro"
className="inputIncNome"
name="bairro"
value={foroData.bairro}
onChange={onChange}               
/>

<Input
type="text"
id="fone"
label="Fone"
className="inputIncNome"
name="fone"
value={foroData.fone}
onChange={onChange}               
/>

<Input
type="text"
id="fax"
label="Fax"
className="inputIncNome"
name="fax"
value={foroData.fax}
onChange={onChange}               
/>

<InputCep
type="text"
id="cep"
label="CEP"
className="inputIncNome"
name="cep"
value={foroData.cep}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="obs"
label="OBS"
className="inputIncNome"
name="obs"
value={foroData.obs}
onChange={onChange}               
/>

<InputCheckbox label="UnicoConfirmado" name="unicoconfirmado" checked={foroData.unicoconfirmado} onChange={onChange} />
        
<Input
type="text"
id="web"
label="Web"
className="inputIncNome"
name="web"
value={foroData.web}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        
    </>
     );
};
 