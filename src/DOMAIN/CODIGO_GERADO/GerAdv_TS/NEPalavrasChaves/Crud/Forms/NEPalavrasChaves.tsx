// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { INEPalavrasChaves } from '@/app/GerAdv_TS/NEPalavrasChaves/Interfaces/interface.NEPalavrasChaves';
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

interface NEPalavrasChavesFormProps {
    nepalavraschavesData: INEPalavrasChaves;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const NEPalavrasChavesForm: React.FC<NEPalavrasChavesFormProps> = ({
    nepalavraschavesData,
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
        console.error("Erro ao submeter formulário de NEPalavrasChaves:", error);
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
          target: document.getElementById(`NEPalavrasChavesForm-${nepalavraschavesData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar NEPalavrasChaves diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-NEPalavrasChaves' : 'form-container5 form-container-NEPalavrasChaves'}>
       
            <form className='formInputCadInc' id={`NEPalavrasChavesForm-${nepalavraschavesData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={nepalavraschavesData} isSubmitting={isSubmitting} onClose={onClose} formId={`NEPalavrasChavesForm-${nepalavraschavesData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="Nome"
            className="inputIncNome"
            name="nome"
            value={nepalavraschavesData.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
          />

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 