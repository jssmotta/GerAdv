// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IContatoCRMView } from '@/app/GerAdv_TS/ContatoCRMView/Interfaces/interface.ContatoCRMView';
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

interface ContatoCRMViewFormProps {
    contatocrmviewData: IContatoCRMView;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ContatoCRMViewForm: React.FC<ContatoCRMViewFormProps> = ({
    contatocrmviewData,
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
      const formElement = document.getElementById('ContatoCRMViewForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`ContatoCRMViewForm-${contatocrmviewData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={contatocrmviewData} isSubmitting={isSubmitting} onClose={onClose} formId={`ContatoCRMViewForm-${contatocrmviewData.id}`} />

                <div className="grid-container">

<Input
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={contatocrmviewData.data}
onChange={onChange}               
/>

<Input
type="text"
id="ip"
label="IP"
className="inputIncNome"
name="ip"
value={contatocrmviewData.ip}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        
    </>
     );
};
 