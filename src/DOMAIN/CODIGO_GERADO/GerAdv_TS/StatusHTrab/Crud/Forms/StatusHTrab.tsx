// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IStatusHTrab } from '@/app/GerAdv_TS/StatusHTrab/Interfaces/interface.StatusHTrab';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/CrudFormsMobile.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import InputDescription from '@/app/components/Inputs/InputDescription';
import InputInput from '@/app/components/Inputs/InputInput'

interface StatusHTrabFormProps {
    statushtrabData: IStatusHTrab;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const StatusHTrabForm: React.FC<StatusHTrabFormProps> = ({
    statushtrabData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  
    const onConfirm = (e: React.FormEvent) => {
    // Importante: prevenir comportamento padrão e propagação
    e.preventDefault();
    if (e.stopPropagation) e.stopPropagation();
    
    // Evitar múltiplos envios
    if (!isSubmitting) {
      setIsSubmitting(true);
      
      // Chamar onSubmit com o evento
      try {
        onSubmit(e);
      } catch (error) {
        console.error("Erro ao submeter formulário de StatusHTrab:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  // Handler para submissão direta via ButtonsCrud
  const handleDirectSave = () => {
    if (!isSubmitting) {
      setIsSubmitting(true);
      
      try {
        // Criar um evento sintético básico para manter compatibilidade
        const syntheticEvent = {
          preventDefault: () => { },
          target: document.getElementById(`StatusHTrabForm-${statushtrabData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar StatusHTrab diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-StatusHTrab' : 'form-container5 form-container-StatusHTrab'}>
       
            <form className='formInputCadInc' id={`StatusHTrabForm-${statushtrabData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={statushtrabData} isSubmitting={isSubmitting} onClose={onClose} formId={`StatusHTrabForm-${statushtrabData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputDescription
            type="text"            
            id="descricao"
            label="status h trab"
            className="inputIncNome"
            name="descricao"
            value={statushtrabData.descricao}
            placeholder={`Digite nome status h trab`}
            onChange={onChange}
            required
            disabled={statushtrabData.id > 0}
          />

<InputInput
type="text"
id="resid"
label="ResID"
className="inputIncNome"
name="resid"
value={statushtrabData.resid}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 