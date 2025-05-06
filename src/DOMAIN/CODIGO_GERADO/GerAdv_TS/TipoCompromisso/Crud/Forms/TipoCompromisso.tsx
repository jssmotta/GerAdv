// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { ITipoCompromisso } from '@/app/GerAdv_TS/TipoCompromisso/Interfaces/interface.TipoCompromisso';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import InputDescription from '@/app/components/Inputs/InputDescription';
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

interface TipoCompromissoFormProps {
    tipocompromissoData: ITipoCompromisso;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const TipoCompromissoForm: React.FC<TipoCompromissoFormProps> = ({
    tipocompromissoData,
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
      const formElement = document.getElementById('TipoCompromissoForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`TipoCompromissoForm-${tipocompromissoData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={tipocompromissoData} isSubmitting={isSubmitting} onClose={onClose} formId={`TipoCompromissoForm-${tipocompromissoData.id}`} />

                <div className="grid-container">

    <InputDescription
            type="text"            
            id="descricao"
            label="descricao"
            className="inputIncNome"
            name="descricao"
            value={tipocompromissoData.descricao}
            placeholder={`Digite nome tipo compromisso`}
            onChange={onChange}
            required
            disabled={tipocompromissoData.id > 0}
          />

<Input
type="text"
id="icone"
label="Icone"
className="inputIncNome"
name="icone"
value={tipocompromissoData.icone}
onChange={onChange}               
/>

<InputCheckbox label="Financeiro" name="financeiro" checked={tipocompromissoData.financeiro} onChange={onChange} />

                </div>               
            </form>
        </div>
        
    </>
     );
};
 