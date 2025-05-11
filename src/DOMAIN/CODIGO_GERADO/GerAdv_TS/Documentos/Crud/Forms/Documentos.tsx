// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IDocumentos } from '@/app/GerAdv_TS/Documentos/Interfaces/interface.Documentos';
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

import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'

interface DocumentosFormProps {
    documentosData: IDocumentos;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const DocumentosForm: React.FC<DocumentosFormProps> = ({
    documentosData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeProcessos, setNomeProcessos] = useState('');
            const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("processos") > 0) {
  processosApi
    .getById(getParamFromUrl("processos"))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

  if (documentosData.id === 0) {
    documentosData.processo = getParamFromUrl("processos");
  }
}
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        documentosData.processo = e.id;
                      };

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
        console.error("Erro ao submeter formulário de Documentos:", error);
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
          target: document.getElementById(`DocumentosForm-${documentosData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar Documentos diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-Documentos' : 'form-container5 form-container-Documentos'}>
       
            <form className='formInputCadInc' id={`DocumentosForm-${documentosData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={documentosData} isSubmitting={isSubmitting} onClose={onClose} formId={`DocumentosForm-${documentosData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

            <ProcessosComboBox
            name={'processo'}
            value={documentosData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

<InputInput
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={documentosData.data}
onChange={onChange}               
/>

<InputInput
type="text"
id="observacao"
label="Observacao"
className="inputIncNome"
name="observacao"
value={documentosData.observacao}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 