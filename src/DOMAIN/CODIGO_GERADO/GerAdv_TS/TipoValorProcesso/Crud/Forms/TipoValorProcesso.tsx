// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { ITipoValorProcesso } from '@/app/GerAdv_TS/TipoValorProcesso/Interfaces/interface.TipoValorProcesso';
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

interface TipoValorProcessoFormProps {
    tipovalorprocessoData: ITipoValorProcesso;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const TipoValorProcessoForm: React.FC<TipoValorProcessoFormProps> = ({
    tipovalorprocessoData,
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
        console.error("Erro ao submeter formulário de TipoValorProcesso:", error);
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
          target: document.getElementById(`TipoValorProcessoForm-${tipovalorprocessoData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar TipoValorProcesso diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-TipoValorProcesso' : 'form-container5 form-container-TipoValorProcesso'}>
       
            <form className='formInputCadInc' id={`TipoValorProcessoForm-${tipovalorprocessoData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={tipovalorprocessoData} isSubmitting={isSubmitting} onClose={onClose} formId={`TipoValorProcessoForm-${tipovalorprocessoData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputDescription
            type="text"            
            id="descricao"
            label="tipo valor processo"
            className="inputIncNome"
            name="descricao"
            value={tipovalorprocessoData.descricao}
            placeholder={`Digite nome tipo valor processo`}
            onChange={onChange}
            required
            disabled={tipovalorprocessoData.id > 0}
          />

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 