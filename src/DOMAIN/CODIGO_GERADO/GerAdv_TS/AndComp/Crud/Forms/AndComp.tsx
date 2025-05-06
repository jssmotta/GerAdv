// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IAndComp } from '@/app/GerAdv_TS/AndComp/Interfaces/interface.AndComp';
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

interface AndCompFormProps {
    andcompData: IAndComp;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const AndCompForm: React.FC<AndCompFormProps> = ({
    andcompData,
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
      const formElement = document.getElementById('AndCompForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`AndCompForm-${andcompData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={andcompData} isSubmitting={isSubmitting} onClose={onClose} formId={`AndCompForm-${andcompData.id}`} />

                <div className="grid-container">

<Input
type="text"
id="andamento"
label="Andamento"
className="inputIncNome"
name="andamento"
value={andcompData.andamento}
onChange={onChange}               
/>

<Input
type="text"
id="compromisso"
label="Compromisso"
className="inputIncNome"
name="compromisso"
value={andcompData.compromisso}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        
    </>
     );
};
 