// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IServicos } from '@/app/GerAdv_TS/Servicos/Interfaces/interface.Servicos';
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
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

interface ServicosFormProps {
    servicosData: IServicos;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ServicosForm: React.FC<ServicosFormProps> = ({
    servicosData,
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
        console.error("Erro ao submeter formulário de Servicos:", error);
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
          target: document.getElementById(`ServicosForm-${servicosData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar Servicos diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-Servicos' : 'form-container5 form-container-Servicos'}>
       
            <form className='formInputCadInc' id={`ServicosForm-${servicosData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={servicosData} isSubmitting={isSubmitting} onClose={onClose} formId={`ServicosForm-${servicosData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputDescription
            type="text"            
            id="descricao"
            label="serviço"
            className="inputIncNome"
            name="descricao"
            value={servicosData.descricao}
            placeholder={`Digite nome serviço`}
            onChange={onChange}
            required
            disabled={servicosData.id > 0}
          />

                <InputCheckbox label="Cobrar" name="cobrar" checked={servicosData.cobrar} onChange={onChange} />
<InputCheckbox label="Basico" name="basico" checked={servicosData.basico} onChange={onChange} />

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 