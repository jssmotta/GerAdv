// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IContatoCRMView } from '@/app/GerAdv_TS/ContatoCRMView/Interfaces/interface.ContatoCRMView';
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

import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'

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
        console.error("Erro ao submeter formulário de ContatoCRMView:", error);
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
          target: document.getElementById(`ContatoCRMViewForm-${contatocrmviewData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar ContatoCRMView diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-ContatoCRMView' : 'form-container5 form-container-ContatoCRMView'}>
       
            <form className='formInputCadInc' id={`ContatoCRMViewForm-${contatocrmviewData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={contatocrmviewData} isSubmitting={isSubmitting} onClose={onClose} formId={`ContatoCRMViewForm-${contatocrmviewData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

<InputInput
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={contatocrmviewData.data}
onChange={onChange}               
/>

<InputInput
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
        <div className="form-spacer"></div>
        
    </>
     );
};
 