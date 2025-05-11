// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IApenso } from '@/app/GerAdv_TS/Apenso/Interfaces/interface.Apenso';
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

interface ApensoFormProps {
    apensoData: IApenso;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ApensoForm: React.FC<ApensoFormProps> = ({
    apensoData,
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

  if (apensoData.id === 0) {
    apensoData.processo = getParamFromUrl("processos");
  }
}
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        apensoData.processo = e.id;
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
        console.error("Erro ao submeter formulário de Apenso:", error);
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
          target: document.getElementById(`ApensoForm-${apensoData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar Apenso diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-Apenso' : 'form-container5 form-container-Apenso'}>
       
            <form className='formInputCadInc' id={`ApensoForm-${apensoData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={apensoData} isSubmitting={isSubmitting} onClose={onClose} formId={`ApensoForm-${apensoData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

            <ProcessosComboBox
            name={'processo'}
            value={apensoData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

<InputInput
type="text"
id="apensox"
label="Apenso"
className="inputIncNome"
name="apensox"
value={apensoData.apensox}
onChange={onChange}               
/>

<InputInput
type="text"
id="acao"
label="Acao"
className="inputIncNome"
name="acao"
value={apensoData.acao}
onChange={onChange}               
/>

<InputInput
type="text"
id="dtdist"
label="DtDist"
className="inputIncNome"
name="dtdist"
value={apensoData.dtdist}
onChange={onChange}               
/>

<InputInput
type="text"
id="obs"
label="OBS"
className="inputIncNome"
name="obs"
value={apensoData.obs}
onChange={onChange}               
/>

<InputInput
type="text"
id="valorcausa"
label="ValorCausa"
className="inputIncNome"
name="valorcausa"
value={apensoData.valorcausa}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 