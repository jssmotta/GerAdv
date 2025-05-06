// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IRamal } from '@/app/GerAdv_TS/Ramal/Interfaces/interface.Ramal';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import InputName from '@/app/components/Inputs/InputName';

interface RamalFormProps {
    ramalData: IRamal;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const RamalForm: React.FC<RamalFormProps> = ({
    ramalData,
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
      const formElement = document.getElementById('RamalForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`RamalForm-${ramalData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={ramalData} isSubmitting={isSubmitting} onClose={onClose} formId={`RamalForm-${ramalData.id}`} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={ramalData.nome}
            placeholder={`Digite nome ramal`}
            onChange={onChange}
            required
          />

<Input
type="text"
id="obs"
label="Obs"
className="inputIncNome"
name="obs"
value={ramalData.obs}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        
    </>
     );
};
 