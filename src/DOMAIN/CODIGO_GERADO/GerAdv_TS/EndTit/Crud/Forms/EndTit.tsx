// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IEndTit } from '@/app/GerAdv_TS/EndTit/Interfaces/interface.EndTit';
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

interface EndTitFormProps {
    endtitData: IEndTit;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const EndTitForm: React.FC<EndTitFormProps> = ({
    endtitData,
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
      const formElement = document.getElementById('EndTitForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`EndTitForm-${endtitData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={endtitData} isSubmitting={isSubmitting} onClose={onClose} formId={`EndTitForm-${endtitData.id}`} />

                <div className="grid-container">

<Input
type="text"
id="endereco"
label="Endereco"
className="inputIncNome"
name="endereco"
value={endtitData.endereco}
onChange={onChange}               
/>

<Input
type="text"
id="titulo"
label="Titulo"
className="inputIncNome"
name="titulo"
value={endtitData.titulo}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        
    </>
     );
};
 