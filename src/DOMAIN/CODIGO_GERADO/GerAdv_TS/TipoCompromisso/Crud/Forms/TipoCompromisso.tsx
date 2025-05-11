// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { ITipoCompromisso } from '@/app/GerAdv_TS/TipoCompromisso/Interfaces/interface.TipoCompromisso';
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
        console.error("Erro ao submeter formulário de TipoCompromisso:", error);
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
          target: document.getElementById(`TipoCompromissoForm-${tipocompromissoData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar TipoCompromisso diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-TipoCompromisso' : 'form-container5 form-container-TipoCompromisso'}>
       
            <form className='formInputCadInc' id={`TipoCompromissoForm-${tipocompromissoData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={tipocompromissoData} isSubmitting={isSubmitting} onClose={onClose} formId={`TipoCompromissoForm-${tipocompromissoData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputDescription
            type="text"            
            id="descricao"
            label="tipo compromisso"
            className="inputIncNome"
            name="descricao"
            value={tipocompromissoData.descricao}
            placeholder={`Digite nome tipo compromisso`}
            onChange={onChange}
            required
            disabled={tipocompromissoData.id > 0}
          />

<InputInput
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
        <div className="form-spacer"></div>
        
    </>
     );
};
 