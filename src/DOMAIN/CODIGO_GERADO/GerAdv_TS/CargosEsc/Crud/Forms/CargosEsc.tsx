// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { ICargosEsc } from '@/app/GerAdv_TS/CargosEsc/Interfaces/interface.CargosEsc';
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

interface CargosEscFormProps {
    cargosescData: ICargosEsc;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const CargosEscForm: React.FC<CargosEscFormProps> = ({
    cargosescData,
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
      const formElement = document.getElementById('CargosEscForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`CargosEscForm-${cargosescData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={cargosescData} isSubmitting={isSubmitting} onClose={onClose} formId={`CargosEscForm-${cargosescData.id}`} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={cargosescData.nome}
            placeholder={`Digite nome cargos esc`}
            onChange={onChange}
            required
          />

<Input
type="text"
id="percentual"
label="Percentual"
className="inputIncNome"
name="percentual"
value={cargosescData.percentual}
onChange={onChange}               
/>

<Input
type="text"
id="classificacao"
label="Classificacao"
className="inputIncNome"
name="classificacao"
value={cargosescData.classificacao}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        
    </>
     );
};
 