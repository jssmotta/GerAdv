// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { ISituacao } from '@/app/GerAdv_TS/Situacao/Interfaces/interface.Situacao';
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
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

interface SituacaoFormProps {
    situacaoData: ISituacao;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const SituacaoForm: React.FC<SituacaoFormProps> = ({
    situacaoData,
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
      const formElement = document.getElementById('SituacaoForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`SituacaoForm-${situacaoData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={situacaoData} isSubmitting={isSubmitting} onClose={onClose} formId={`SituacaoForm-${situacaoData.id}`} />

                <div className="grid-container">

<Input
type="text"
id="parte_int"
label="Parte_Int"
className="inputIncNome"
name="parte_int"
value={situacaoData.parte_int}
onChange={onChange}               
/>

<Input
type="text"
id="parte_opo"
label="Parte_Opo"
className="inputIncNome"
name="parte_opo"
value={situacaoData.parte_opo}
onChange={onChange}               
/>

<InputCheckbox label="Top" name="top" checked={situacaoData.top} onChange={onChange} />

                </div>               
            </form>
        </div>
        
    </>
     );
};
 